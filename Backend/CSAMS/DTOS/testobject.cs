namespace CSAMS.DTOS
{
    public class Filter
    {
        public string Assignment { get; set; }
        public string ReviewerID { get; set; }
        public string TargetID { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class PostMessage
    {
        public int Id { get; set; }
        public string AnswerType { get; set; }
        public string Answer { get; set; }
        public string Comment { get; set; }
    }
}

