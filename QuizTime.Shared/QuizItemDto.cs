using System.Text.Json.Serialization;

namespace QuizTime.Shared.Data
{
    public class QuizItemDto
    {
        public int Id { get; set; }

        public QuestionTypeEnum QuestionType { get; set; }
        
        public int SkillLevel { get; set; }
        
        public string Question { get; set; }
        
        public int AnswerIndex { get; set; }
    }
}