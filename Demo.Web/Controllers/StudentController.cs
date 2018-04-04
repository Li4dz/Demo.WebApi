using Demo.ApiServiceController.Implementation;
using Demo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Web.Controllers
{
    public class StudentController : Controller
    {
        IList<StudentModel> studentList;

        public StudentController()
        {
            if(studentList == null)
            {
                studentList = new List<StudentModel>();
                var listaEstudiante = new StudentApiServiceController().ListarEstudiantes();
                listaEstudiante.ForEach(x => studentList.Add(new StudentModel { StudentId = x.StudentId, StudentName = x.StudentName, Age = x.Age }));
            }
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult Edit(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }

        public ActionResult Details(int id)
        {
            DTO.DemoRequest request = new DTO.DemoRequest() { StudentDTO = new DTO.StudentDTO() { StudentId = id } };
            var response = new StudentApiServiceController().ObtenerEstudiante(request);
            var listaEstudiante = new StudentApiServiceController().ListarEstudiantes();
            //StudentModel model = new StudentModel() { StudentName = response.StudentDTO.StudentName, StudentId = response.StudentDTO.StudentId, Age = response.StudentDTO.StudentId };
            return View();
        }

        [HttpPost]
        public ActionResult Edit(StudentModel std)
        {
            //ModelState.AddModelError(string.Empty, "Student Name already exists.");
            DTO.StudentDTO student = new DTO.StudentDTO() { StudentId = std.StudentId, StudentName = std.StudentName, Age = std.Age };
            DTO.ListStudentDTO listStudent = new DTO.ListStudentDTO();
            foreach (var item in studentList)
            {
                listStudent.Add(new DTO.StudentDTO { StudentId = item.StudentId, StudentName = item.StudentName, Age = item.Age });
            }
            DTO.DemoRequest demoRequest = new DTO.DemoRequest() { StudentDTO = student, ListStudentDTO = listStudent };

            if (ModelState.IsValid)
            {
                var listaEstudiante = new StudentApiServiceController().ActualizarEstudiante(demoRequest);
                //this.studentList = new List<StudentModel>();
                //listaEstudiante.ForEach(x => studentList.Add(new StudentModel { StudentId = x.StudentId, StudentName = x.StudentName, Age = x.Age }));
                return RedirectToAction("Index");
            }

            //write code to update student 

            return View(std);
        }

        [HttpPost]
        public ActionResult Create(StudentModel std)
        {
            DTO.StudentDTO student = new DTO.StudentDTO() { StudentName = std.StudentName, Age = std.Age };
            DTO.DemoRequest request = new DTO.DemoRequest() { StudentDTO = student };
            var response = new StudentApiServiceController().RegistrarEstudiante(request);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(StudentModel model)
        {
            DTO.StudentDTO student = new DTO.StudentDTO() { StudentName = model.StudentName, Age = model.Age };
            DTO.DemoRequest request = new DTO.DemoRequest() { StudentDTO = student };
            var response = new StudentApiServiceController().EliminarEstudiante(request);
            return RedirectToAction("Index");
        }
    }
}