using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model
{
    class ByerSingleton
    {
        private static ByerSingleton _instance = null;

        public static ByerSingleton Instance
        {
            get { return _instance ?? (_instance = new ByerSingleton()); }
        }

        public ObservableCollection<Byer> ByerCollection { get; set; }

        private ByerSingleton()
        {
            ByerCollection = new ObservableCollection<Byer>();
        }

        public void Add(int id, string bName)
        {
            Byer byToBeAdded = new Byer(id, bName);
            ByerCollection.Add(byToBeAdded);
            ByerPersistencyService.PostByAsync(byToBeAdded);
        }

        public void Delete(Byer ByToBeDelete)
        {
            ByerCollection.Remove((ByToBeDelete));
            ByerPersistencyService.DeleteByAsync(ByToBeDelete);
        }

    }
}
