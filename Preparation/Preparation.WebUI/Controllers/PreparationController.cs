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

        public ViewResult Filter(string filter, string value)
        {
            var model = _preparationStore.FilterMedicaments(filter, value);
            return View("List",model);
        }
    }
}
