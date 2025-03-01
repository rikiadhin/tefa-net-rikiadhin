using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class ModalController : Controller
    {
        public IActionResult Add()
        {
            return PartialView("~/Component/Modal/modal-add.cshtml");
        }

        public IActionResult Edit()
        {
            return PartialView("~/Component/Modal/modal-edit.cshtml");
        }
    }
}
