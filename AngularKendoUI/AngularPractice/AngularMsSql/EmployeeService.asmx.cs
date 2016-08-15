using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace AngularKendoUI.AngularPractice.AngularMsSql
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {
        string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=AngularEmployee;Integrated Security=SSPI;";

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertEmployee(string empId, string firstName, string lastName, string address, string city, string pincode, string state, string country)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd;
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO EmployeeDetails(Id, FirstName, LastName, Address, City, Pincode, State, Country) VALUES (@Id, @FirstName, @LastName, @Address, @City, @Pincode, @State, @Country)";
                cmd.Parameters.AddWithValue("@Id", empId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Pincode", Convert.ToInt32(pincode));
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.ExecuteNonQuery();
                return "Record Inserted Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
