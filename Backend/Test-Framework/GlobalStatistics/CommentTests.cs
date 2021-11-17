using CSAMS.APIModels;
using CSAMS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test_Framework.Methods;

namespace Test_Framework.GlobalStatistics
{
    /// <summary>
    /// Class for testing the CommentsController functions
    /// </summary>
    [TestClass]
    public class CommentTests
    {
        public readonly CommentModel[] ExpectedProjectResultOne =
            {
                new CommentModel {Target = 1, Reviewer = 2, Answer = "2", AnswerType = "radio", Comment = "Could have been a lot better"},
                new CommentModel {Target = 1, Reviewer = 2, Answer = "This is just some text", AnswerType = "textarea", Comment = "This review is text"},
                new CommentModel {Target = 3, Reviewer = 1, Answer = "6", AnswerType = "radio", Comment = "This is fantastic. Well done work"}
            };

        public readonly CommentModel[] ExpectedProjectResultTwo =
        {
                new CommentModel {Target = 2, Reviewer = 3, Answer = "1", AnswerType = "radio", Comment = "Worst job I have ever seen"},
                new CommentModel {Target = 2, Reviewer = 3, Answer = "on", AnswerType = "checkbox", Comment = "This is acceptable"}
            };

        public readonly CommentModel[] ExpectedReviewerResultOne =
        {
                new CommentModel {Target = 3, Reviewer = 1, Answer = "6", AnswerType = "radio", Comment = "This is fantastic. Well done work"}
        };

        public readonly CommentModel[] ExpectedReviewerResultTwo =
        {
                new CommentModel {Target = 1, Reviewer = 2, Answer = "2", AnswerType = "radio", Comment = "Could have been a lot better"},
                new CommentModel {Target = 1, Reviewer = 2, Answer = "This is just some text", AnswerType = "textarea", Comment = "This review is text"}
        };

        /// <summary>
        /// Tests the GetProjects Function for returning expected values
        /// </summary>
        [TestMethod]
        public void TestProjectCommentsOne()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 1);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultOne, result));
        }

        /// <summary>
        /// Tests the GetProjects Function for returning expected values
        /// </summary>
        [TestMethod]
        public void TestProjectCommentsTwo()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 2);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultTwo, result));
        }

        /// <summary>
        /// Tests the GetProjects Function for returning only the expected values
        /// </summary>
        [TestMethod]
        public void TestProjectCommentsFail()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 1);
            Assert.IsFalse(EqualClassChecker.APIModelEqual(ExpectedProjectResultTwo, result));
        }

        /// <summary>
        /// Tests the GetProjects Function for returning null when there is no data matching the input number
        /// </summary>
        [TestMethod]
        public void TestNoApplicableResult()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 1000);
            Assert.IsTrue(result is null);
        }

        /// <summary>
        /// Tests the GetReviewers Function for returning expected values
        /// </summary>
        [TestMethod]
        public void TestReviewCommentsOne()
        {
            var result = CommentController.GetReviewers(TestData.TestData.UserReviewTest, 1);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedReviewerResultOne, result));
        }

        /// <summary>
        /// Tests the GetReviewers Function for returning expected values
        /// </summary>
        [TestMethod]
        public void TestReviewCommentsTwo()
        {
            var result = CommentController.GetReviewers(TestData.TestData.UserReviewTest, 2);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedReviewerResultTwo, result));
        }

        /// <summary>
        /// Tests the GetReviewers Function for returning only the expected values
        /// </summary>
        [TestMethod]
        public void TestReviewCommentsFail()
        {
            var result = CommentController.GetReviewers(TestData.TestData.UserReviewTest, 1);
            Assert.IsFalse(EqualClassChecker.APIModelEqual(ExpectedReviewerResultTwo, result));
        }

        /// <summary>
        /// Tests the GetReviewers Function for returning null when there is no data matching the input number
        /// </summary>
        [TestMethod]
        public void TestReviewCommentsIsNull()
        {
            var result = CommentController.GetReviewers(TestData.TestData.UserReviewTest, 100000);
            Assert.IsTrue(result is null);
        }
    }
}
