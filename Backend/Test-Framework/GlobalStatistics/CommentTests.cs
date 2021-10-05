using CSAMS.APIModels;
using CSAMS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test_Framework.Methods;

namespace Test_Framework.GlobalStatistics
{
    [TestClass]
    public class CommentTests
    {
        public readonly ProjectComments[] ExpectedResultOne =
            {
                new ProjectComments {Target = 1, Reviewer = 2, Answer = "2", AnswerType = "radio", Comment = "Could have been a lot better"},
                new ProjectComments {Target = 1, Reviewer = 2, Answer = "This is just some text", AnswerType = "textarea", Comment = "This review is text"},
                new ProjectComments {Target = 3, Reviewer = 1, Answer = "6", AnswerType = "radio", Comment = "This is fantastic. Well done work"}
            };

        public readonly ProjectComments[] ExpectedResultTwo =
        {
                new ProjectComments {Target = 2, Reviewer = 3, Answer = "1", AnswerType = "radio", Comment = "Worst job I have ever seen"},
                new ProjectComments {Target = 2, Reviewer = 3, Answer = "on", AnswerType = "checkbox", Comment = "This is acceptable"}
            };

        [TestMethod]
        public void TestProjectCommentsOne()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 1);
            Assert.IsTrue(EqualClassChecker.ProjectCommentsEqual(ExpectedResultOne, result));
        }

        [TestMethod]
        public void TestProjectCommentsTwo()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 2);
            Assert.IsTrue(EqualClassChecker.ProjectCommentsEqual(ExpectedResultTwo, result));
        }

        [TestMethod]
        public void TestNoApplicableResult()
        {
            var result = CommentController.GetProjects(TestData.TestData.UserReviewTest, 1000);
            Assert.IsTrue(result is null);
        }
    }
}
