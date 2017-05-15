using ACCESO_DATOS.Interface;
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
    public class ADO_Sucursal : IADO_Sucursal
    {
        public int Actualizar_Sucursal(ENT_Sucursal p_ent_sucursal)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Actualizar_Sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Sucursal", p_ent_sucursal.Id_Sucursal);
                cmd.Parameters.AddWithValue("@Nombre_Sucursal", p_ent_sucursal.Nombre_Sucursal);
                cmd.Parameters.AddWithValue("@Direccion_Sucursal", p_ent_sucursal.Direccion_Sucursal);
                cmd.Parameters.AddWithValue("@Id_Banco", p_ent_sucursal.Id_Banco);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Eliminar_Sucursal(ENT_Sucursal p_ent_sucursal)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Eliminar_Sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Sucursal", p_ent_sucursal.Id_Sucursal);
                cmd.Parameters.AddWithValue("@Estado", p_ent_sucursal.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Insertar_Sucursal(ENT_Sucursal p_ent_sucursal)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Insertar_Sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Sucursal", p_ent_sucursal.Nombre_Sucursal);
                cmd.Parameters.AddWithValue("@Direccion_Sucursal", p_ent_sucursal.Direccion_Sucursal);
                cmd.Parameters.AddWithValue("@Id_Banco", p_ent_sucursal.Id_Banco);
                //cmd.Parameters.Add("@Id_Sucursal", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                //int Id_Sucursal = 0;
                //Id_Sucursal = Convert.ToInt32(cmd.Parameters["@Id_Sucursal"].Value.ToString().Trim());
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<ENT_Sucursal> Listar_Sucursales()
        {
            List<ENT_Sucursal> lst = new List<ENT_Sucursal>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Sucursales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Sucursal item = new ENT_Sucursal();
                        item.Id_Sucursal = reader.GetInt32(reader.GetOrdinal("Id_Sucursal"));
                        item.Nombre_Sucursal = reader.GetString(reader.GetOrdinal("Nombre_Sucursal"));
                        item.Direccion_Sucursal = reader.GetString(reader.GetOrdinal("Direccion_Sucursal"));
                        item.Fecha_Registro = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro"));
                        item.Estado = reader.GetInt32(reader.GetOrdinal("Estado"));
                        item.Id_Banco = reader.GetInt32(reader.GetOrdinal("Id_Banco"));
                        item.Nombre_Banco = reader.GetString(reader.GetOrdinal("Nombre_Banco"));
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

        public List<ENT_Sucursal> Listar_Sucursal(int p_id_sucursal)
        {
            List<ENT_Sucursal> lst = new List<ENT_Sucursal>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Sucursal", p_id_sucursal);
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Sucursal item = new ENT_Sucursal();
                        item.Id_Sucursal = reader.GetInt32(reader.GetOrdinal("Id_Sucursal"));
                        item.Nombre_Sucursal = reader.GetString(reader.GetOrdinal("Nombre_Sucursal"));
                        item.Direccion_Sucursal = reader.GetString(reader.GetOrdinal("Direccion_Sucursal"));
                        item.Fecha_Registro = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro"));
                        item.Estado = reader.GetInt32(reader.GetOrdinal("Estado"));
                        item.Id_Banco = reader.GetInt32(reader.GetOrdinal("Id_Banco"));
                        item.Nombre_Banco = reader.GetString(reader.GetOrdinal("Nombre_Banco"));
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

        public List<ENT_Sucursal> Listar_Sucursales_Banco(int p_id_banco)
        {
            List<ENT_Sucursal> lst = new List<ENT_Sucursal>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Sucursales_Banco", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Banco", p_id_banco);
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Sucursal item = new ENT_Sucursal();
                        item.Id_Sucursal = reader.GetInt32(reader.GetOrdinal("Id_Sucursal"));
                        item.Nombre_Sucursal = reader.GetString(reader.GetOrdinal("Nombre_Sucursal"));
                        item.Direccion_Sucursal = reader.GetString(reader.GetOrdinal("Direccion_Sucursal"));
                        item.Fecha_Registro = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro"));
                        item.Estado = reader.GetInt32(reader.GetOrdinal("Estado"));
                        item.Nombre_Banco = reader.GetString(reader.GetOrdinal("Nombre_Banco"));
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
