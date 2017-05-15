using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;
using System.Data;

namespace ACCESO_DATOS
{
    public class ADO_Banco : Interface.IADO_Banco
    {
        public int Actualizar_Banco(ENT_Banco p_ent_banco)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Actualizar_Banco", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Banco", p_ent_banco.Id_Banco);
                cmd.Parameters.AddWithValue("@Nombre_Banco", p_ent_banco.Nombre_Banco);
                cmd.Parameters.AddWithValue("@Direccion_Banco", p_ent_banco.Direccion_Banco);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Eliminar_Banco(ENT_Banco p_ent_banco)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Eliminar_Banco", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Banco", p_ent_banco.Id_Banco);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
         }

        public int Insertar_Banco(ENT_Banco p_ent_banco)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Insertar_Banco", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Banco", p_ent_banco.Nombre_Banco);
                cmd.Parameters.AddWithValue("@Direccion_Banco", p_ent_banco.Direccion_Banco);
                //cmd.Parameters.Add("@Id_Banco", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                //int Id_Banco = 0;
                //Id_Banco = Convert.ToInt32(cmd.Parameters["@Id_Banco"].Value.ToString().Trim());
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<ENT_Banco> Listar_Bancos()
        {
            List<ENT_Banco> lst = new List<ENT_Banco>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Bancos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Banco item = new ENT_Banco();
                        item.Id_Banco = reader.GetInt32(reader.GetOrdinal("Id_Banco"));
                        item.Nombre_Banco = reader.GetString(reader.GetOrdinal("Nombre_Banco"));
                        item.Direccion_Banco = reader.GetString(reader.GetOrdinal("Direccion_Banco"));
                        item.Fecha_Registro = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro"));
                        item.Estado = reader.GetInt32(reader.GetOrdinal("Estado"));
                        lst.Add(item);
                    }
                    reader.Close();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ENT_Banco> Listar_Banco(int p_id_banco)
        {
            List<ENT_Banco> lst = new List<ENT_Banco>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Banco", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Banco", p_id_banco);
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Banco item = new ENT_Banco();
                        item.Id_Banco = reader.GetInt32(reader.GetOrdinal("Id_Banco"));
                        item.Nombre_Banco = reader.GetString(reader.GetOrdinal("Nombre_Banco"));
                        item.Direccion_Banco = reader.GetString(reader.GetOrdinal("Direccion_Banco"));
                        item.Fecha_Registro = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro"));
                        item.Estado = reader.GetInt32(reader.GetOrdinal("Estado"));
                        lst.Add(item);
                    }
                    reader.Close();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
