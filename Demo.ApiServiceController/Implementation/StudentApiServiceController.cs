using Demo.ApiServiceController.Interface;
using Demo.ApiServiceController.Rest;
using Demo.Common.API;
using Demo.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Demo.ApiServiceController.Implementation
{
    public class StudentApiServiceController : BaseApiServiceController
    {
        private readonly IStudentService IStudentService;

        public StudentApiServiceController()
        {
            this.IStudentService = RestService.For<IStudentService>(HttpClient, RefitSettings);
        }

        public ListStudentDTO ListarEstudiantes()
        {
            ListStudentDTO lista = IStudentService.ObtenerListaEstudiantes().Result;
            return lista;
        }

        public ListStudentDTO ActualizarEstudiante(DemoRequest oDemoRequest)
        {
            ListStudentDTO lista = IStudentService.ActualizarEstudiante(this.IJsonManager.CreateBinaryData(oDemoRequest)).Result;
            return lista;
        }

        public DemoResponse RegistrarEstudiante(DemoRequest request)
        {
            DemoResponse response = IStudentService.RegistrarEstudiante(this.IJsonManager.CreateBinaryData(request)).Result;
            return response;
        }

        public DemoResponse EliminarEstudiante(DemoRequest request)
        {
            DemoResponse response = IStudentService.EliminarEstudiante(this.IJsonManager.CreateBinaryData(request)).Result;
            return response;
        }

        public DemoResponse ObtenerEstudiante(DemoRequest request)
        {
            DemoResponse response = IStudentService.ObtenerEstudiante(this.IJsonManager.CreateBinaryData(request)).Result;
            return response;
        }
    }
}
