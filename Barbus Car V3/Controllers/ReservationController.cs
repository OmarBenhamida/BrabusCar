using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace BarbusCar.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Valid());
        }
        [HttpPost]
        public ActionResult Index(Valid v)
        {
            var etat = "";
            var corps = "Brabus Car vous avez une nouvelle demande de reservation de la part de Mr ou Mme" +
                " "+v.Nom+" " +
                "qui souhaite reserver le véhicule suivant : \n "+v.Vhc+"" +
                " du : "+v.Datedep+ " à : "+v.Hdepart+"H"+v.Mindep+ "Min \n jusqu'a : " +
                ""+v.Dateret+" à : "+v.Hretour+"H "+v.Minret+
                "Min \n  avec les option suivantes : "
                + v.GPS+","+v.Siegeb+","+v.Deuxconducteur+"," +
                ""+v.Barretoit+ " \n ses cordonnes : tel :  " +
                ""+v.Tel+ "\n  email : " + v.Email+"";
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("brabuscar683@gmail.com", "7598426130"),
                    EnableSsl = true
                };
                client.Send("brabuscar683@gmail.com", "brabuscarmaroc@gmail.com", "Reservation", corps);
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
            public string Vhc { get; set; }
            public DateTime Datedep { get; set; }
            public string Hdepart { get; set; }
            public string Mindep { get; set; }
            public DateTime Dateret { get; set; }
            public string Hretour { get; set; }
            public string Minret { get; set; }

            public string Lieuxliv { get; set; }

            public string Lieuxrec { get; set; }

            public string GPS { get; set; }
            public string Siegeb { get; set; }
            public string Barretoit{ get; set; }
            public string Deuxconducteur { get; set; }

        }
    }
}