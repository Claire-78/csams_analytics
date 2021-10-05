using CSAMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Framework.TestData
{
    public class TestData
    {
        public static readonly Forms[] FormTest =
        {
            new Forms {ID = 1, Prefix = "assi1_submission", Name = "Assignment 1 Submission"},
            new Forms {ID = 2, Prefix = "assi1_review", Name = "Assignment 1 Review"},
            new Forms {ID = 3, Prefix = "assi2_submission", Name = "Assignment 2 Submission"},
            new Forms {ID = 4, Prefix = "assi2_review", Name = "Assignment 2 Review"},
            new Forms {ID = 5, Prefix = "assi3_submission", Name = "Assignment 3 Submission"},
            new Forms {ID = 6, Prefix = "assi3_review", Name = "Assignment 3 Review"},
            new Forms {ID = 7, Prefix = "assi4_submission", Name = "Assignment 4 Submission"},
            new Forms {ID = 8, Prefix = "assi4_review", Name = "Assignment 4 Review"},
            new Forms {ID = 9, Prefix = "assi5_submission", Name = "Assignment 5 Submission"},
            new Forms {ID = 10, Prefix = "assi5_review", Name = "Assignment 5 Review"},
            new Forms {ID = 11, Prefix = "assi6_submission", Name = "Assignment 6 Submission"},
            new Forms {ID = 12, Prefix = "assi6_review", Name = "Assignment 6 Review"}
        };

        public static readonly Submissions[] SubmissionsTest =
        {
            new Submissions {ID = 1, FormID = 1},
            new Submissions {ID = 2, FormID = 3},
            new Submissions {ID = 3, FormID = 5},
            new Submissions {ID = 4, FormID = 7},
            new Submissions {ID = 5, FormID = 9},
            new Submissions {ID = 6, FormID = 11}
        };

        public static readonly Reviews[] ReviewsTest =
        {
            new Reviews {ID = 1, FormID = 2},
            new Reviews {ID = 2, FormID = 4},
            new Reviews {ID = 3, FormID = 6},
            new Reviews {ID = 4, FormID = 8},
            new Reviews {ID = 5, FormID = 10},
            new Reviews {ID = 6, FormID = 12},
        };

        public static readonly UserReviews[] UserReviewTest =
        {
            new UserReviews {ID = 1, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, ReviewID = 1, Comment = "Could have been a lot better"},
            new UserReviews {ID = 2, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_02", Type = "radio", Answer = "4", AssignmentID = 1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 3, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_03", Type = "textarea", Answer = "This is just some text", AssignmentID = 1, ReviewID = 1, Comment = "This review is text"},
            new UserReviews {ID = 4, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_04", Type = "paragraph", Answer = "this answer should not be considered", AssignmentID = 1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 5, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_05", Type = "radio", Answer = "3", AssignmentID = 1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 6, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_01", Type = "radio", Answer = "1", AssignmentID = 2, ReviewID = 2, Comment = "Worst job I have ever seen"},
            new UserReviews {ID = 7, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_02", Type = "checkbox", Answer = "on", AssignmentID = 2, ReviewID = 2, Comment = "This is acceptable"},
            new UserReviews {ID = 8, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_03", Type = "radio", Answer = "5", AssignmentID = 2, ReviewID = 2, Comment = null},
            new UserReviews {ID = 9, UserTarget = 3, UserReviewer = 1, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 10, UserTarget = 3, UserReviewer = 1, Name = "assi1_review_02", Type = "radio", Answer = "6", AssignmentID = 1, ReviewID = 1, Comment = "This is fantastic. Well done work"},
        };

        public static readonly Roles[] RolesTest =
        {
            new Roles {ID = 1, Key = "teacher", Name = "Teacher"},
            new Roles {ID = 2, Key = "ta", Name = "Teaching Assistant"},
            new Roles {ID = 3, Key = "student", Name = "Student"},
        };

        public static readonly Users[] UsersTest =
        {
            new Users { ID = 1, Role = 3},
            new Users { ID = 2, Role = 3},
            new Users { ID = 3, Role = 3},
            new Users { ID = 4, Role = 1},
            new Users { ID = 5, Role = 3},
            new Users { ID = 6, Role = 3},
            new Users { ID = 7, Role = 3},
            new Users { ID = 8, Role = 3},
            new Users { ID = 9, Role = 2},
            new Users { ID = 10, Role = 2}
        };

    }
}
