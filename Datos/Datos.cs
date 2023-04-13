using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class Datos
    {

        static string connectionString = "Data Source=DESKTOP-487N39E;Initial Catalog=DBPruebaWFUsuarios;" +
                             "Integrated Security=False;User Id=test;Password=123456";

        public DataTable ObtenerUsuarios()
        {
            DataTable dt = new DataTable();

            using (var cn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[CRUD_USUARIOS]";

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@Accion",
                        Value = 0,
                        SqlDbType = SqlDbType.Int
                    });
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public DataTable ObtenerUsuario(int idUsr)
        {
            DataTable dt = new DataTable();

            using (var cn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[CRUD_USUARIOS]";

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@Accion",
                        Value = 0,
                        SqlDbType = SqlDbType.Int
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        Direction = ParameterDirection.Input,
                        ParameterName = "@id",
                        Value = idUsr,
                        SqlDbType = SqlDbType.Int
                    });

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

            }
            return dt;
        }


        public bool AgregarUsuario(string Nombre, DateTime Nacimiento, string Sexo)
        {
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand() { Connection = cn })
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[CRUD_USUARIOS]";

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Accion",
                            Value = 1,
                            SqlDbType = SqlDbType.Int
                        });

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Nombre",
                            Value = Nombre,
                            SqlDbType = SqlDbType.VarChar
                        });
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Nacimiento",
                            Value = Nacimiento,
                            SqlDbType = SqlDbType.Date
                        });
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Sexo",
                            SqlDbType = SqlDbType.Char,
                            Value = Sexo
                        });

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


        public bool EditarUsuarios(int idUsr, string Nombre, DateTime Nacimiento, string Sexo)
        {
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand() { Connection = cn })
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[CRUD_USUARIOS]";

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Accion",
                            Value = 2,
                            SqlDbType = SqlDbType.Int
                        });

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@id",
                            Value = idUsr,
                            SqlDbType = SqlDbType.Int
                        });

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Nombre",
                            Value = Nombre,
                            SqlDbType = SqlDbType.VarChar
                        });
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Nacimiento",
                            Value = Nacimiento,
                            SqlDbType = SqlDbType.Date
                        });
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Sexo",
                            SqlDbType = SqlDbType.Char,
                            Value = Sexo
                        });

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool RemoverUsuarios(int idUsr)
        {
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand() { Connection = cn })
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[CRUD_USUARIOS]";

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@Accion",
                            Value = 3,
                            SqlDbType = SqlDbType.Int
                        });

                        cmd.Parameters.Add(new SqlParameter()
                        {
                            Direction = ParameterDirection.Input,
                            ParameterName = "@id",
                            Value = idUsr,
                            SqlDbType = SqlDbType.Int
                        });
                 
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
