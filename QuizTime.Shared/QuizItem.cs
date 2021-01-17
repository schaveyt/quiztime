using System;
using System.ComponentModel.DataAnnotations;

namespace QuizTime.Shared.Data
{
    public enum QuestionTypeEnum
    {
        MultipleChoice,
        Boolean,
        Verbal
    }
    public interface IQuizItem
    {
        public int Id { get; }
        public QuestionTypeEnum QuestionType { get; }
        public string[] Question { get; }
        public int AnswerIndex { get; }
        public string AnswerString { get; }

        public IQuizItem Copy();

        public QuizItemDto Dto();
    }

    public class MultipleChoiceQuizItem : IQuizItem
    {
        string _question;
        string[] _choices;
        int _answerIndex;

        public MultipleChoiceQuizItem()
        {
            _question = String.Empty;
            _choices = new string[0];
            _answerIndex = 0;
            Id = 0;
        }

        public MultipleChoiceQuizItem(string question, string[] choices, int answerIndex, int id = 0)
        {
            _question = question;
            _choices = choices;
            _answerIndex = answerIndex;
            Id = id;
        }

        public virtual IQuizItem Copy()
        {   
            return (IQuizItem) this.MemberwiseClone();
        }

        public virtual int Id { get; set; }

        public virtual QuestionTypeEnum QuestionType => QuestionTypeEnum.MultipleChoice;

        public virtual string[] Question
        {
            get
            {
                var result = new string[_choices.Length + 1];
                result[0] = _question;
                for (var i = 0; i < _choices.Length; i++)
                {
                    result[i + 1] = _choices[i];
                }
                return result;
            }
        }

        public virtual int AnswerIndex => _answerIndex;

        public virtual string AnswerString => "";

        public QuizItemDto Dto() 
        {
            return new QuizItemDto()
            {
                Id = Id,
                QuestionType = QuestionType,
                Question = string.Join('~', Question),
                AnswerIndex = AnswerIndex,
            };
        }

        public static implicit operator MultipleChoiceQuizItem(QuizItemDto i) 
        {
            var raw_question = new ArraySegment<string>(i.Question.Split('~'));
            ArraySegment<string> choices = null;

            if (raw_question.Count > 0)
            {
                choices = raw_question.Slice(1);
            }

            return new MultipleChoiceQuizItem
            (
                question: raw_question[0],
                choices: choices.ToArray(),
                answerIndex: i.AnswerIndex,
                id: i.Id
            );
        }

    }

    public class BooleanQuizItem : MultipleChoiceQuizItem
    {
        public BooleanQuizItem(string question, bool answer, int id = 0)
            : base(question, new string[] { "True", "False" }, answer ? 0 : 1, id)
        {
        }

        public override IQuizItem Copy()
        {   
            return (IQuizItem) this.MemberwiseClone();
        }

        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Boolean;

        public static implicit operator BooleanQuizItem(QuizItemDto i) 
        {
            var raw_question = i.Question.Split('~');

            return new BooleanQuizItem
            (
                question: raw_question[0],
                answer: i.AnswerIndex == 0 ? true : false,
                id: i.Id
            );
        }

    }
}