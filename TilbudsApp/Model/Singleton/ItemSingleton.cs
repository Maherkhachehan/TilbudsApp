using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Annotations;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    class ItemSingleton : INotifyPropertyChanged
    {
        private static ItemSingleton _instance = null;

        public static ItemSingleton Instance
        {
            get { return _instance ?? (_instance = new ItemSingleton()); }
        }

        public ObservableCollection<Item> ItemCollection { get; set; }

        private ItemSingleton()
        {
            ItemCollection = new ObservableCollection<Item>();
           // ItemCollection.Add(new Item(1,"Mad","produktmad"));
        }

        public void Add(int id, string iname, string beskrivelse)
        {
            Item itemToBeAdded = new Item(id, iname,beskrivelse);
            ItemCollection.Add(itemToBeAdded);
            ItemPersistencyService.PostItemAsync(itemToBeAdded);
        }

        public void Delete(Item ItemToBeDelete)
        {
            ItemCollection.Remove((ItemToBeDelete));
            ItemPersistencyService.DeleteItemAsync(ItemToBeDelete);
        }
        
        public async void LoadItem()
        {
            List<Item> ItemList = new List<Item>();

            //her får jeg en liste af items
            ItemList = await ItemPersistencyService.GetItemAsync();
            
            //
            foreach (Item items in ItemList )
            {
                ItemCollection.Add(items);
            }
        }

        
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
