using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using final.DAL;

namespace final.Controllers
{
    public class LogINController : Controller
    {
        ProductDAL DAL =new ProductDAL();
        public ActionResult Verify(Account acn)
        {
            if (DAL.Login(acn) == "Sucess")
            {
                RedirectToAction("Index");
                return View("Create");
                
            }
            else
            { return View("Error"); }
            
        }
    }
    
}