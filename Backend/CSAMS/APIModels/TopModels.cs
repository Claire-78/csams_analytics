using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.APIModels
{
    public class TopModel : IAPIModel
    {
        public float Grade { get; set; }
        public string AssingmentName { get; set; }
        public int AssingmentID { get; set; }
        public int ReviewerID { get; set; }


        public string type { get; set; }
        public bool AssertEqual(IAPIModel other)
        {
            var otherProject = other as TopModel;
            return (Grade == otherProject.Grade &&
                AssingmentName == otherProject.AssingmentName &&
                type == otherProject.type &&
               ReviewerID==otherProject.ReviewerID&&
                AssingmentID == otherProject.AssingmentID);
        }
    }
}
