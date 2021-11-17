
using CSAMS.Controllers;
using CSAMS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Framework.Methods;

namespace Test_Framework.GlobalStatistics
{
    /// <summary>
    /// Class for testing functions in the StatisticsController
    /// </summary>
    [TestClass]
    public class FiltersTests
    {
        public static readonly Assignments Assignment1 =
            new Assignments { ID = 1, Name = "assi1" };
        public static readonly Assignments Assignment2 =
            new Assignments { ID = 2, Name = "assi2" };


        public readonly UserReviews[] ExpectedResult1 = {
            new UserReviews {ID = 1, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "Could have been a lot better"},
            new UserReviews {ID = 2, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_02", Type = "radio", Answer = "4", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 3, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_03", Type = "textarea", Answer = "This is just some text", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "This review is text"},
            new UserReviews {ID = 4, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_04", Type = "paragraph", Answer = "this answer should not be considered", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 5, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_05", Type = "radio", Answer = "3", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 9, UserTarget = 3, UserReviewer = 1, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 10, UserTarget = 3, UserReviewer = 1, Name = "assi1_review_02", Type = "radio", Answer = "6", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "This is fantastic. Well done work"}
        };

        public readonly UserReviews[] ExpectedResult2 = {
            new UserReviews {ID = 6, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_01", Type = "radio", Answer = "1", AssignmentID = 2, Assignment = Assignment2, ReviewID = 2, Comment = "Worst job I have ever seen"},
            new UserReviews {ID = 7, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_02", Type = "checkbox", Answer = "on", AssignmentID = 2, Assignment = Assignment2, ReviewID = 2, Comment = "This is acceptable"},
            new UserReviews {ID = 8, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_03", Type = "radio", Answer = "5", AssignmentID = 2, Assignment = Assignment2, ReviewID = 2, Comment = null}
        };

        public readonly UserReviews[] ExpectedResult3 = {
            new UserReviews {ID = 1, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "Could have been a lot better"},
            new UserReviews {ID = 2, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_02", Type = "radio", Answer = "4", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 3, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_03", Type = "textarea", Answer = "This is just some text", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "This review is text"},
            new UserReviews {ID = 4, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_04", Type = "paragraph", Answer = "this answer should not be considered", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 5, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_05", Type = "radio", Answer = "3", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null}
        };

        public readonly UserReviews[] ExpectedResult4 = {
            new UserReviews {ID = 6, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_01", Type = "radio", Answer = "1", AssignmentID = 2, Assignment = Assignment2, ReviewID = 2, Comment = "Worst job I have ever seen"},
            new UserReviews {ID = 7, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_02", Type = "checkbox", Answer = "on", AssignmentID = 2, Assignment = Assignment2, ReviewID = 2, Comment = "This is acceptable"},
            new UserReviews {ID = 8, UserTarget = 2, UserReviewer = 3, Name = "assi2_review_03", Type = "radio", Answer = "5", AssignmentID = 2, Assignment = Assignment2, ReviewID = 2, Comment = null }
        };

        public readonly UserReviews[] ExpectedResult5 = {
            new UserReviews {ID = 1, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "Could have been a lot better"},
            new UserReviews {ID = 2, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_02", Type = "radio", Answer = "4", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 3, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_03", Type = "textarea", Answer = "This is just some text", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "This review is text"},
            new UserReviews {ID = 4, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_04", Type = "paragraph", Answer = "this answer should not be considered", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 5, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_05", Type = "radio", Answer = "3", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null}
        };

        public readonly UserReviews[] ExpectedResult6 = {
            new UserReviews {ID = 9, UserTarget = 3, UserReviewer = 1, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 10, UserTarget = 3, UserReviewer = 1, Name = "assi1_review_02", Type = "radio", Answer = "6", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "This is fantastic. Well done work"},
        };

        public readonly UserReviews[] ExpectedResult7 = {
            new UserReviews {ID = 1, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_01", Type = "radio", Answer = "2", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "Could have been a lot better"},
            new UserReviews {ID = 2, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_02", Type = "radio", Answer = "4", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 3, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_03", Type = "textarea", Answer = "This is just some text", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = "This review is text"},
            new UserReviews {ID = 4, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_04", Type = "paragraph", Answer = "this answer should not be considered", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null},
            new UserReviews {ID = 5, UserTarget = 1, UserReviewer = 2, Name = "assi1_review_05", Type = "radio", Answer = "3", AssignmentID = 1, Assignment = Assignment1, ReviewID = 1, Comment = null}
        };

        [TestMethod]
        public void TestProjectCommentsOne()//Non applicable
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "afkiikjuhgbfvdc");
            Assert.IsTrue(result is null);
        }

        [TestMethod]
        public void TestProjectCommentsTwo()//Assignment 1
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "assi1");
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult1, result));
        }

        [TestMethod]
        public void TestProjectCommentsThree()//Assignment2
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "assi2");
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult2, result));
        }

        [TestMethod]
        public void TestProjectCommentsFour()//Reviewer2
        {
            UserReviews[] result = StatisticsController.ApplyFilterReviewerID(TestData.TestData.UserReviewTest, 2);
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult3, result));
        }

        [TestMethod]
        public void TestProjectCommentsFive()//Non applicable
        {
            UserReviews[] result = StatisticsController.ApplyFilterReviewerID(TestData.TestData.UserReviewTest, 10);
            Assert.IsTrue(result is null);
        }

        [TestMethod]
        public void TestProjectCommentsSix()//Target2
        {
            UserReviews[] result = StatisticsController.ApplyFilterTargetID(TestData.TestData.UserReviewTest, 2);
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult4, result));
        }

        [TestMethod]
        public void TestProjectCommentsSeven()//Non applicable
        {
            UserReviews[] result = StatisticsController.ApplyFilterTargetID(TestData.TestData.UserReviewTest, 5);
            Assert.IsTrue(result is null);
        }

        [TestMethod]
        public void TestProjectCommentsEight()//Assignment 1 && Reviewer2
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "assi1");
            result = StatisticsController.ApplyFilterReviewerID(result, 2);
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult5, result));
        }

        [TestMethod]
        public void TestProjectCommentsNine()//Assignment 1 && Reviewer3
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "assi1");
            result = StatisticsController.ApplyFilterReviewerID(result, 3);
            Assert.IsTrue(result is null);
        }

        [TestMethod]
        public void TestProjectCommentsTen()//Assignment1 && Target 3
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "assi1");
            result = StatisticsController.ApplyFilterTargetID(result, 3);
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult6, result));
        }

        [TestMethod]
        public void TestProjectCommentsEleven()//Assignment1 && Target 2
        {
            UserReviews[] result = StatisticsController.ApplyFilterAssignment(TestData.TestData.UserReviewTest, "assi1");
            result = StatisticsController.ApplyFilterTargetID(result, 2);
            Assert.IsTrue(result is null);
        }

        [TestMethod]
        public void TestProjectCommentsTwelve()//Target1 && Reviewer2
        {
            UserReviews[] result = StatisticsController.ApplyFilterReviewerID(TestData.TestData.UserReviewTest, 2);
            result = StatisticsController.ApplyFilterTargetID(result, 1);
            Assert.IsTrue(EqualClassChecker.UserReviewsEqual(ExpectedResult7, result));
        }

        [TestMethod]
        public void TestProjectCommentsThirteen()//Target1 && Reviewer1
        {
            UserReviews[] result = StatisticsController.ApplyFilterReviewerID(TestData.TestData.UserReviewTest, 1);
            result = StatisticsController.ApplyFilterTargetID(result, 1);
            Assert.IsTrue(result is null);
        }

    }
}
