using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace PatronRepositorio
{
    class Operaciones
    {
        public void Insertar(string nombres, string apellidos, char genero, string fechaNacimiento)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MiBaseDeDatos; Integrated Security=true;");
            SqlCommand comando = new SqlCommand($"INSERT INTO personas (personaId, nombres, apellidos, genero, fechaNacimiento) VALUES (NEWID(), '{nombres}', '{apellidos}', '{genero}', '{fechaNacimiento}')");
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void Editar(Guid personaId, string nombres, string apellidos, char genero, string fechaNacimiento)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MiBaseDeDatos; Integrated Security=true;");
            SqlCommand comando = new SqlCommand($"UPDATE personas SET nombres='{nombres}', apellidos = '{apellidos}', genero = '{genero}', fechaNacimiento = '{fechaNacimiento}' WHERE personaId = '{personaId.ToString()}'");
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void Eliminar(Guid personaId)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MiBaseDeDatos; Integrated Security=true;");
            SqlCommand comando = new SqlCommand($"DELETE FROM personas WHERE personaId = {personaId.ToString()}");
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
