using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.APIModels
{
    public class APIModel
    {
        public virtual bool AssertEqual(APIModel other) { return false; }
    }
}
