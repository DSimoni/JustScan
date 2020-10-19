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


                cmd.Parameters.Add(new SqlParameter("@BusinessName", name.Split('_')[0]));


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    Menu menu = new Menu();

                    while (rdr.Read())
                    {

                        menu = new Menu()
                        {
                            BusinessID = Int32.Parse(rdr["BusinessID"].ToString()),
                            BusinessName = rdr["BusinessName"].ToString(),
                            BusinessType = rdr["BusinessType"].ToString(),
                            BusinessLanguage = rdr["BusinessLanguage"].ToString(),
                            ImageID = Int32.Parse(rdr["ImageID"].ToString()),
                            CategoryName = rdr["CategoryName"].ToString(),
                            SubCategoryName = rdr["SubCategoryName"].ToString(),
                            Description = rdr["Description"].ToString(),
                            MetaDescription = rdr["MetaDescription"].ToString(),
                            Price = Double.Parse(rdr["Price"].ToString())

                        };

                        if (name.Contains("_"))
                            menus.Add(checkLanguage(name.Split('_')[name.Split('_').Length - 1], menu));
                        else menus.Add(checkLanguage(name,menu));

                    }
                }

                sqlCon.Close();

            }
            return menus;

        }

        private Menu checkLanguage(string lang, Menu menu)
        {
            String[] CategoryName = menu.CategoryName.Split(";");
            String[] SubCategoryName = menu.SubCategoryName.Split(";");
            String[] Description = menu.Description.Split(";");
            String[] MetaDescription = menu.MetaDescription.Split(";");


            switch (lang)
            {
                    case "en":
                    menu.CategoryName = CategoryName[1];
                    menu.SubCategoryName = SubCategoryName[1];
                    menu.Description = Description[1];
                    menu.MetaDescription = MetaDescription[1];

                    break;

                     case "it":
                    menu.CategoryName = CategoryName[2];
                    menu.SubCategoryName = SubCategoryName[2];
                    menu.Description = Description[2];
                    menu.MetaDescription = MetaDescription[2];
                    break;

                default:
                    menu.CategoryName = CategoryName[0];
                    menu.SubCategoryName = SubCategoryName[0];
                    menu.Description = Description[0];
                    menu.MetaDescription = MetaDescription[0];
                    break;
            }

            return menu;

        }
    }
}
