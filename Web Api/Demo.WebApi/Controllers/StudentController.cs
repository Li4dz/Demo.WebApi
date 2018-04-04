using Demo.Common.API;
using Demo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Demo.WebApi.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : BaseAPIController
    {
        [HttpGet]
        [ActionName("ObtenerListaEstudiantes")]
        [Route("ObtenerListaEstudiantes")]
        //[ResponseType(typeof(IList<StudentDTO>))]
        public IHttpActionResult ObtenerListaEstudiantes()
        {
            var listaEstudiantes = new Domain.StudentDomain().ListarEstudiantes();
            return Ok(listaEstudiantes);
        }

        [HttpPut]
        [ActionName("ActualizarEstudiante")]
        [Route("ActualizarEstudiante")]
        public IHttpActionResult ActualizarEstudiante(byte[] contentData)
        {
            string jsonB64 = Convert.ToBase64String(contentData);
            var demoRequest = this.JsonManager.CreateDataFromBase64String<DemoRequest>(jsonB64);
            var student = demoRequest.StudentDTO;
            var listStudent = demoRequest.ListStudentDTO;
            var listaEstudiantes = new Domain.StudentDomain().ActualizarEstudiante(listStudent, student);
            return Ok(listaEstudiantes);
        }

        [HttpPost]
        [ActionName("RegistrarEstudiante")]
        [Route("RegistrarEstudiante")]
        public IHttpActionResult RegistrarEstudiante(byte[] contentData)
        {
            string jsonB64 = Convert.ToBase64String(contentData);
            var request = this.JsonManager.CreateDataFromBase64String<DemoRequest>(jsonB64);
            var student = request.StudentDTO;
            var response = new Domain.StudentDomain().RegistrarEstudiante(student);
            return Ok(response);
        }

        [HttpDelete]
        [ActionName("EliminarEstudiante")]
        [Route("EliminarEstudiante")]
        public IHttpActionResult EliminarEstudiante(byte[] contentData)
        {
            var request = this.JsonManager.CreateDataFromBase64String<DemoRequest>(Convert.ToBase64String(contentData));
            var response = new Domain.StudentDomain().EliminarEstudiante(request.StudentDTO.StudentId);
            return Ok(response);
        }

        [HttpGet]
        [ActionName("ObtenerEstudiante")]
        [Route("ObtenerEstudiante")]
        public IHttpActionResult ObtenerEstudiante(byte[] contentData)
        {
            var request = this.JsonManager.CreateDataFromBase64String<DemoRequest>(Convert.ToBase64String(contentData));
            var response = new Domain.StudentDomain().ObtenerEstudiante(request.StudentDTO.StudentId);
            return Ok(response);
        }
    }
}