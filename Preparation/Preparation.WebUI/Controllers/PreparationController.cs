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

        private IPreparationStore preparationStore;

        public PreparationController(IPreparationStore preparationStore)
        {
            this.preparationStore = preparationStore;
        }

        public ViewResult List()
        {
            var model = preparationStore.GetAll();

            return View(model);
        }

        public PartialViewResult Filter(string filter, string value)
        {
            return PartialView();
        }
    }
}
