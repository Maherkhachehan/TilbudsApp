using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Model;

namespace TilbudsApp.ViewModel
{
    class ByerViewModel
    {
        public int Id { get; set; }

        private string _bName;

        public string Bname
        {
            get { return _bName; }
            set
            {
                _bName = value;
                // onPropChanged(nameof(Bname))
                // onPropChanged("Bname")
            }
        }


        public ByerSingleton ByerSingleton { get; set; }

        public ByerViewModel()
        {
            ByerSingleton = ByerSingleton.Instance;
            ByerSingleton.LoadFromDB();
        }

    }

}
