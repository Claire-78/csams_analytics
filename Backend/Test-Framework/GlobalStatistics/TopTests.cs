using CSAMS.APIModels;
using CSAMS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Framework.Methods;

namespace Test_Framework.GlobalStatistics
{
    /// <summary>
    /// Class for testing functions in TopController
    /// </summary>
    [TestClass]
    public class TopTests
    {
        public readonly TopModel[] ExpectedProjectResultTopOne =
        {
            new TopModel{Grade = 4, AssingmentName = "Cloud 2021 - Assignment 2", AssingmentID = 6, ReviewerID = 33, type = "top"}
        };

        public readonly TopModel[] ExpectedProjectResulToptTwo =
        {
            new TopModel{Grade = 1.21F, AssingmentName = "PROG2006 Assignment 1 tic-tac-roll", AssingmentID = 5, ReviewerID = 97,type = "top"},
            new TopModel{Grade = 2.79F, AssingmentName = "Cloud 2021 - Assignment 1", AssingmentID = 1, ReviewerID = 19, type = "top"}
        };

        public readonly TopModel[] ExpectedProjectResultBottomOne =
        {
            new TopModel{Grade = 3.73F, AssingmentName = "Cloud 2021 - Assignment 1", AssingmentID = 1, ReviewerID = 27, type = "top"},
            new TopModel{Grade = 3, AssingmentName = "PROG2006 Assignment 1 tic-tac-roll", AssingmentID = 5, ReviewerID = 97, type = "top"}
        };

        public readonly TopModel[] ExpectedProjectResulBottomtTwo =
        {
            new TopModel{Grade = 3.62F, AssingmentName = "Cloud 2021 - Assignment 1", AssingmentID = 1, ReviewerID = 27, type = "top"}
        };

        [TestMethod]
        public void TestProjectTopsOne()
        {
            var TopOne = TopController.OuterTopProjects(1, "Top", true, TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultTopOne, TopOne));
        }

        [TestMethod]
        public void TestProjectTopsTwo()
        {
            var TopTwo = TopController.OuterTopProjects(2, "Top", false, TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResulToptTwo, TopTwo));
        }

        [TestMethod]
        public void TestProjectBottomOne()
        {
            var BottomOne = TopController.OuterTopProjects(2, "Bottom", true, TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultBottomOne, BottomOne));
        }

        [TestMethod]
        public void TestProjectBottomTwo()
        {
            var BottomTwo = TopController.OuterTopProjects(1, "Bottom", false, TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResulBottomtTwo, BottomTwo));
        }
    }
}
