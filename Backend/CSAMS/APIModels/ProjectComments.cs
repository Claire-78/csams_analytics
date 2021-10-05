using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.APIModels
{
    public class ProjectComments : APIModel
    {
        public int Target { get; set; }
        public int Reviewer { get; set; }
        public string AnswerType { get; set; }
        public string Answer { get; set; }
        public string Comment { get; set; }

        public override bool AssertEqual(APIModel other)
        {
            var otherProject = other as ProjectComments;
            return (Target == otherProject.Target &&
                Reviewer == otherProject.Reviewer &&
                AnswerType == otherProject.AnswerType &&
                Answer == otherProject.Answer &&
                Comment == otherProject.Comment);
        }
    }
}
