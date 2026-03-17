using Budweg2._0.Models;
using Budweg2._0.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Budweg2._0.Repository;
using System.Windows.Controls;

namespace Budweg2._0.VievModels
{
    internal class MainWindowViewModel 
    {
        private DeliveryNoteRepository deliveryNoteRepository = new DeliveryNoteRepository();
        private ItemRepository itemRepository = new ItemRepository();



        public ObservableCollection<DeliveryNote>  OCDeliveryNotes { get; set; } = new ObservableCollection<DeliveryNote>();

        // Property for binding items in the UI
        public ObservableCollection<Item> OCItems { get; set; } = new ObservableCollection<Item>();
        private int itemNO;

        public int ItemNo 
        { 
            get
            {
                return this.itemNO;
            }
            set
            {
                try
                {

                    foreach (Item item in OCItems)
                    {
                        if (value == item.ItemNo)
                        {
                            this.itemNO = value;
                            return;
                        }
                    }
                 
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading items: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public int Quantity { get; set; }


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
