using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Model;
using TilbudsApp.ViewModel;

namespace TilbudsApp.Handler
{
    class ByerHandler
    {
        //SKAL MÅSKE IKKE BRUGES
        public ByerViewModel ByerViewModel { get; set; }

        public ByerHandler(ByerViewModel byerViewModel)
        {
            ByerViewModel = byerViewModel;
        }

        public void SetSelectedBy(Byer by)
        {
            
        }
    }
}
