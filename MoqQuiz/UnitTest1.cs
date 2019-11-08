using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DITestingQuiz;
using Moq;

namespace MoqQuiz
{
    [TestClass]
    public class UnitTest1
    {
        
       
        public Mock<IEmployeeDataAccess> fakeDataAccess;
        public EmployeeBusinessLogic ebl;
            
        

        [TestInitialize]
        public void DoWorkTest()
        {

            
            ebl = new EmployeeBusinessLogic(fakeDataAccess.Object);
        }

        [TestMethod]
        public void PrintEmployeetInfo_Test_WithMoq()
        {
            //Arrange (Handled by Initialize)                
            //Act
            var printResult = ebl.GetEmployeeSalary(1);
            //Assert
            Assert.AreEqual(printResult, 169069);

        }



    }
}
