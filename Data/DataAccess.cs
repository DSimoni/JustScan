using JustScan.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JustScan.Data
{
    public class DataAccess
    {
        IConfiguration _iconfiguration;


        public DataAccess(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public List<Menu> getMenu(string name)
        {
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
                    Menu menu = new Menu();

                    while (rdr.Read())
                    {

                        menu = new Menu()
                        {
                            BusinessID = rdr["BusinessID"].ToString(),
                            BusinessName = rdr["BusinessName"].ToString(),
                            BusinessType = rdr["BusinessType"].ToString(),
                            CategoryName = rdr["CategoryName"].ToString(),
                            SubCategoryName = rdr["SubCategoryName"].ToString(),
                            Description = rdr["Description"].ToString(),
                            Price = Double.Parse(rdr["Price"].ToString())

                        };
                        menus.Add(menu);

                    }
                }

                sqlCon.Close();

            }
            return menus;

        }
    }
}
