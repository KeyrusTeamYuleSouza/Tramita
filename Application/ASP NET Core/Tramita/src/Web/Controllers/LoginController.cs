using Microsoft.AspNet.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        #region IActions
        public IActionResult Index()
        {
            return View();
        }
       
        public  IActionResult Login()
        {
            return View();
        }
        #endregion

        #region Methods


        #endregion 
    }
}
