using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Budweg2._0.Models
{
    public class DeliveryNote
    {
        private int orderNo_;
        private int startQuantity_;
        public int? OrderNo { get { return orderNo_; } set { orderNo_ = value ?? 0; } }
        public int? StartQuantity { get { return startQuantity_; } set { startQuantity_ = value ?? 0; } }
        public int? ItemNo { get; set; }

        public DeliveryNote(int startQuantity, int itemNo)

        {
            startQuantity_ = startQuantity;
            ItemNo = itemNo;

        }

    }
}
