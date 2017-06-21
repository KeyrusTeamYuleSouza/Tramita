using System.Web.Mvc;
using System.Linq;

using Web.Data;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        #region Context
        private TramitaEntities db = new TramitaEntities();
        #endregion

        #region Routes

        public ActionResult Home(string userToken)
        {
            //Convert ViewBag or ViewData To Token 
            var user = GetUserByToken(userToken);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public dynamic GetUserByToken(string token)
        {
            var user = (from u in db.IdentityCard
                        join up in db.UserProfile on u.ID equals up.IdentityCardID
                        where u.UserToken == token
                        select u).First();

            return user;
        }

        #endregion 
    }
}