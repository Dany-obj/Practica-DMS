using Xunit;
using StudentManagement;

namespace StudentManagement.Tests
{
    public class StudentServiceTests
    {
        [Fact]
        public void EstudianteConNotaMayorA51_DeberiaAprobar()
        {
            var estudiante = new Estudiante { CI = 123, Nombre = "Juan", Nota = 70 };
            var servicio = new StudentService();

            var resultado = servicio.HasApproved(estudiante);

            Assert.True(resultado);
        }

        [Fact]
        public void EstudianteConNotaMenorA51_DeberiaReprobar()
        {
            var estudiante = new Estudiante { CI = 124, Nombre = "Maria", Nota = 40 };
            var servicio = new StudentService();

            var resultado = servicio.HasApproved(estudiante);

            Assert.False(resultado);
        }

        [Fact]
        public void Estudiante_DeberiaTenerNombreCorrecto()
        {
            var estudiante = new Estudiante { CI = 125, Nombre = "Pedro", Nota = 60 };

            Assert.Equal("Pedro", estudiante.Nombre);
        }

        [Fact]
        public void Estudiante_DeberiaTenerCICorrecto()
        {
            var estudiante = new Estudiante { CI = 999, Nombre = "Lucia", Nota = 90 };

            Assert.Equal(999, estudiante.CI);
        }
    }
}
