using CSAMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Framework.TestData
{
    public class TestData
    {
        public UserReviews[] UserReviewTest =
        {
            new UserReviews {ID = 1, UserTarget = 1, UserReviewer = 2, Name = "assi1_01", Type = "radio", Answer = "2"},
            new UserReviews {ID = 2, UserTarget = 1, UserReviewer = 2, Name = "assi1_02", Type = "radio", Answer = "4"},
            new UserReviews {ID = 3, UserTarget = 1, UserReviewer = 2, Name = "assi1_03", Type = "textarea", Answer = "This is just some text"},
            new UserReviews {ID = 4, UserTarget = 1, UserReviewer = 2, Name = "assi1_04", Type = "paragraph", Answer = "this answer should not be considered"},
            new UserReviews {ID = 5, UserTarget = 1, UserReviewer = 2, Name = "assi1_05", Type = "radio", Answer = "3"},
            new UserReviews {ID = 6, UserTarget = 2, UserReviewer = 3, Name = "assi2_01", Type = "radio", Answer = "1"},
            new UserReviews {ID = 7, UserTarget = 2, UserReviewer = 3, Name = "assi2_02", Type = "checkbox", Answer = "on"},
            new UserReviews {ID = 8, UserTarget = 2, UserReviewer = 3, Name = "assi2_03", Type = "radio", Answer = "5"},
            new UserReviews {ID = 9, UserTarget = 3, UserReviewer = 1, Name = "assi1_01", Type = "radio", Answer = "2"},
            new UserReviews {ID = 10, UserTarget = 3, UserReviewer = 1, Name = "assi1_02", Type = "radio", Answer = "6"},
        };

    }
}
