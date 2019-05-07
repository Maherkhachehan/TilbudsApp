using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilbudsApp.Model
{
    class Butik
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int Zipcode { get; set; }
        public string Adresse { get; set; }

        public Butik(int id, int firmaId, int zipcode, string adresse)
        {
            Id = id;
            FirmaId = firmaId;
            Zipcode = zipcode;
            Adresse = adresse;

        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirmaId)}: {FirmaId}, {nameof(Zipcode)}: {Zipcode}, {nameof(Adresse)}: {Adresse}";
        }
    }
}
