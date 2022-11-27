using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace _111_1QZ4
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_connS = "";

            s_connS = "Data Source = DESKTOP - GUNQC4G\\SQLEXPRESS03;" +
            "Initial Catalog = test;" +
            "Integrated Security = True;" +
            "Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False;" +
            "ApplicationIntent = ReadWrite; MultiSubnetFailover = False;" +
            "User ID = sa; Password = 12345";

            try {
                SqlConnection o_conn = new SqlConnection(s_connS);

                SqlCommand o_com = new SqlCommand("Select * from Users", o_conn);
                o_conn.Open();
                SqlDataReader o_r = o_com.ExecuteReader();
                    for(; o_r.Read(); ) {
                        for(int i_col = 0;i_col < o_r.FieldCount; i_col++) {
                        Response.Write("&nbsp;&nbsp;" + o_r[i_col].ToString());
                    }
                    Response.Write("<br />");
                } 
                o_conn.Close();
            }
            catch(Exception o_exc) {
                Response.Write(o_exc.ToString());
            }
        }
    }
}