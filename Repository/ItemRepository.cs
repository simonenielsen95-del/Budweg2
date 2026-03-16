using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Budweg2._0.Models;

namespace Budweg2._0.Repository
{
    internal class ItemRepository
    {

        private readonly string ConnectionString;
        private readonly List<Item> items;

        public ItemRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            items = new List<Item>();

            ConnectionString = config.GetConnectionString("MyDBConnection")!;
        }

        //CRUD - metoder her!

        public List<Item> RetriveAll()
        {
            var items = new List<Item>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ItemNo FROM Item", con);

                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            items.Add(new Item
                            {
                                ItemNo = dr.GetInt32(0)
                            });
                        }
                    }
                }
            }

            return items;
        }
    }
}
