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
            //ByerCollection.Add(new Byer(4, "test name"));

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

        public void LoadFromDB()
        {

            
            List<Byer> tempList = new List<Byer>();

            // her får jeg en liste af byer. fordi jeg har skrevet ".result"
            tempList = ByerPersistencyService.GetByerAsync().Result;

            // her går jeg igennem listen med foreach, for at add dem til min OC'list
            foreach (Byer by in tempList)
            {
                ByerCollection.Add(by);
            }
        }

    }
}
