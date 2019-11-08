using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DITestingQuiz;
using Moq;

namespace MoqQuiz
{
    [TestClass]
    public class UnitTest1
    {

        EmployeeBusinessLogic ebl;
        Mock<IEmployeeDataAccess> fakeDataAccess;





        [TestInitialize]
        public void SetUp()
        {
            fakeDataAccess = new Mock<IEmployeeDataAccess>();
            ebl = new EmployeeBusinessLogic(fakeDataAccess.Object);

            fakeDataAccess.Setup(m => m.GetEmployeeSalary(It.IsAny<int>())).Equals(169069);
            
            
        }

        [TestMethod]
        public void PrintEmployeetInfo_Test_WithMoq()
        {
            //Arrange (Handled by Initialize)  

            SetUp();
            //Act
            var printResult = ebl.GetEmployeeSalary(1);
            //Assert
            Assert.AreEqual(printResult, 169069);

        }



    }
}
