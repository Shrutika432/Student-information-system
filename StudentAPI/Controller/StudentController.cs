using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controller
{
    public class StudentController : ApiController
    {
        StudentDBEntities db = new StudentDBEntities();
        //1)Insert records into tables
        public IHttpActionResult PostData(Student_Info student)
        {
            try
            {
                if (student != null)
                {
                    db.Student_Info.Add(student);
                    db.SaveChanges();
                    return Ok("Data added successfully");
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, "No Data Foun!!");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Provide Proper Data!!");
            }
        }

        //2)View a specific record of the table
        public IHttpActionResult GetStudent(int Sid)
        {
            try
            {
                Student_Info student = db.Student_Info.Find(Sid);
                if (student != null)
                {
                    return Content(HttpStatusCode.OK, student);
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "There is no student data with Sid: '"+Sid+"'");
                }
                
               


            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please try again!!");
                throw;
            }
        }
        
        //3)Update a specific record.
        public IHttpActionResult UpdateStudent(int Sid,Student_Info student)
        {
            try
            {
                Student_Info students = db.Student_Info.Find(Sid);
                if (students != null)
                {
                    students.Sname = student.Sname;
                    students.Degree = student.Degree;
                    students.City = students.City;
                    students.Gender = students.Gender;
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, students);
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "There is no student data with Sid: '" + Sid + "'");
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please try again!!");
                throw;
            }
        }

        //4)Delete a Record.
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int Sid)
        {
            try
            {
                Student_Info students = db.Student_Info.Find(Sid);
                if (students != null)
                {
                    db.Student_Info.Remove(students);
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK,"Data Deleted Successfully");
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "There is no student data with Sid: '" + Sid + "'");
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please try again!!");
                throw;
            }
        }

        //5)View all the records of the table
        public IHttpActionResult GetData()
        {
            try
            {
                List<Student_Info> data = db.Student_Info.ToList();
                if (data.Count > 0)
                {
                    return Content(HttpStatusCode.OK, data);
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, "No Data Foun!!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
