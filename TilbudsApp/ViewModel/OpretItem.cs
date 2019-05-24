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
using TilbudsApp.Model.Singleton;

namespace TilbudsApp.ViewModel
{
    class OpretItem : INotifyPropertyChanged
    {
        public ICommand _createItemCommand;

        //Skriv propertiesne fra klassen -- Tilbuditem & Item
        public int ItemId { get; set; }
        public string Iname { get; set; }
        public string Beskrivelse { get; set; }

        public int Id { get; set; }
        public int ButikId { get; set; }
        public int Antal { get; set; }

        public ItemSingleton ItemSingleton { get; set; }

        public ItemHandler ItemHandler { get; set; }

        public OpretItem()
        {
            ItemSingleton = ItemSingleton.Instance;
            ItemHandler = new ItemHandler(this);
        }

        public ICommand CreateItemCommand
        {
            get { return _createItemCommand ?? (_createItemCommand = new RelayCommand(ItemHandler.AddItem)); }
            set { _createItemCommand = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
