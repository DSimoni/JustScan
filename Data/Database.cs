using JustScan.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JustScan.Data
{
    public class Database
    {
        IConfiguration _iconfiguration;


        public Database(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public List<Menu> getMenu(string name)
        {
            Menu menu = new Menu();
            List<Menu> menus = new List<Menu>();
            string connectionString = _iconfiguration.GetSection("ConnectionStrings").GetSection("ConnectionString").Value;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();


                SqlCommand cmd = new SqlCommand("GetBusiness", sqlCon);


                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@BusinessName", name));


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {

                        menu = new Menu()
                        {
                            BusinessName = rdr["BusinessName"].ToString(),
                            BusinessType = rdr["BusinessType"].ToString(),
                            CategoryName = rdr["CategoryName"].ToString(),
                            Description = rdr["Description"].ToString(),
                            Price = Double.Parse(rdr["Price"].ToString())

                        };
                        menus.Add(menu);

                    }
                }

                return menus;
            }
        }
    }
}
