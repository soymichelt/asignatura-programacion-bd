using NUnit.Framework;
using PatronRepositorio.Entidades;
using PatronRepositorio.Repositorios;

namespace PatronRepositorio.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AgregarTest()
        {
            RepositorioSQLServerPersona repoPersona = new RepositorioSQLServerPersona();
            Persona persona = repoPersona.Agregar(new Persona() {
                nombres = "Michel",
                apellidos = "Trana",
                genero = "Masculino",
                fechaNacimiento = "31/12/90",
            });

            Assert.IsNotNull(persona);
        }

        [Test]
        public void ValidarDatosTest()
        {
            RepositorioSQLServerPersona repoPersona = new RepositorioSQLServerPersona();
            Persona persona = new Persona()
            {
                nombres = "Michel",
                apellidos = "Trana",
                genero = "Masculino",
                fechaNacimiento = "31/12/90",
            };

            Persona personaGuardada = repoPersona.Agregar(persona);

            Assert.AreEqual(persona, personaGuardada);
        }
    }
}