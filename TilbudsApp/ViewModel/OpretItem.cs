﻿using System;
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


        private int _id;
        private string _beskrivelse;
        private string _iname;
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


        #endregion

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
