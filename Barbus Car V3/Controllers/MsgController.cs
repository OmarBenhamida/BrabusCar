using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Barbus_Car_V3.Controllers
{
    public class MsgController : Controller
    {
        // GET: Msg
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Valid());
        }
        [HttpPost]
        public ActionResult Index(Valid v)
        
            {
            var etat = "";
            var corps = "Brabus Car vous avez une nouvelle demande de message de la part de Mr ou Mme" +
                " " + v.Nom +  " \n ses cordonnes : tel :  " +
                "" + v.Tel + "\n  email : " + v.Email + " son message est le suivant : "+v.Msge+"";
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("brabuscar683@gmail.com", "7598426130"),
                    EnableSsl = true
                };
                client.Send("brabuscar683@gmail.com", "brabusmaroc@gmail.com", "Contact us", corps);
                etat = "Succee d'Envoie";
            }
            catch (Exception)
            {
                etat = "Echec d'Envoie";
            }


            return Json(etat, JsonRequestBehavior.AllowGet);
        }
        public class Valid
        {


            public string Nom { get; set; }
            public string Email { get; set; }
            public string Tel { get; set; }
            public string Msge { get; set; }
           

        }
    }
}