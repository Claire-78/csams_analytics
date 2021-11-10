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
        public readonly TopModel[] ExpectedProjectResultTopOne =
            {
                new TopModel{Grade= 4,AssignmentName= "Cloud 2021 - Assignment 2",AssignmentID= 6,ReviewerID=33, type= "top"}
             //  new TopModel{Grade= 5,AssingmentName= "PROG2006 Assignment 1 tic-tac-roll",AssingmentID= 5,type= "top"},
             //new TopModel{Grade= 40,AssingmentName= "Cloud 2021 - Assignment 1",AssingmentID= 1,type= "top"}
            };

        public readonly TopModel[] ExpectedProjectResulToptTwo = 
        {
                   new TopModel{Grade=1.21F,AssignmentName= "PROG2006 Assignment 1 tic-tac-roll",AssignmentID= 5,ReviewerID=97,type= "top"},
               new TopModel{Grade= 2.79F,AssignmentName= "Cloud 2021 - Assignment 1",AssignmentID= 1,ReviewerID=19,type= "top"}
            // new TopModel{Grade= 1,AssingmentName= "Cloud 2021 - Assignment 2",AssingmentID= 6,type= "Bottom"}
            
        
        };

        public readonly TopModel[] ExpectedProjectResultBottomOne =
           {
                   new TopModel{Grade= 3.73F,AssignmentName= "Cloud 2021 - Assignment 1",AssignmentID= 1,ReviewerID=27, type= "top"},
                       new TopModel{Grade= 3,AssignmentName= "PROG2006 Assignment 1 tic-tac-roll",AssignmentID= 5,ReviewerID=97, type= "top"}
            };

        public readonly TopModel[] ExpectedProjectResulBottomtTwo =
        {
                   new TopModel{Grade= 3.62F,AssignmentName= "Cloud 2021 - Assignment 1",AssignmentID= 1,ReviewerID=27, type= "top"}


        };




        [TestMethod]
        public void TestProjectTopsOne()
        {
           
            var TopOne = TopController.OuterTopProjects(1, "Top", true,TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            for (int i = 0; i < TopOne.Length; i++)
            {
                Console.WriteLine(TopOne.Length + ":length ");
                Console.WriteLine(TopOne[i].AssignmentName + " " + i + " :A.Name  ");
                Console.WriteLine(TopOne[i].AssignmentID + " " + i + " :A.ID  ");
                Console.WriteLine(TopOne[i].Grade + " " + i + " :Grade  ");
                Console.WriteLine(TopOne[i].ReviewerID + " " + i + " :R.ID  ");
                Console.WriteLine(TopOne[i].type + " " + i + " :type  ");
            }
              Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultTopOne, TopOne));

        }

        [TestMethod]
        public void TestProjectTopsTwo()
        {var TopTwo = TopController.OuterTopProjects(2, "Top", false, TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            for (int i = 0; i < TopTwo.Length; i++)
            {
                Console.WriteLine(TopTwo.Length + ":length ");
                Console.WriteLine(TopTwo[i].AssignmentName + " " + i + " :A.Name  ");
                Console.WriteLine(TopTwo[i].AssignmentID + " " + i + " :A.ID  ");
                Console.WriteLine(TopTwo[i].Grade + " " + i + " :Grade  ");
                Console.WriteLine(TopTwo[i].ReviewerID + " " + i + " :R.ID  ");
                Console.WriteLine(TopTwo[i].type + " "+i+" :type  ");
            }
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResulToptTwo, TopTwo));
        }

        [TestMethod]
        public void TestProjectBottomOne()
        {
            var BottomOne = TopController.OuterTopProjects(2, "Bottom", true, TestData.TestData.TopTestsOne, TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            for (int i = 0; i < BottomOne.Length; i++)
            {
                Console.WriteLine(BottomOne.Length + ":length ");
                Console.WriteLine(BottomOne[i].AssignmentName + " " + i + " :A.Name  ");
                Console.WriteLine(BottomOne[i].AssignmentID + " " + i + " :A.ID  ");
                Console.WriteLine(BottomOne[i].Grade + " " + i + " :Grade  ");
                Console.WriteLine(BottomOne[i].ReviewerID + " " + i + " :R.ID  ");
                Console.WriteLine(BottomOne[i].type + " " + i + " :type  ");
            }
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResultBottomOne, BottomOne));
        }

        [TestMethod]
        public void TestProjectBottomTwo()
        {
            var BottomTwo = TopController.OuterTopProjects(1, "Bottom", false, TestData.TestData.TopTestsOne,TestData.TestData.TopTestsFields, TestData.TestData.TopTestsOne);
            for (int i = 0; i < BottomTwo.Length; i++)
            {
                Console.WriteLine(BottomTwo.Length + ":length ");
                Console.WriteLine(BottomTwo[i].AssignmentName + " " + i + " :A.Name  ");
                Console.WriteLine(BottomTwo[i].AssignmentID + " " + i + " :A.ID  ");
                Console.WriteLine(BottomTwo[i].Grade + " " + i + " :Grade  ");
                Console.WriteLine(BottomTwo[i].ReviewerID + " " + i + " :R.ID  ");
                Console.WriteLine(BottomTwo[i].type + " " + i + " :type  ");
            }
            Assert.IsTrue(EqualClassChecker.APIModelEqual(ExpectedProjectResulBottomtTwo, BottomTwo));
        }


        /*
          for(int i=0;i< TestData.TestData.TopTestsOne.Length; i++)
          {
              Console.WriteLine(t[i].Answer + " " + i+": answer TESTDATA ");
              Console.WriteLine(t[i].AssignmentID + " " + i + ": AssignmentID TESTDATA ");
              Console.WriteLine(t[i].ReviewID + " " + i + ": ReviewID TESTDATA ");
              Console.WriteLine(t[i].UserReviewer + " " + i + ": UserReviewer  TESTDATA ");
              Console.WriteLine(t[i].Name+ " " + i + ": Name TESTDATA ");


          }
        */
        /*
                public TopModel[] TestProjects(int N, string Type, Boolean IsProject, CSAMS.Models.UserReviews[] testdata,CSAMS.Models.Fields[] testfields)
                {
                    var t=testdata

                          .AsEnumerable()
                          // .GroupBy(r => r.AssignmentID)
                          // .Select(r => TopProjects(r.ToArray(), fields, IsProject))
                          .Where(p => p != null)

                          .ToArray();
                    Console.WriteLine($"N is {N} and Type is {Type}");
                    Console.WriteLine(testdata.Length + " testdata_length ");

                    //  int N = 1;
                    //  string Type = "Top";
                    //  Boolean IsProject = true;
                    if (IsProject == true)
                    {
                        if (Type == "Top")
                        {
                            return t
                                   .GroupBy(r => r.AssignmentID)
                                  .Select(r => TopController.TopProjects(r.ToArray(), testfields, IsProject, 0))
                               .Where(r => r != null)

                                 .OrderByDescending(p => p.Grade)
                                 .Take(N)
                                 .ToArray();
                            ;
                        }
                        else if (Type == "Bottom")
                        {
                            Console.WriteLine(t.Length);
                            var x = t
                                .GroupBy(r => r.AssignmentID)
                               .Select(r => TopController.TopProjects(r.ToArray(), testfields, IsProject, 0))
                               .Where(r => r != null)
                               .OrderBy(p => p.Grade)
                               .Take(N)

                               .ToArray();
                            return x;
                        }
                        else
                        {
                            return t
                                  .GroupBy(r => r.AssignmentID)
                                  .Select(r => TopController.TopProjects(r.ToArray(), testfields, IsProject, 0))
                               .Where(r => r != null)
                                 .Take(2)
                                 .ToArray();
                            ;
                        }
                    }
                    else////////////////////////////
                    {
                        var average = TopController.GetMiddle(testdata, testfields);

                        if (Type == "Top")
                        {
                            return t

                                   .GroupBy(r => r.ReviewID)
                                  .Select(r => TopController.TopProjects(r.ToArray(), testfields, IsProject, average))

                               .Where(r => r != null)

                                 .OrderByDescending(p => p.Grade)

                                 .Take(N)

                                 .ToArray();
                            ;
                        }
                        else if (Type == "Bottom")
                        {
                            return t
                                .GroupBy(r => r.ReviewID)
                               .Select(r => TopController.TopProjects(r.ToArray(), testfields, IsProject, average))
                               .Where(r => r != null)
                               .OrderBy(p => p.Grade)
                               .Take(N)
                               .ToArray();

                        }
                        else
                        {
                            return t
                                  .GroupBy(r => r.ReviewID)
                                  .Select(r => TopController.TopProjects(r.ToArray(), testfields, IsProject, average))
                               .Where(r => r != null)
                                 .Take(2)
                                 .ToArray();
                            ;
                        }
                    }


                }

                    */
    }
}
    