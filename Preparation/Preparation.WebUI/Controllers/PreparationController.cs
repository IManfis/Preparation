using System.Collections.Generic;
using System.Web.Http.Tracing;
using System.Web.Mvc;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;
using Preparation.WebUI.Models;
using AutoMapper;

namespace Preparation.WebUI.Controllers
{
    public class PreparationController : Controller
    {
        //
        // GET: /Preparation/

        private readonly IPreparationStore _preparationStore;
        private IPreparationRepository _preparationRepository;

        public PreparationController(IPreparationStore preparationStore, IPreparationRepository preparationRepository)
        {
            this._preparationStore = preparationStore;
            _preparationRepository = preparationRepository;
        }

        public ViewResult List()
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.GetAll());

            return View(users);
        }

        public ViewResult ViewResult(int id)
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.Get(id));
            return View(users);
        }

        public ViewResult Filter(string filter, string value)
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.FilterMedicaments(filter, value));

            return View("List",users);
        }

        public ViewResult Edit(int id)
        {
                Mapper.CreateMap<Medicament, MedicamentViewModel>();

                var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.Get(id));

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

            var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.Get(id));
            _preparationStore.Delete(id);
            TempData["message"] = string.Format("Препарат \"{0}\" был удален",users.Name);
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users1 = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.GetAll());

            return View("List",users1);
        }
    }
}
