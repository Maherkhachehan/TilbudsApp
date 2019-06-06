using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TilbudsApp.Annotations;
using TilbudsApp.Common;
using TilbudsApp.Handler;
using TilbudsApp.Model;
using TilbudsApp.Model.Singleton;

namespace TilbudsApp.ViewModel
{
   class OpretItem : INotifyPropertyChanged
    {
        private ICommand _createItemCommand;
        private ICommand _deleteItemCommand;
        private ICommand _selectItemCommand;
        
        private int _id;
        private string _beskrivelse;
        private string _iname;
        public string overskrift { get; set; }
        #region props

        //Skriv propertiesne fra klassen -- Tilbuditem & Item
        public int ItemId { get; set; }

        public string Iname
        {
            get { return _iname;}
            set
            {
                _iname = value;
                OnPropertyChanged(nameof(Iname));
            }
        }

        public OpretItem()
        {
            overskrift = "Tilføj vare";
        }
        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set
            {
                _beskrivelse = value;
                OnPropertyChanged(nameof(_beskrivelse));
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(_id));
            }
        }
        public int ButikId { get; set; }
        public int Antal { get; set; }

        public ItemSingleton ItemSingleton { get; set; }

        public ItemHandler ItemHandler { get; set; }

        public RelayCommand AddItemCommand { get; set; }

        public Item SelectedItem { get; set; }

        public ICommand SelectItemCommand
        {
            get
            {
                return _selectItemCommand ??
                       (_selectItemCommand = new RelayArgCommand<Item>(i => ItemHandler.SetSelectedItem(i)));
            }
            set { _selectItemCommand = value; }
        }


        #endregion

        

        

        public ICommand CreateItemCommand
        {
            get { return _createItemCommand ?? (_createItemCommand = new RelayCommand(ItemHandler.AddItem)); }
            set { _createItemCommand = value; }
        }

        public ICommand DeleteItemCommand
        {
            get { return _deleteItemCommand ?? (_deleteItemCommand = new RelayCommand(ItemHandler.DeleteItem)); }
            set { _deleteItemCommand = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
