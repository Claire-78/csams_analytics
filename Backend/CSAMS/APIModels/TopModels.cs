using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.APIModels
{
    public class TopModel : IAPIModel
    {
        public float Grade { get; set; }
        public string AssignmentName { get; set; }
        public int AssignmentID { get; set; }
        public int ReviewerID { get; set; }


        public string type { get; set; }
        public bool AssertEqual(IAPIModel other)
        {
            var otherProject = other as TopModel;
            return (Grade == otherProject.Grade &&
                AssignmentName == otherProject.AssignmentName &&
                type == otherProject.type &&
               ReviewerID==otherProject.ReviewerID&&
                AssignmentID == otherProject.AssignmentID);
        }
    }
}
