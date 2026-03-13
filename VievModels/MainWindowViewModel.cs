using System;
using System.Collections.Generic;
using System.Text;
using Budweg2._0.Repository;
using Budweg2._0.Models;

namespace Budweg2._0.VievModels
{
    internal class MainWindowViewModel
    {
        public int ItemNo { get; set; }

        public int Quantity { get; set; }



        public DeliveryNote CreateNewDeliveryNote()
        { 
            DeliveryNote newDeliveryNote = new DeliveryNote();

            return newDeliveryNote;
        }
    }
}
