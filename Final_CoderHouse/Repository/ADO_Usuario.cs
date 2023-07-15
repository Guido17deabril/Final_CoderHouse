﻿using Final_CoderHouse.Models;
using System.Data.SqlClient;
using System.Data;

namespace Final_CoderHouse.Repository
{
    public class ADO_Usuario
    {
        static string connectionString = "Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True";

        public static Usuario TraerUsuarioXNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = new Usuario();

            // Verifico si el argumento pasado es válido
            if (String.IsNullOrEmpty(nombreUsuario))
            {
                return usuario; // Devuelvo un objeto Usuario
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [SistemaGestion].[dbo].[Usuario] WHERE NombreUsuario = @nombreUsuario", sqlConnection))
                {
                    var sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "nombreUsuario";
                    sqlParameter.SqlDbType = SqlDbType.VarChar;
                    sqlParameter.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows & dataReader.Read())
                        {
                            usuario.Id = Convert.ToInt32(dataReader["Id"]);
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Contraseña = dataReader["Contraseña"].ToString();
                            usuario.Mail = dataReader["Mail"].ToString();
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuario;
        }

        //Metodo Para iniciar sesion
        public static Usuario IniciarSesion(string nombreUsuario, string contraseña)
        {
            Usuario usuario = new Usuario();

            // Verifico si los argumentos son validos
            if (String.IsNullOrEmpty(nombreUsuario) || String.IsNullOrEmpty(contraseña))
            {
                return usuario; // Devuelvo un Usuario 
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [SistemaGestion].[dbo].[Usuario] WHERE (NombreUsuario = @nombreUsuario AND Contraseña = @contraseña)", sqlConnection))
                {
                    //parametro 1 que es el nombre del usuario
                    var sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "nombreUsuario";
                    sqlParameter1.SqlDbType = SqlDbType.VarChar;
                    sqlParameter1.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(sqlParameter1);

                    //parametro 2 que es la contraseña 
                    var sqlParameter2 = new SqlParameter();
                    sqlParameter2.ParameterName = "contraseña";
                    sqlParameter2.SqlDbType = SqlDbType.VarChar;
                    sqlParameter2.Value = contraseña;
                    sqlCommand.Parameters.Add(sqlParameter2);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows & dataReader.Read())
                        {
                            usuario.Id = Convert.ToInt32(dataReader["Id"]);
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Contraseña = dataReader["Contraseña"].ToString();
                            usuario.Mail = dataReader["Mail"].ToString();
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuario;
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            bool resultado = false;
            int rowsAffected = 0;

            if (usuario.Id <= 0) 
            {
                return false;
            }

            if (String.IsNullOrEmpty(usuario.Nombre) ||
                String.IsNullOrEmpty(usuario.Apellido) ||
                String.IsNullOrEmpty(usuario.NombreUsuario) ||
                String.IsNullOrEmpty(usuario.Contraseña) ||
                String.IsNullOrEmpty(usuario.Mail))
            {
                return false; 
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Usuario] " +
                                        "SET Nombre = @nombre, " +
                                            "Apellido = @apellido, " +
                                            "NombreUsuario = @nombreUsuario, " +
                                            "Contraseña = @contraseña, " +
                                            "Mail = @mail " +
                                            "WHERE Id = @id";

                var parameterNombre = new SqlParameter("nombre", SqlDbType.VarChar);
                parameterNombre.Value = usuario.Nombre;

                var parameterApellido = new SqlParameter("apellido", SqlDbType.VarChar);
                parameterApellido.Value = usuario.Apellido;

                var parameterNombreUsuario = new SqlParameter("nombreUsuario", SqlDbType.VarChar);
                parameterNombreUsuario.Value = usuario.NombreUsuario;

                var parameterContraseña = new SqlParameter("contraseña", SqlDbType.VarChar);
                parameterContraseña.Value = usuario.Contraseña;

                var parameterMail = new SqlParameter("mail", SqlDbType.VarChar);
                parameterMail.Value = usuario.Mail;

                var parameterId = new SqlParameter("id", SqlDbType.BigInt);
                parameterId.Value = usuario.Id;

                sqlConnection.Open(); // Abro la conexión con la BD

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterNombre);
                    sqlCommand.Parameters.Add(parameterApellido);
                    sqlCommand.Parameters.Add(parameterNombreUsuario);
                    sqlCommand.Parameters.Add(parameterContraseña);
                    sqlCommand.Parameters.Add(parameterMail);
                    sqlCommand.Parameters.Add(parameterId);
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            if (rowsAffected == 1)
            {
                resultado = true;
            }
            return resultado;
        }

        public static List<Usuario> TraerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [SistemaGestion].[dbo].[Usuario]", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuarios;
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            bool resultado = false;
            int rowsAffected = 0;

            
            if (String.IsNullOrEmpty(usuario.Nombre) ||
                String.IsNullOrEmpty(usuario.Apellido) ||
                String.IsNullOrEmpty(usuario.NombreUsuario) ||
                String.IsNullOrEmpty(usuario.Contraseña) ||
                String.IsNullOrEmpty(usuario.Mail))
            {
                return false; 
            }

            
            Usuario usuarioEnBD = new Usuario();
            usuarioEnBD = TraerUsuarioXNombreUsuario(usuario.NombreUsuario); 
            if (usuarioEnBD.Id != 0) 
            {
                return resultado; 
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Nombre, Apellido, NombreUsuario, Contraseña, Mail) " + // Query que me permite crear un Usuario.
                                        "VALUES (@nombre, @apellido, @nombreUsuario, @contraseña, @mail) ";

                var parameterNombre = new SqlParameter("nombre", SqlDbType.VarChar);
                parameterNombre.Value = usuario.Nombre;

                var parameterApellido = new SqlParameter("apellido", SqlDbType.VarChar);
                parameterApellido.Value = usuario.Apellido;

                var parameterNombreUsuario = new SqlParameter("nombreUsuario", SqlDbType.VarChar);
                parameterNombreUsuario.Value = usuario.NombreUsuario;

                var parameterContraseña = new SqlParameter("contraseña", SqlDbType.VarChar);
                parameterContraseña.Value = usuario.Contraseña;

                var parameterMail = new SqlParameter("mail", SqlDbType.VarChar);
                parameterMail.Value = usuario.Mail;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterNombre);
                    sqlCommand.Parameters.Add(parameterApellido);
                    sqlCommand.Parameters.Add(parameterNombreUsuario);
                    sqlCommand.Parameters.Add(parameterContraseña);
                    sqlCommand.Parameters.Add(parameterMail);
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            if (rowsAffected == 1)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool EliminarUsuario(long id)
        {
            bool resultado = false;
            int rowsAffected = 0;
          
            if (id <= 0) 
            {
                return false;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Usuario] " + 
                                        "WHERE Id = @id";

                var parameterId = new SqlParameter("id", SqlDbType.BigInt);
                parameterId.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterId);
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            if (rowsAffected == 1)
            {
                resultado = true;
            }
            return resultado;
        }

        public static Usuario TraerUsuario_conId(long id)
        {
            Usuario usuario = new Usuario();

            if (id <= 0)
            {
                return usuario; 
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id", sqlConnection))
                {
                    var sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "id";
                    sqlParameter.SqlDbType = SqlDbType.VarChar;
                    sqlParameter.Value = id;
                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows & dataReader.Read())
                        {
                            usuario.Id = Convert.ToInt32(dataReader["Id"]);
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Contraseña = dataReader["Contraseña"].ToString();
                            usuario.Mail = dataReader["Mail"].ToString();
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuario;
        }

    }
}
