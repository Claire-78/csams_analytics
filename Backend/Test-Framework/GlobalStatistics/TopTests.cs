using CSAMS.APIModels;
using CSAMS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test_Framework.Methods;



namespace Test_Framework.GlobalStatistics
{
    [TestClass]
    public class TopTests
    {
        public readonly TopModel[] ExpectedProjectResultOne =
            {
                new TopModel{Grade= 40,AssingmentName= "Cloud 2021 - Assignment 2",AssingmentID= 6,type= "Top"},
               new TopModel{Grade= 5,AssingmentName= "PROG2006 Assignment 1 tic-tac-roll",AssingmentID= 5,type= "Top"},
             new TopModel{Grade= 40,AssingmentName= "Cloud 2021 - Assignment 1",AssingmentID= 1,type= "Top"}
            };

        public readonly TopModel[] ExpectedProjectResultTwo = 
        {
                    new TopModel{Grade= 1,AssingmentName= "Cloud 2021 - Assignment 1",AssingmentID= 1,type= "Bottom"},
               new TopModel{Grade= 1,AssingmentName= "PROG2006 Assignment 1 tic-tac-roll",AssingmentID= 5,type= "Bottom"},
             new TopModel{Grade= 1,AssingmentName= "Cloud 2021 - Assignment 2",AssingmentID= 6,type= "Bottom"}
            
        
        };



        
        [TestMethod]
        public void TestProjectTopsOne()
        {
            var t = TestData.TestData.TopTests.GroupBy(r => r.AssignmentID).Select(r => TopController.TopProjects(r.ToArray(), TestData.TestData.TopTestsFields)).ToArray();

            // var result = TopController.TopProjects(t[i], TestData.TestData.TopTestsFields);

            
               
           // for(int i=0;i<t.Length;i++)
                Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultOne, t));
            
        }

        [TestMethod]
        public void TestProjectTopsTwo()
        {
            var result = TopController.BottomProjects(TestData.TestData.TopTests, TestData.TestData.TopTestsFields);
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultTwo, result));
        }

            
    }
}
    