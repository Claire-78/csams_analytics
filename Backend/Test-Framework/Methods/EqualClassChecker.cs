using CSAMS.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Framework.Methods
{
    public static class EqualClassChecker
    {
        public static bool ProjectCommentsEqual(ProjectComments[] expected, ProjectComments[] result)
        {
            if (expected.Length != result.Length)
                return false;

            foreach (var proj in expected)
            {
                if (result.All(res => proj.AreEqual(res) == false))
                    return false;
            }

            return true;
        }
    }
}
