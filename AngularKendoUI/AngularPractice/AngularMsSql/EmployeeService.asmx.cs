using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {
        [WebMethod]
        public void GetData()
        {
            List<Country> listCountries = new List<Country>();

            string cs = ConfigurationManager.ConnectionStrings["AngularEmployee"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblCountry; select * from tblCity;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataView dataView = new DataView(ds.Tables[1]);

                foreach (DataRow countryDataRow in ds.Tables[0].Rows)
                {
                    Country country = new Country();
                    country.Id = Convert.ToInt32(countryDataRow["Id"]);
                    country.Name = countryDataRow["Name"].ToString();

                    dataView.RowFilter = "CountryId = '" + country.Id + "'";

                    List<City> listCities = new List<City>();

                    foreach (DataRowView cityDataRowView in dataView)
                    {
                        City city = new AngularMsSql.City();
                        city.Id = Convert.ToInt32(cityDataRowView["Id"]);
                        city.Name = cityDataRowView["Name"].ToString();
                        city.CountryId = Convert.ToInt32(cityDataRowView["CountryId"]);
                        listCities.Add(city);
                    }

                    country.Cities = listCities;
                    listCountries.Add(country);
                }
            }        
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listCountries));
        }

        //string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=AngularEmployee;Integrated Security=SSPI;";

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string InsertEmployee(string empId, string firstName, string lastName, string address, string city, string pincode, string state, string country)
        //{
        //    SqlConnection con = new SqlConnection(connection);
        //    SqlCommand cmd;
        //    try
        //    {
        //        con.Open();
        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "INSERT INTO EmployeeDetails(Id, FirstName, LastName, Address, City, Pincode, State, Country) VALUES (@Id, @FirstName, @LastName, @Address, @City, @Pincode, @State, @Country)";
        //        cmd.Parameters.AddWithValue("@Id", empId);
        //        cmd.Parameters.AddWithValue("@FirstName", firstName);
        //        cmd.Parameters.AddWithValue("@LastName", lastName);
        //        cmd.Parameters.AddWithValue("@Address", address);
        //        cmd.Parameters.AddWithValue("@City", city);
        //        cmd.Parameters.AddWithValue("@Pincode", Convert.ToInt32(pincode));
        //        cmd.Parameters.AddWithValue("@State", state);
        //        cmd.Parameters.AddWithValue("@Country", country);
        //        cmd.ExecuteNonQuery();
        //        return "Record Inserted Successfully";
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State == System.Data.ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //}
    }
}
