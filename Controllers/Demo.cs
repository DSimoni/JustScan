using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JustScan.Controllers
{
    public class DemoController : Controller
    {
        IConfiguration _iconfiguration;
        public DemoController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        // GET: Demo
        public ActionResult Index()
        {
            //string connectionString = _iconfiguration.GetSection("ConnectionStrings").GetSection("ConnectionString").Value;

            //using (SqlConnection  sqlCon = new SqlConnection(connectionString))
            //{
            //    sqlCon.Open();
            //    SqlCommand sql_cmnd = new SqlCommand("PROC_NAME", sqlCon);
            //    //sql_cmnd.CommandType = CommandType.StoredProcedure;
            //    //sql_cmnd.Parameters.AddWithValue("@FIRST_NAME", SqlDbType.NVarChar).Value = firstName;
            //    //sql_cmnd.Parameters.AddWithValue("@LAST_NAME", SqlDbType.NVarChar).Value = lastName;
            //    //sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = age;
            //    sql_cmnd.ExecuteNonQuery();
            //    sqlCon.Close();
            //}
            return View();
        }

        // GET: Demo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
