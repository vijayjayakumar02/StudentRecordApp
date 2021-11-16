using StudentApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DAL.Db db = new DAL.Db();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_Student()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add_Student(Student stud)
        {
            string result = string.Empty;
            try
            {
                db.Add_data(stud);
                result = "New Student Created";
            }
            catch (Exception e)
            {
                result = "Failed";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Show_data()
        {
            return View();
        }

        public JsonResult Get_data()
        {
            DataSet ds = db.GetAllStudent();
            List<Student> studentlist = new List<Student>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                studentlist.Add(new Student
                {
                    StudentId = Convert.ToInt32(dr["StudentID"]),
                    StudentName = dr["StudentName"].ToString(),
                    StudentAge = Convert.ToInt32(dr["StudentAge"])
                }); 
            }
            return Json(studentlist, JsonRequestBehavior.AllowGet);
        }
    }
}