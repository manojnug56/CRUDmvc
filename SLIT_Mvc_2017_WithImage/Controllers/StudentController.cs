using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLIT_Mvc_2017_WithImage.Models;

namespace SLIT_Mvc_2017_WithImage.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        BasicLayeredDB_DemoEntities db = new BasicLayeredDB_DemoEntities();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
                return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Student student)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssffff") + filename;
            string extention = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
            student.ImageFile = "~/Images/" + _filename;

            if(extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
            {
                if(file.ContentLength <= 1000000)
                {
                    db.Students.Add(student);
                    if (db.SaveChanges()>0)
                    {
                        file.SaveAs(path);
                        ModelState.Clear();
                    }
                }

                else
                {
                    ViewBag.msg = "Size is not valid !";
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault());
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, int id, Student student)
        {
            
            try
            {
                // TODO: Add update logic here
                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssffff") + filename;
                string extention = Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
                student.ImageFile = "~/Images/" + _filename;

                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                {
                    if (file.ContentLength <= 1000000)
                    {
                        db.Entry(student).State = EntityState.Modified;
                        if (db.SaveChanges() > 0)
                        {
                            file.SaveAs(path);
                            ModelState.Clear();
                        }
                    }

                    else
                    {
                        ViewBag.msg = "Size is not valid !";
                    }
                }                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault());
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                // TODO: Add delete logic here
                
                student = db.Students.Where(x => x.StudentID == id).FirstOrDefault();
                db.Students.Remove(student);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoadTblDetails()
        {
           
            //var list = (from st in db.StudentMasters
            //            join cs in db.Courses on st.CourseSerial equals cs.CourseSerial
            //            select new
            //            {
            //                st.Serial,
            //                cs.CourseName
            //            }).ToList().Where(x=>x.Serial >= 100 && x.Serial <= 200).OrderBy(y=>y.Serial);

            //var list = db.StudentDataLoad();

            List<GetAllStudents_Result> list = db.GetAllStudents().ToList();

            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            
        }
    }
}