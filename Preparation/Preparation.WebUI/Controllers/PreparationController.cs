using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Tracing;
using System.Web.Mvc;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;
using Preparation.WebUI.Models;
using AutoMapper;
using Preparation.WebUI.Filter;

namespace Preparation.WebUI.Controllers
{
    public class PreparationController : Controller
    {
        //
        // GET: /Preparation/

        private readonly IPreparationStore _preparationStore;
        private IPreparationRepository _repository;
        public PreparationController(IPreparationStore preparationStore, IPreparationRepository repository)
        {
            this._preparationStore = preparationStore;
            _repository = repository;
        }

        //[Compress]
        public ActionResult List()
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<IEnumerable<Medicament>, List<MedicamentViewModel>>(_preparationStore.GetAll());

            return View(users);
        }

        [Compress]
        public ActionResult ViewResult(int id)
        {
            Mapper.CreateMap<Medicament, MedicamentViewModel>();

            var users = Mapper.Map<Medicament, MedicamentViewModel>(_preparationStore.Get(id));
            return View(users);
        }

        [Compress]
        public ActionResult Filter(string filter, string value)
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
        public ActionResult Edit(int id)
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

        public ActionResult Add()
        {
            return View("Edit",new MedicamentViewModel());
        }

        public ActionResult Delete(int id)
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
