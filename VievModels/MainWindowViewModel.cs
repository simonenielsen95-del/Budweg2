using System;
using System.Collections.Generic;
using System.Text;
using Budweg2._0.Repository;
using Budweg2._0.Models;
using System.Collections.ObjectModel;

namespace Budweg2._0.VievModels
{
    internal class MainWindowViewModel
    {
        private DeliveryNoteRepository deliveryNoteRepository = new DeliveryNoteRepository();

        public int ItemNo { get; set; }

        public int Quantity { get; set; }

        public ObservableCollection<DeliveryNote>  OCDeliveryNotes { get; set; } = new ObservableCollection<DeliveryNote>();


        public MainWindowViewModel() 
        { 

            foreach(DeliveryNote dn in deliveryNoteRepository.GetAllDeliveryNotes())
            {
                OCDeliveryNotes.Add(dn);
            }
        
        }


        //public DeliveryNote CreateNewDeliveryNote()
        //{ 
        //    DeliveryNote newDeliveryNote = new DeliveryNote();

        //    return newDeliveryNote;
        //}
    }
}
