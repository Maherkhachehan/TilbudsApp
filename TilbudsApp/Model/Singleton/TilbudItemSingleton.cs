using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    class TilbudItemSingleton
    {
        private static TilbudItemSingleton _instance = null;

        public static TilbudItemSingleton Instance
        {
            get { return _instance ?? (_instance = new TilbudItemSingleton()); }
        }

        public ObservableCollection<TilbudItem> TilbudItemsCollection { get; set; }

        private TilbudItemSingleton()
        {
            TilbudItemsCollection = new ObservableCollection<TilbudItem>();
        }

        public void Add(int id, int itemId, int butikId, int antal)
        {
            TilbudItem tilbudItemToBeAdded = new TilbudItem(id, itemId,butikId,antal);
            TilbudItemsCollection.Add(tilbudItemToBeAdded);
            TilbudItemPersistencyService.PostTilbudItemAsync(tilbudItemToBeAdded);
        }

        public void Delete(TilbudItem TilbudItemToBeDelete)
        {
            TilbudItemsCollection.Remove((TilbudItemToBeDelete));
            TilbudItemPersistencyService.DeleteTilbudItemAsync(TilbudItemToBeDelete);
        }
    }
}
