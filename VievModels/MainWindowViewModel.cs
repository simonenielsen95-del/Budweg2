using Budweg2._0.Models;
using Budweg2._0.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Budweg2._0.Repository;
using System.ComponentModel;

namespace Budweg2._0.VievModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DeliveryNoteRepository deliveryNoteRepository = new DeliveryNoteRepository();
        private ItemRepository itemRepository = new ItemRepository();

        public int ItemNo { get; set; }

        public int Quantity { get; set; }

        public ObservableCollection<DeliveryNote> OCDeliveryNotes { get; set; } = new ObservableCollection<DeliveryNote>();

        // Property for binding items in the UI
        public ObservableCollection<Item> OCItems { get; set; } = new ObservableCollection<Item>();

        public MainWindowViewModel()
        {

            foreach (DeliveryNote dn in deliveryNoteRepository.GetAllDeliveryNotes())
            {
                OCDeliveryNotes.Add(dn);
            }

            foreach (Item item in itemRepository.RetriveAll())
            {
                OCItems.Add(item);
            }
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set

                {
                    _selectedItem = value;

                   OnPropertyChanged(nameof(SelectedItem));
                }

            }
        

        public void AddDeliveryNote()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Vælg en vare fra listen.");
                return;
            }

            if (Quantity <=0)
            {
                MessageBox.Show("Antallet skal være større end 0.");
                return;
            }


            DeliveryNote newNote = new DeliveryNote(Quantity, SelectedItem.ItemNo);

            deliveryNoteRepository.CreateDeliveryNote(newNote); //tilføje en add-metode i repo

            OCDeliveryNotes.Add(newNote);

            //nulstille felter
            Quantity = 0;
            SelectedItem = null;

            OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(SelectedItem));

            MessageBox.Show($"Følgeseddel oprettet med ordre nr.: {newNote.OrderNo}");

        }

    }
}