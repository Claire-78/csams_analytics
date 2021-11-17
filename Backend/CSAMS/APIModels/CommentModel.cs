namespace CSAMS.APIModels
{
    public class CommentModel : IAPIModel
    {
        public int Target { get; set; }
        public int Reviewer { get; set; }
        public string AnswerType { get; set; }
        public string Answer { get; set; }
        public string Comment { get; set; }

        public bool AssertEqual(IAPIModel other)
        {
            var otherProject = other as CommentModel;
            return (Target == otherProject.Target &&
                Reviewer == otherProject.Reviewer &&
                AnswerType == otherProject.AnswerType &&
                Answer == otherProject.Answer &&
                Comment == otherProject.Comment);
        }
    }
}
