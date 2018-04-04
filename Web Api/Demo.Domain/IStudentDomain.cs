using Demo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain
{
    public interface IStudentDomain
    {
        ListStudentDTO ListarEstudiantes();

        ListStudentDTO ActualizarEstudiante(ListStudentDTO oListStudentDTO, StudentDTO oStudentDTO);

        DemoResponse RegistrarEstudiante(StudentDTO student);

        DemoResponse EliminarEstudiante(int studentId);

        DemoResponse ObtenerEstudiante(int studentId);
    }
}
