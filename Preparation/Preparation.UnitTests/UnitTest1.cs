using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;
using Preparation.WebUI.Controllers;
using Preparation.WebUI.Models;

namespace Preparation.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Get_All()
        {
            //arrange
            Mock<IPreparationStore> mock = new Mock<IPreparationStore>();
            mock.Setup(m => m.GetAll()).Returns(new List<Medicament>()
            {
                new Medicament{ ID = 1, Name = "Preparat1", Producer = "Prod1"},
                new Medicament{ ID = 2, Name = "Preparat2", Producer = "Prod2"},
                new Medicament{ ID = 3, Name = "Preparat3", Producer = "Prod1"},
                new Medicament{ ID = 4, Name = "Preparat4", Producer = "Prod2"},
                new Medicament{ ID = 5, Name = "Preparat5", Producer = "Prod3"}
            });
            PreparationController controller = new PreparationController(mock.Object,null);
            //action
            List<MedicamentViewModel> result = (List<MedicamentViewModel>)(controller.List().Model);
            //assert
            Assert.AreEqual(result.Count(), 5);
        }

        [TestMethod]
        public void Can_Filter()
        {
            //arrange
            Mock<IPreparationRepository> mock = new Mock<IPreparationRepository>();
            mock.Setup(m => m.Medicaments).Returns(new List<Medicament>()
            {
                new Medicament{ ID = 1, Name = "Preparat1", Producer = "Prod1"},
                new Medicament{ ID = 2, Name = "Preparat2", Producer = "Prod2"},
                new Medicament{ ID = 3, Name = "Preparat3", Producer = "Prod1"},
                new Medicament{ ID = 4, Name = "Preparat4", Producer = "Prod2"},
                new Medicament{ ID = 5, Name = "Preparat5", Producer = "Prod3"}
            });
            PreparationController controller = new PreparationController(null,mock.Object);
            //action
            List<MedicamentViewModel> result = (List<MedicamentViewModel>) (controller.Filter("Producer", "Prod1").Model);
            //assert
            Assert.AreEqual(result.Count(),2);
            Assert.IsTrue(result[0].Name == "Preparat1" && result[0].Producer == "Prod1");
            Assert.IsTrue(result[0].Name == "Preparat3" && result[0].Producer == "Prod1");
        }
    }
}
