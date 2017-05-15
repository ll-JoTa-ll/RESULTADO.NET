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
    public class ADO_Orden_Pago : IADO_Orden_Pago
    {
        public int Actualizar_Orden(ENT_Orden_Pago p_ent_orden)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Actualizar_Orden", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Orden_Pago", p_ent_orden.Id_Orden_Pago);
                cmd.Parameters.AddWithValue("@Monto", p_ent_orden.Monto);
                cmd.Parameters.AddWithValue("@Moneda", p_ent_orden.Moneda);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Eliminar_Orden(ENT_Orden_Pago p_ent_orden)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Eliminar_Orden", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Orden_Pago", p_ent_orden.Id_Orden_Pago);
                cmd.Parameters.AddWithValue("@Estado", p_ent_orden.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Insertar_Orden(ENT_Orden_Pago p_ent_orden)
        {
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Insertar_Orden", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Monto", p_ent_orden.Monto);
                cmd.Parameters.AddWithValue("@Moneda", p_ent_orden.Moneda);
                cmd.Parameters.AddWithValue("@Estado", p_ent_orden.Estado);
                cmd.Parameters.AddWithValue("@Id_Sucursal", p_ent_orden.Id_Sucursal);
                //cmd.Parameters.Add("@Id_Orden_Pago", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                //int Id_Orden_Pago = 0;
                //Id_Orden_Pago = Convert.ToInt32(cmd.Parameters["@Id_Orden_Pago"].Value.ToString().Trim());
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<ENT_Orden_Pago> Listar_Ordenes()
        {
            List<ENT_Orden_Pago> lst = new List<ENT_Orden_Pago>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Orden", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Orden_Pago item = new ENT_Orden_Pago();
                        item.Id_Orden_Pago = reader.GetInt32(reader.GetOrdinal("Id_Orden_Pago"));
                        item.Monto = reader.GetDecimal(reader.GetOrdinal("Monto"));
                        item.Moneda = reader.GetString(reader.GetOrdinal("Moneda"));
                        item.Estado = reader.GetString(reader.GetOrdinal("Estado"));
                        item.Fecha_Pago = reader.GetDateTime(reader.GetOrdinal("Fecha_Pago"));
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


        public List<ENT_Orden_Pago> Listar_Ordenes_Sucursal(int p_id_sucursal, string p_moneda)
        {
            List<ENT_Orden_Pago> lst = new List<ENT_Orden_Pago>();
            SqlConnection con = new SqlConnection(Conexion.CNX);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Listar_Ordenes_Sucursal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Sucursal", p_id_sucursal);
                cmd.Parameters.AddWithValue("@Moneda", p_moneda);
                con.Open();
                using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        ENT_Orden_Pago item = new ENT_Orden_Pago();
                        item.Id_Orden_Pago = reader.GetInt32(reader.GetOrdinal("Id_Orden_Pago"));
                        item.Monto = reader.GetDecimal(reader.GetOrdinal("Monto"));
                        item.Moneda = reader.GetString(reader.GetOrdinal("Moneda"));
                        item.Estado = reader.GetString(reader.GetOrdinal("Estado"));
                        item.Fecha_Pago = reader.GetDateTime(reader.GetOrdinal("Fecha_Pago"));
                        item.Nombre_Sucursal = reader.GetString(reader.GetOrdinal("Nombre_Sucursal"));
                        item.Direccion_Sucursal = reader.GetString(reader.GetOrdinal("Direccion_Sucursal"));
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
