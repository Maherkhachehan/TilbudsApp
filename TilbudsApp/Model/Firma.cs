using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilbudsApp.Model
{
    class Firma
    {
        public int Id { get; set; }
        public string Fname { get; set; }


        public Firma(int id, string fname)
        {
            Id = id;
            Fname = fname;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Fname)}: {Fname}";
        }
    }
}
