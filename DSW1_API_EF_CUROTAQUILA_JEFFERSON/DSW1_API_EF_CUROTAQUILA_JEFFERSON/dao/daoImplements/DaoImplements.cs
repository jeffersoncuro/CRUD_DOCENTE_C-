using DSW1_API_EF_CUROTAQUILA_JEFFERSON.Model;
using System.Data;

using System.Data.SqlClient;

namespace DSW1_API_EF_CUROTAQUILA_JEFFERSON.dao.daoImplements
{
    public class DaoImplements : iDocentesDAO
    {
        private string connectionString = "Server=DESKTOP-B9U0EBE\\SQLEXPRESS;Database=DB_EF_CUROTAQUILA_JEFFERSON;Integrated Security=true;";

        public List<Docentes> ListarDocentes()
        {
            List<Docentes> docentes = new List<Docentes>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("LISTADOCENTES", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Docentes docente = new Docentes();
                    docente.Codigo = Convert.ToInt32(reader["codigo"]);
                    docente.Nombre = Convert.ToString(reader["nombre"]);
                    docente.Apellido = Convert.ToString(reader["apellido"]);
                    docente.Profesion = Convert.ToString(reader["profesion"]);
                    docente.TipoDocumento = Convert.ToString(reader["tipodocumento"]);
                    docente.Documento = Convert.ToString(reader["documento"]);
                    docentes.Add(docente);
                }
            }
            return docentes;
        }

        public Docentes BuscarDocentePorId(int id)
        {
            Docentes docente = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("BUSCARDOCENTESPORID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    docente = new Docentes();
                    docente.Codigo = Convert.ToInt32(reader["codigo"]);
                    docente.Nombre = Convert.ToString(reader["nombre"]);
                    docente.Apellido = Convert.ToString(reader["apellido"]);
                    docente.Profesion = Convert.ToString(reader["profesion"]);
                    docente.TipoDocumento = Convert.ToString(reader["tipodocumento"]);
                    docente.Documento = Convert.ToString(reader["documento"]);
                }
            }
            return docente;
        }

        public void RegistrarDocente(Docentes docente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("REGISTRARDOCENTES", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", docente.Nombre);
                command.Parameters.AddWithValue("@Apellido", docente.Apellido);
                command.Parameters.AddWithValue("@Profesion", docente.Profesion);
                command.Parameters.AddWithValue("@TipoDocumento", docente.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", docente.Documento);
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarDocente(Docentes docente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EDITARDOCENTES", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", docente.Codigo);
                command.Parameters.AddWithValue("@Nombre", docente.Nombre);
                command.Parameters.AddWithValue("@Apellido", docente.Apellido);
                command.Parameters.AddWithValue("@Profesion", docente.Profesion);
                command.Parameters.AddWithValue("@TipoDocumento", docente.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", docente.Documento);
                command.ExecuteNonQuery();
            }
        }

        public void EliminarDocentePorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ELIMINARDOCENTESPORID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
