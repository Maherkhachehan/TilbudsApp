using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Model;
using TilbudsApp.Model.Singleton;

namespace TilbudsApp.ViewModel
{
    class ButikViewModel
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int Zipcode { get; set; }
        public string Adresse { get; set; }
        //public Byer _selectedby;

        //public Byer Selectedby
        //{
        //    get { return _selectedby; }
        //    set
        //    {
        //        _selectedby = value;
        //        ButikSingleton.LoadDb();
        //        foreach (var butik in ButikSingleton.ButikCollection)
        //        {
        //            if (butik.Zipcode != _selectedby.Id)
        //            {
        //                ButikSingleton.ButikCollection.Remove(butik);
        //            }
        //        }
                
        //    }
        //}
        
        public ButikSingleton ButikSingleton { get; set; }

        public ButikViewModel()
        {
            ButikSingleton = ButikSingleton.Instance;
            ButikSingleton.LoadDb();
            ButikSingleton.LoadFromDB();
        }
        
    }
}
