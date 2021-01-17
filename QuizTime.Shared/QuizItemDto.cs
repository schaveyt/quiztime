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

        public QuizItemDto Copy()
        {   
            return (QuizItemDto) this.MemberwiseClone();
        }

        public void Update(QuizItemDto dto)
        {   
            Id = dto.Id;
            QuestionType = dto.QuestionType;
            SkillLevel = dto.SkillLevel;
            Question = dto.Question;
            AnswerIndex = dto.AnswerIndex;
        }

        public override string ToString()
        {
            return $"id={Id}, QuestionType={QuestionType}, Question:={Question??"null"}, AnswerIndex={AnswerIndex}";
        }
    }
}