using Budweg2._0.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Budweg2._0.Repository
{
    internal class DeliveryNoteRepository
    {

        private readonly string ConnectionString;
        private List<DeliveryNote> deliverynotes;


        public DeliveryNoteRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            deliverynotes = new List<DeliveryNote>();

            ConnectionString = config.GetConnectionString("MyDBConnection")!;
        }

        public List<DeliveryNote> GetAllDeliveryNotes()
        {

            return deliverynotes;
        }


        public void CreateDeliveryNote(DeliveryNote deliveryNote)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO DeliveryNote (StartQuantity, ItemNo) " +
                     "VALUES(@StartQuantity,@ItemNo); " +
                      "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@StartQuantity", SqlDbType.Int).Value = deliveryNote.StartQuantity;
                    cmd.Parameters.Add("@ItemNo", SqlDbType.Int).Value = deliveryNote.ItemNo;
                    deliveryNote.OrderNo = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<DeliveryNote> RetrieveAllDeliveryNotes()
        {
            List<DeliveryNote> deliverynotes = new List<DeliveryNote>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT OrderNo, StartQuantity, ItemNo FROM DeliveryNote", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DeliveryNote deliverynote = new DeliveryNote(dr.GetInt32(1), dr.GetInt32(2))
                        {
                            OrderNo = dr.GetInt32(0)
                        };
                        deliverynotes.Add(deliverynote);
                    }


                }
            }
            return deliverynotes;
        }

    }
}
