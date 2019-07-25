using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avantura
{
    internal abstract class Item
    {
        int tezina;
        string naziv;
    }

    internal class Kljuc : Item
    {
        (Soba soba, Pravci pravac) otkljucava;
    }

}
