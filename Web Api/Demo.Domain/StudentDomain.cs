using Demo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain
{
    public class StudentDomain : IStudentDomain
    {
        public ListStudentDTO ListarEstudiantes()
        {
            ListStudentDTO oListaEstudiante = new ListStudentDTO();
            oListaEstudiante.Add(new StudentDTO() { StudentId = 1, StudentName = "John", Age = 18 });
            oListaEstudiante.Add(new StudentDTO() { StudentId = 2, StudentName = "Steve", Age = 21 });
            oListaEstudiante.Add(new StudentDTO() { StudentId = 3, StudentName = "Bill", Age = 25 });
            oListaEstudiante.Add(new StudentDTO() { StudentId = 4, StudentName = "Ram", Age = 20 });
            oListaEstudiante.Add(new StudentDTO() { StudentId = 5, StudentName = "Ron", Age = 31 });
            oListaEstudiante.Add(new StudentDTO() { StudentId = 6, StudentName = "Chris", Age = 17 });
            oListaEstudiante.Add(new StudentDTO() { StudentId = 7, StudentName = "Rob", Age = 19 });
            return oListaEstudiante;
        }

        public ListStudentDTO ActualizarEstudiante(ListStudentDTO oListStudentDTO, StudentDTO oStudentDTO)
        {
            oListStudentDTO.Where(x => x.StudentId == oStudentDTO.StudentId).ToList().ForEach(m => { m.StudentName = oStudentDTO.StudentName; m.Age = oStudentDTO.Age; });
            return oListStudentDTO;
        }

        public DemoResponse RegistrarEstudiante(StudentDTO student)
        {
            return new DemoResponse() { Descripcion = "Estudiante registrado satisfactoriamente" };
        }

        public DemoResponse EliminarEstudiante(int studentId)
        {
            return new DemoResponse() { Descripcion = "Estudiante eliminado satisfactoriamente" };
        }

        public DemoResponse ObtenerEstudiante(int studentId)
        {
            DemoResponse response = new DemoResponse();
            response.StudentDTO = ListarEstudiantes().Where(x => x.StudentId == studentId).FirstOrDefault();
            return response;
        }

    }
}
