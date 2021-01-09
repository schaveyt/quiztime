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

        public MultipleChoiceQuizItem(string question, string[] choices,int answerIndex)
        {
            _question = question;
            _choices = choices;
            _answerIndex = answerIndex;
        }

        public virtual QuestionTypeEnum QuestionType => QuestionTypeEnum.MultipleChoice;

        public string[] Question
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

        public int AnswerIndex => _answerIndex;

        public string AnswerString => "";

    }

    public class BooleanQuizItem : MultipleChoiceQuizItem
    {
        public BooleanQuizItem(string question, bool answer)
            : base(question, new string[]{ "True", "False"}, answer ? 0 : 1)
        {
        }

        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Boolean;

    }
}