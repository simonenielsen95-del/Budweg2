using Budweg2._0.Models;
using Budweg2._0.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Budweg2._0.Repository;

namespace Budweg2._0.VievModels
{
    internal class MainWindowViewModel
    {
        private DeliveryNoteRepository deliveryNoteRepository = new DeliveryNoteRepository();
        private ItemRepository itemRepository = new ItemRepository();

        public int ItemNo { get; set; }

        public int Quantity { get; set; }

        public ObservableCollection<DeliveryNote>  OCDeliveryNotes { get; set; } = new ObservableCollection<DeliveryNote>();

        // Property for binding items in the UI
        public ObservableCollection<Item> OCItems { get; set; } = new ObservableCollection<Item>();

        public MainWindowViewModel() 
        { 

            foreach(DeliveryNote dn in deliveryNoteRepository.GetAllDeliveryNotes())
            {
                OCDeliveryNotes.Add(dn);
            }
            
            foreach(Item item in itemRepository.RetriveAll())
            { 
                OCItems.Add(item); 
            }
        }

    }
}
