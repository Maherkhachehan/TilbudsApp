using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    class ItemSingleton
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
    }
}
