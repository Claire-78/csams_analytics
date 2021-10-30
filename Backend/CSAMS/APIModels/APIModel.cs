using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.APIModels
{
    public interface IAPIModel
    {
        public bool AssertEqual(IAPIModel other);
    }
}
