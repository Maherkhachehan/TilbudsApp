using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilbudsApp.Model
{
    class Item
    {
        public int Id { get; set; }
        public string Iname { get; set; }
        public string Beskrivelse { get; set; }

        public Item(int id, string iname, string beskrivelse)
        {
            Id = id;
            Iname = iname;
            Beskrivelse = beskrivelse;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Iname)}: {Iname}, {nameof(Beskrivelse)}: {Beskrivelse}";
        }
    }
}
