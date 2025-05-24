using Xunit;
using Moq;
using StudentManagement;

namespace StudentManagement.Tests
{
    public class StudentControllerTests
    {
        [Fact]
        public void VerificarAprobacion_UsandoMock_DeberiaRetornarTrue()
        {
            var estudiante = new Estudiante { CI = 101, Nombre = "Carlos", Nota = 80 };

            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.HasApproved(estudiante)).Returns(true);

            var controller = new StudentController(mockService.Object);

            var resultado = controller.VerificarAprobacion(estudiante);

            Assert.True(resultado);
        }

        [Fact]
        public void VerificarAprobacion_UsandoStubManual_DeberiaRetornarFalse()
        {
            var estudiante = new Estudiante { CI = 102, Nombre = "Laura", Nota = 45 };
            var servicioStub = new StudentServiceStub();

            var controller = new StudentController(servicioStub);

            var resultado = controller.VerificarAprobacion(estudiante);

            Assert.False(resultado);
        }

        [Fact]
        public void Verificar_Creacion_De_Estudiante()
        {
            var ciTest = 103;
            var nombreTest = "Ana";
            var notaTest = 75;

            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.CreateStudent(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int ci, string nombre, int nota) => new Estudiante { CI = ci, Nombre = nombre, Nota = nota });
            var controller = new StudentController(mockService.Object);
            var resultado = controller.CrearEstudiante(ciTest, nombreTest, notaTest);
            
            Assert.Equal(ciTest, resultado.CI);
            Assert.Equal(nombreTest, resultado.Nombre);
            Assert.Equal(notaTest, resultado.Nota);

        }
    }

    // Stub manual
    public class StudentServiceStub : IStudentService
    {
        public Estudiante CreateStudent(int ci, string nombre, int nota)
        {
            return new Estudiante { CI = ci, Nombre = nombre, Nota = nota };
        }

        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}
