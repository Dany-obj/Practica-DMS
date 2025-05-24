namespace StudentManagement
{
    public interface IStudentService
    {
        bool HasApproved(Estudiante estudiante);
        Estudiante CreateStudent(int ci, string nombre, int nota);
    }

    public class StudentService : IStudentService
    {
        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }

        public Estudiante CreateStudent(int ci, string nombre, int nota)
        {
            return new Estudiante { CI = ci, Nombre = nombre, Nota = nota };
        }
    }
}
