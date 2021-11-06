using System.Runtime.InteropServices;
using System;
namespace CSAMS.DTOS
{
    public class User
    {
        public string id { get; set; }
        public string role { get; set; }

    }


    public class UserFilter
    {
        public string id { get; set; }
       

    }

    public class Filter
    {
        public string assignment { get; set; }
        public string reviewerID { get; set; }
        public string targetID { get; set; }
        public string errorMsg { get; set; }
    }
}

