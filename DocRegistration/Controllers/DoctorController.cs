using DocRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DocRegistration.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Get database Doctor models to initialize the form elements and validation in the view
        public ActionResult CreateDoctor(int id = 0)
        {
            Doctor docModel = new Doctor();
            return View(docModel);
        }

        //GET: Retrieve all values in datase
        public ActionResult GetData()
        {
            using (DbModels db = new DbModels())
            {
                List<Doctor> doctorList = db.Doctors.ToList<Doctor>();
                return View(doctorList);
            }
        }

        //POST: Create a new doctor record
        [HttpPost]
        public ActionResult CreateDoctor(Doctor docModel)
        {
            // Initiate the "DbModels" as the database context and add a Doctor record "dbModel" to database
            using (DbModels dbModel = new DbModels())
            {
                if (docModel.DoctorID == 0)
                {
                    dbModel.Doctors.Add(docModel);
                    dbModel.SaveChanges();
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registered Successfully";
            return View("CreateDoctor", new Doctor());

        }
    }
    
}