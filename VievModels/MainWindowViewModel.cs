using System;
using System.Collections.Generic;
using System.Text;
using Budweg2._0.Repository;
using Budweg2._0.Models;

namespace Budweg2._0.VievModels
{
    internal class MainWindowViewModel
    {


        public DeliveryNote CreateNewDeliveryNote()
        { 
            DeliveryNote newDeliveryNote = new DeliveryNote();

            return newDeliveryNote;
        }
    }
}
