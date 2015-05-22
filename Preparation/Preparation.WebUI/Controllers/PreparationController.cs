using System.Web.Mvc;
using Preparation.Domain.Abstract;

namespace Preparation.WebUI.Controllers
{
    public class PreparationController : Controller
    {
        //
        // GET: /Preparation/

        private IPreparationRepository _repository;

        public PreparationController(IPreparationRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List()
        {
            return View(_repository.Medicaments);
        }
    }
}
