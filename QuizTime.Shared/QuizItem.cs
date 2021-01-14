using System;

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
    }

    public class MultipleChoiceQuizItem : IQuizItem
    {
        string _question;
        string[] _choices;
        int _answerIndex;

        public MultipleChoiceQuizItem(string question, string[] choices, int answerIndex, int id = 0)
        {
            _question = question;
            _choices = choices;
            _answerIndex = answerIndex;
            Id = id;
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

        public static implicit operator QuizItemDto(MultipleChoiceQuizItem i) 
        {
            return new QuizItemDto()
            {
                Id = i.Id,
                QuestionType = i.QuestionType,
                Question = string.Join('~', i.Question),
                AnswerIndex = i.AnswerIndex,
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
                answerIndex: i.AnswerIndex
            );
        }

    }

    public class BooleanQuizItem : MultipleChoiceQuizItem
    {
        public BooleanQuizItem(string question, bool answer)
            : base(question, new string[] { "True", "False" }, answer ? 0 : 1)
        {
        }

        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Boolean;

        public static implicit operator BooleanQuizItem(QuizItemDto i) 
        {
            var raw_question = i.Question.Split('~');

            return new BooleanQuizItem
            (
                question: raw_question[0],
                answer: i.AnswerIndex == 0 ? true : false
            );
        }

    }
}