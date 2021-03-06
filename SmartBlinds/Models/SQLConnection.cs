using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace SmartBlinds.Models
{
    /// <summary>
    /// A static class used to insert data into the SQL database
    /// </summary>
    public static class SQLConnection
    {
        public static void SendCommand(SerialCon serialCon)
        {
            //need to send the database the value of the blindState
            SqlConnection conn = new SqlConnection("Data Source=tcp:s14.winhost.com;Initial Catalog=DB_134003_orders;User ID=DB_134003_orders_user;Password=Electronics1;Integrated Security=False;");

            string query = "Update dbo.SmartBlinds set blindState = " + serialCon.blindState.ToString() + " where BlindID = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            cmd.ExecuteReader();

            conn.Close();
            conn.Dispose();
        }

        public static void UpdateControl(SerialCon serialCon)
        {
            SqlConnection conn = new SqlConnection("Data Source=tcp:s14.winhost.com;Initial Catalog=DB_134003_orders;User ID=DB_134003_orders_user;Password=Electronics1;Integrated Security=False;");

            string query = "";
            if(serialCon.controlMode == 1)
            {
                //time control need to also include times
                query = "Update dbo.SmartBlinds set controlMode = " + serialCon.controlMode.ToString() + " , timecontrolopentime ='"+ serialCon.openTime+"' , timecontrolclosetime = '"+serialCon.closeTime + "' , blindState = 2 where BlindID = 1";

            }
            else if(serialCon.controlMode == 0)
            {
                query = "Update dbo.SmartBlinds set controlMode = " + serialCon.controlMode.ToString() + ", blindState = 2 where BlindID = 1";

            }
            else
            {
                //easy just update the controlMode value
                query = "Update dbo.SmartBlinds set controlMode = " + serialCon.controlMode.ToString() + " where BlindID = 1";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            cmd.ExecuteReader();

            conn.Close();
            conn.Dispose();
        }

        public static SerialCon GetLightMode()
        {
            SqlConnection conn = new SqlConnection("Data Source=tcp:s14.winhost.com;Initial Catalog=DB_134003_orders;User ID=DB_134003_orders_user;Password=Electronics1;Integrated Security=False;");

            SerialCon serialCon = new SerialCon();
            try
            {
                string query = "Select * from dbo.SmartBlinds where BlindID = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
              
                while (reader.Read())
                {
                    serialCon.controlMode = Convert.ToInt32(reader["controlMode"]);
                }
                reader.Close();
                
                conn.Close();
                conn.Dispose();
            }
            catch(Exception e)
            {

            }
            

            return serialCon;
        }
    }
}
