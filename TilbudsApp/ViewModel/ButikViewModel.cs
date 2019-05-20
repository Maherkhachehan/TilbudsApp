using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Annotations;
using TilbudsApp.Model;
using TilbudsApp.Model.Singleton;

namespace TilbudsApp.ViewModel
{
    public class ButikViewModel : INotifyPropertyChanged
    {
        //public int Id { get; set; }
        //public int FirmaId { get; set; }
        //public int Zipcode { get; set; }
        //public string Adresse { get; set; }

        private Byer _selectedItem;

        public Byer SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                foreach (var butik in ButikSingleton.ButikCollection)
                {
                    if (butik.Zipcode != _selectedItem.Id)
                    {
                        ButikSingleton.ButikCollection.Remove(butik);
                    }
                }
            }
        }

        //public Byer Selectedby
        //{
        //    get { return _selectedby; }
        //    set
        //    {
        //        _selectedby = value;
        //        //ButikSingleton.LoadDb();
        //        //foreach (var butik in ButikSingleton.ButikCollection)
        //        //{
        //        //    if (butik.Zipcode != _selectedby.Id)
        //        //    {
        //        //        ButikSingleton.ButikCollection.Remove(butik);
        //        //    }
        //        //}

        //    }
        //}

        public ButikSingleton ButikSingleton { get; set; }

        public ButikViewModel()
        {
            ButikSingleton = ButikSingleton.Instance;
            ButikSingleton.LoadDb();
            ButikSingleton.LoadFromDB();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
