using System.Collections.Generic;
using System.Web.Mvc;
using Preparation.Domain.Abstract;
using Preparation.Domain.Entities;

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

        public ViewResult List()
        {
            var model = _preparationStore.GetAll();
            return View(model);
        }

        public ViewResult ViewResult(int id)
        {
            var model = _preparationStore.Get(id);
            return View(model);
        }

        public ViewResult Filter(string filter, string value)
        {
            var model = _preparationStore.FilterMedicaments(filter, value);
            return View("List",model);
        }

        public ViewResult Edit(int id)
        {
            var model = _preparationStore.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Medicament model)
        {
            _preparationStore.Save(model);
            TempData["message"] = string.Format("Препарат \"{0}\" был сохранен", model.Name);
            return RedirectToAction("List");
        }

        public ViewResult Add()
        {
            return View("Edit",new Medicament());
        }

        public ViewResult Delete(int id)
        {
            var model = _preparationStore.Get(id);
            _preparationStore.Delete(id);
            TempData["message"] = string.Format("Препарат \"{0}\" был удален",model.Name);
            var model1 = _preparationStore.GetAll();
            return View("List",model1);
        }
    }
}
