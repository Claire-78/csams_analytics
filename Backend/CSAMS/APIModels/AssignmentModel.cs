using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.APIModels
{
    public class AssignmentModel : IAPIModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReviewDeadline { get; set; }

        public bool AssertEqual(IAPIModel other)
        {
            var otherModel = other as AssignmentModel;
            return (otherModel.ID == ID &&
                otherModel.Name == Name &&
                otherModel.Course == Course &&
                otherModel.Deadline == Deadline &&
                otherModel.ReviewDeadline == ReviewDeadline);
        }
    }
}
