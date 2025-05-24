namespace StudentManagement
{
    public class StudentController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public bool VerificarAprobacion(Estudiante estudiante)
        {
            return _studentService.HasApproved(estudiante);
        }

        public Estudiante CrearEstudiante(int ci, string nombre, int nota)
        {
            return _studentService.CreateStudent(ci, nombre, nota);
        }
    }
}
