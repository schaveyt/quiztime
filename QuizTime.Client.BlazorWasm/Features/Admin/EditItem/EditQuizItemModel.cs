using System.ComponentModel.DataAnnotations;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Admin.EditItem
{
    public class EditQuizItemModel
    {
        [Required]
        public QuestionTypeEnum QuestionType {get; set;}

        [Required]
        [StringLength(50, ErrorMessage = "Too long.")]
        public string Question {get; set;}

        [StringLength(25, ErrorMessage = "Too long.")]
        public string Choice0 {get; set;}

        [StringLength(25, ErrorMessage = "Too long.")]
        public string Choice1 {get; set;}

        [StringLength(25, ErrorMessage = "Too long.")]
        public string Choice2 {get; set;}

        [StringLength(25, ErrorMessage = "Too long.")]
        public string Choice3 {get; set;}

        [Required]
        [Range(0, 12, ErrorMessage = "Value range is 0 to 12")]
        public int SkillLevel {get; set;}

        [Required]
        [Range(0, 3, ErrorMessage = "Value must be 0, 1, 2, or 3")]
        public int AnswerIndex {get; set;}
    }
}
