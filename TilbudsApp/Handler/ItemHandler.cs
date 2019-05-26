using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Model;
using TilbudsApp.ViewModel;

namespace TilbudsApp.Handler
{
    class ItemHandler
    {
        public OpretItem OpretItemVM { get; set; }

        public ItemHandler(OpretItem opretItem)
        {
            OpretItemVM = opretItem;
        }

        public void AddItem()
        {
            
            OpretItemVM.ItemSingleton.Add(
                OpretItemVM.Id, 
                OpretItemVM.Iname, 
                OpretItemVM.Beskrivelse);
        }

        //Sletter den valgte item fra listen. 
        public void DeleteItem()
        {
            OpretItemVM.ItemSingleton.Delete(OpretItemVM.SelectedItem);
        }

        //Gemmer hvilket item man har valgt på listen. 
        public void SetSelectedItem(Item item)
        {
            OpretItemVM.SelectedItem = item;
        }
    }
}
