using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;
using Preparation.WebUI.Filter;
using Preparation.WebUI.Models;

namespace Preparation.WebUI.Controllers
{
    public class PreparationController : Controller
    {
        //
        // GET: /Preparation/

        private readonly IPreparationStore _preparationStore;
        public PreparationController(IPreparationStore preparationStore)
        {
            this._preparationStore = preparationStore;
        }

        [Compress]
        public ViewResult List()
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.GetAll());

            return View(users);
        }

        [Compress]
        public ViewResult ViewResult(int id)
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.GetById(id));
            return View(users);
        }

        [Compress]
        public ViewResult Filter(string filter, string value)
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.FilterMedicaments(filter, value));

            if (!users.Any() )
            {
                TempData["message"] = string.Format("Ничего не найдено");
            }
            return View("List",users);
        }

        [Compress]
        public ViewResult Edit(int id)
        {
                Mapper.CreateMap<Medicament, MedicamentViewModel>();

                var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.GetById(id));

                return View(users);
        }

        [HttpPost]
        public ActionResult Edit(MedicamentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<MedicamentViewModel, Medicament>();

                var users = Mapper.Map<MedicamentViewModel, Medicament>(model);
                _preparationStore.Save(users);

                TempData["message"] = string.Format("Препарат \"{0}\" был сохранен", model.Name);
                return RedirectToAction("List");
            }
            TempData["message"] = string.Format("Беда");
            return RedirectToAction("List");
        }

        public ViewResult Add()
        {
            return View("Edit",new MedicamentViewModel());
        }

        public ViewResult Delete(int id)
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.GetById(id));
            _preparationStore.Delete(id);
            TempData["message"] = string.Format("Препарат \"{0}\" был удален",users.Name);
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users1 = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.GetAll());

            return View("List",users1);
        }
    }
}
