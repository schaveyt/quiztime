
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizTime.Shared.Data;

namespace QuizTime.Api.Rest
{
    public interface IApiDataService
    {
        Task<int> Load();
        Task<int> Store();
    }

    public class ApiDataServiceFileStore : IApiDataService
    {

        public async Task<int> Load()
        {
            var errors = false;
            var csvFiles = Directory.EnumerateFiles("storage", "*.csv");
            foreach (var csvFile in csvFiles)
            {
                try
                {
                    await LoadFromFileCsv(csvFile);
                }
                catch (Exception e)
                {
                    errors = true;
                    Console.WriteLine("ApiDataServiceFileStore - ERROR - 001 - Encountered " +
                        $"exception while loading file: '{csvFile}':\n" + 
                        $"Message: {e.Message}\nStacktrace:\n{e.StackTrace}");
                }
            }

            if (errors)
            {
                return -1;
            }

            return 0;
        }

        public async Task LoadFromFileCsv(string csvFile)
        {
            var count = 0;
            var db = new QuizTimeDbContext();
            using (FileStream fs = new FileStream(csvFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fs))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (line[0] == '#')
                        {
                            continue;
                        }
                        
                        var cols = line.Split(',');
                        var answerIndex = 0;
                        var skillLevel = 0;
                        Int32.TryParse(cols[1], out skillLevel);
                        Int32.TryParse(cols[3], out answerIndex);

                        await db.QuizItems.AddAsync(
                            new QuizItemDto()
                            {
                                SkillLevel = skillLevel,
                                Question = cols[2],
                                QuestionType =  cols[0][0] == 'M' ? QuestionTypeEnum.MultipleChoice : QuestionTypeEnum.Boolean,
                                AnswerIndex = answerIndex
                            }
                        );

                        count++;
                    }
                }
            }

            await db.SaveChangesAsync();

            Console.WriteLine("ApiDataServiceFileStore - Loaded data file: " + 
                $"{csvFile} with {count} questions.");
        }
    
        public async Task<int> Store()
        {
            using var db = new QuizTimeDbContext();
            var results = await db.QuizItems.ToListAsync();

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            //
            using (StreamWriter outputFile = new StreamWriter("storage/data.csv"))
            {
                foreach (var item in results)
                {
                    await outputFile.WriteLineAsync(
                        $"{item.QuestionType},{0},{item.Question},{item.AnswerIndex}");
                }
            }

            return 0;            
        }
    }
}