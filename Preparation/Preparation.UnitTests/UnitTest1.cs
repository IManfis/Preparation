using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Preparation.Domain.Abstract;
using Preparation.Domain.Concrete;
using Preparation.Domain.Entities;

namespace Preparation.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Get_All()
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
            //action
            var store = new PreparationStore(mock.Object);
            var result = store.GetAll();
            //assert
            Assert.AreEqual(result.Count(), 5);
        }

        [TestMethod]
        public void Can_Get_By_Id()
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
            //action
            var store = new PreparationStore(mock.Object);
            var result = store.GetById(1);
            //assert
            Assert.IsTrue(result.Name == "Preparat1" && result.Producer == "Prod1");
        }

        [TestMethod]
        public void Can_Filter()
        {
            //arrange
            Mock<IPreparationRepository> mock = new Mock<IPreparationRepository>();
            mock.Setup(m => m.Medicaments).Returns(new List<Medicament>
            {
                new Medicament{ ID = 1, Name = "Preparat1", Producer = "Prod1"},
                new Medicament{ ID = 2, Name = "Preparat2", Producer = "Prod2"},
                new Medicament{ ID = 3, Name = "Preparat3", Producer = "Prod1"},
                new Medicament{ ID = 4, Name = "Preparat4", Producer = "Prod2"},
                new Medicament{ ID = 5, Name = "Preparat5", Producer = "Prod3"}
            });
            //action
            var store = new PreparationStore(mock.Object);
            var result = store.FilterMedicaments("Producer", "Prod1");
            //assert
            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Name == "Preparat1" && result[0].Producer == "Prod1");
            Assert.IsTrue(result[1].Name == "Preparat3" && result[1].Producer == "Prod1");
        }
    }
}
