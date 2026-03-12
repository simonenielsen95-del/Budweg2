using Budweg2._0.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Budweg2._0.Repository
{
    internal class DeliveryNoteRepository
    {
        public void CreateDeliveryNote(DeliveryNote deliveryNoteToBeCreated, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO DeliveryNote (OrderNo, StartQuantity, ItemNo) " +
                     "VALUES(@OrderNo,@StartQuantity,@ItemNo); " +
                      "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@OrderNo", SqlDbType.Int).Value = deliveryNoteToBeCreated.OrderNo;
                    cmd.Parameters.Add("@StartQuantaty", SqlDbType.Int).Value = deliveryNoteToBeCreated.StartQuantity;
                    cmd.Parameters.Add("@ItemNo", SqlDbType.Int).Value = deliveryNoteToBeCreated.Item.ItemNo;
                    deliveryNoteToBeCreated.OrderNo = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
