using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;

using Web.Util;
using Web.Data;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {

        }

        #region Context
        private TramitaEntities db = new TramitaEntities();
        #endregion

        #region Routes

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Home", "Home");
            }

            return View();
        }

        public ActionResult AuthenticateUser(string username, string password)
        {
            // Encrypt Password With User CPF
            password = Security.Encrypt(password, username);
             
            // Generate Security Token
            var token = Security.GenerateToken(password);

            // Get User By CPF / Encrypt Password
            var user = (from p in db.UserProfile
                        join ic in db.IdentityCard on p.IdentityCardID equals ic.ID
                        where ic.CPF == username && ic.PasswordHash == password
                        select ic).First();
            
            // Get Identity Card By ID
            var identityCard = (from i in db.IdentityCard
                                where i.ID == user.ID
                                select i).First();

            // New Token 
            identityCard.UserToken = token;
            identityCard.ModifiedDate = DateTime.Now;

            //Update Database With Current User Token 
            db.SaveChanges();

            if (user != null)
            {
                // Authentication Ticket
                var authTicket = new FormsAuthenticationTicket(1,
                                                               token,
                                                               DateTime.Now,
                                                               DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                                                               true,
                                                               password,
                                                               "/");
                // Creating Cookie
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket)) { HttpOnly = true };

                return RedirectToAction("Home", "Home", new { userToken = token});
            }

            else
            {

                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Login", "Login");
        }

        #endregion 

        #region Methods

        public dynamic GetUserByCPF(string key)
        {
            var tokenUser = (from ic in db.IdentityCard
                             join p in db.UserProfile on ic.ID equals p.IdentityCardID
                             where ic.CPF == key

                             select new
                             {
                                 cpf = ic.CPF

                             }).Any();

            return Json(tokenUser, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetUserRegisterByCPF(string key)
        {
            var user = (from ic in db.IdentityCard
                        join p in db.UserProfile on ic.ID equals p.IdentityCardID
                        where ic.CPF == key && ic.PasswordHash == "" && ic.Active == false

                        select new
                        {
                            cpf = ic.CPF,
                            password = ic.PasswordHash

                        }).Any();

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetEmailByKey(string key)
        {
            var email = (from ic in db.IdentityCard
                         join p in db.UserProfile on ic.ID equals p.IdentityCardID
                         where p.Email == key

                         select new
                         {
                             email = p.Email

                         }).Any();

            return Json(email, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetPasswordByKey(string username, string key)
        {
            bool token = false;
            key = Security.Encrypt(key, username);

            var accessToken = (from ic in db.IdentityCard
                               join p in db.UserProfile on ic.ID equals p.IdentityCardID
                               where ic.CPF == username && ic.PasswordHash == key

                               select new
                               {
                                   token = ic.PasswordHash

                               }).ToList().FirstOrDefault();

            if (accessToken != null)
            {
                token = true;
            }

            return Json(token, JsonRequestBehavior.AllowGet);
        }

        public dynamic RegisterUser(string username, string password)
        {
            string passwordEncrypt = Security.Encrypt(password, username);

            var user = (from ic in db.IdentityCard
                        join p in db.UserProfile on ic.ID equals p.IdentityCardID
                        where ic.CPF == username && ic.PasswordHash == "" || ic.CPF == username && ic.PasswordHash == null

                        select ic).First();

            //Populate User Object 
            user.PasswordHash = passwordEncrypt;
            user.Active = true;

            //Save Changes
            db.SaveChanges();

            return RedirectToAction("AuthenticateUser", "Login", new { username = username, password = password });
        }

        #endregion 
    }
}