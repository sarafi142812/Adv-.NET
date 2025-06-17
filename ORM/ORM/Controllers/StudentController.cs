using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORM.Models;

namespace ORM.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        
        public ActionResult Index()
        {
            UMS_AEntities db = new UMS_AEntities();
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            UMS_AEntities db = new UMS_AEntities();
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult Edit(int Id)
        {
            UMS_AEntities db = new UMS_AEntities();
            var student = (from st in db.Students
                           where st.Id == Id
                           select st).First();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                var entity = (from st in db.Students
                              where st.Id == s.Id
                              select st).FirstOrDefault();
               /* entity.Name = s.Name;
                entity.Dob = s.Dob;
                entity.Gender = s.Gender;
                entity.Cgpa = s.Cgpa;*/
                db.Entry(entity).CurrentValues.SetValues(s); // This will update all properties of the entity with the values from the model
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }
                
        }
        public ActionResult Delete(int id)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                var student = (from st in db.Students
                               where st.Id == id
                               select st).FirstOrDefault();
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            using (UMS_AEntities db = new UMS_AEntities())
            {
                var entity = (from st in db.Students
                              where st.Id == s.Id
                              select st).FirstOrDefault();

                if (entity != null)
                {
                    db.Students.Remove(entity);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }




    }


}