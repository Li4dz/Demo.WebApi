using Demo.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ApiServiceController.Rest
{
    [Headers("Accept: application/json")]
    public interface IStudentService
    {
        [Get("/api/Student/ObtenerListaEstudiantes")]
        Task<ListStudentDTO> ObtenerListaEstudiantes();

        [Put("/api/Student/ActualizarEstudiante")]
        Task<ListStudentDTO> ActualizarEstudiante([Body]byte[] jsonB64);

        [Post("/api/Student/RegistrarEstudiante")]
        Task<DemoResponse> RegistrarEstudiante([Body]byte[] jsonB64);

        [Delete("/api/Student/EliminarEstudiante")]
        Task<DemoResponse> EliminarEstudiante([Body]byte[] jsonB64);

        [Get("/api/Student/ObtenerEstudiante/{jsonB64}")]
        Task<DemoResponse>ObtenerEstudiante([Body]byte[] jsonB64);
    }
}
