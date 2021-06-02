using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using PatronRepositorio.Helpers;
using PatronRepositorio.Entidades;

namespace PatronRepositorio.Repositorios
{
    public class PersonaRepositorioSQLServer : IRepositorio<Persona, Guid>
    {
        SqlCommand sqlCmd;

        void ValidarDatos(Persona entidad)
        {
            if (string.IsNullOrEmpty(entidad.nombres)) throw new Exception("Los nombres son obligatorios");

            if (string.IsNullOrEmpty(entidad.apellidos)) throw new Exception("Los apellidos son obligatorios");

            if (string.IsNullOrEmpty(entidad.genero)) throw new Exception("El genero es obligatorio");

            if (string.IsNullOrEmpty(entidad.fechaNacimiento)) throw new Exception("La fecha de nacimiento es obligatoria");
        }

        public Persona Agregar(Persona entidad)
        {
            entidad.PersonaId = Guid.NewGuid();

            ValidarDatos(entidad);

            sqlCmd = new SqlCommand($"Insert Into personas (personaId, nombres, apellidos, genero, fechaNacimiento) " +
                $"values (@personaId, @nombres, '{entidad.apellidos}', '{entidad.genero}', '{entidad.fechaNacimiento}')");
            sqlCmd.Parameters.AddWithValue("@personaId", entidad.PersonaId);
            sqlCmd.Parameters.AddWithValue("@nombres", entidad.nombres);
            SqlConnection cnn = SqlServerHelper.Connection();
            sqlCmd.Connection = cnn;
            cnn.Open();
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Parameters.Clear();
            return entidad;
        }

        public Persona Editar(Persona entidad)
        {
            ValidarDatos(entidad);

            sqlCmd = new SqlCommand($"Update personas Set nombres = '{entidad.nombres}', apellidos = '{entidad.apellidos}'," +
                $"genero = '{entidad.genero}', fechaNacimiento = '{entidad.fechaNacimiento}' Where personaId = '{entidad.PersonaId}'");
            SqlConnection cnn = SqlServerHelper.Connection();
            sqlCmd.Connection = cnn;
            cnn.Open();
            sqlCmd.ExecuteNonQuery();
            return entidad;
        }

        public void Eliminar(Guid entidadId)
        {
            sqlCmd = new SqlCommand($"Delete From personas Where personaId = '{entidadId}'");
            SqlConnection cnn = SqlServerHelper.Connection();
            sqlCmd.Connection = cnn;
            cnn.Open();
            sqlCmd.ExecuteNonQuery();
        }

        public void Agregar3Personas() {
            sqlCmd = new SqlCommand();
            SqlConnection cnn = SqlServerHelper.Connection();
            cnn.Open();
            SqlTransaction transaction = cnn.BeginTransaction();

            sqlCmd.Connection = cnn;
            try {
                sqlCmd.CommandText = "INSERT INTO personas (personaId, nombres, apellidos, genero, fechaNacimiento) VALUES (@personaId, @nombres, @apellidos, @genero, @fecha)";
                sqlCmd.Parameters.AddWithValue("@personaId", Guid.NewGuid());
                sqlCmd.Parameters.AddWithValue("@nombres", "Renard");
                sqlCmd.Parameters.AddWithValue("@apellidos", "Gomez");
                sqlCmd.Parameters.AddWithValue("@genero", "M");
                sqlCmd.Parameters.AddWithValue("@fecha", "1998/11/03");
                sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();

                transaction.Commit();
            } catch (Exception ex) {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
            
        }

        public List<Persona> Listar()
        {
            sqlCmd = new SqlCommand($"Select * From personas Where name LIKE '%jose%'");
            SqlConnection cnn = SqlServerHelper.Connection();
            sqlCmd.Connection = cnn;
            cnn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            List<Persona> personas = new List<Persona>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Persona nuevaPersona = new Persona();
                    nuevaPersona.PersonaId = Guid.NewGuid();
                    nuevaPersona.nombres = "";
                    nuevaPersona.apellidos = "";

                    personas.Add(new Persona()
                        {
                            PersonaId = Guid.Parse(reader["personaId"].ToString()),
                            nombres = reader["nombres"].ToString(),
                            apellidos = reader["apellidos"].ToString(),
                            genero = reader["genero"].ToString(),
                            fechaNacimiento = reader["fechaNacimiento"].ToString(),
                        }
                    );
                }
            }

            return personas;
        }

        public Persona Seleccionar(Guid tipoId)
        {
            sqlCmd = new SqlCommand($"Select Top 1 * From personas Where personaId = {tipoId}");
            SqlConnection cnn = SqlServerHelper.Connection();
            sqlCmd.Connection = cnn;
            cnn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            Persona persona = null;
            if (reader.HasRows)
            {
                if (reader.Read())
                {

                    persona = new Persona()
                    {
                        PersonaId = Guid.Parse(reader["personaId"].ToString()),
                        nombres = reader["nombres"].ToString(),
                        apellidos = reader["apellidos"].ToString(),
                        genero = reader["genero"].ToString(),
                        fechaNacimiento = reader["fechaNacimiento"].ToString(),
                    };
                }
            }

            return persona;
        }
    }
}
