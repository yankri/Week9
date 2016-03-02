using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Characters : Supernatural
    {
        public string characters;


        public Characters()
        {
            Supernatural SN = new Supernatural();
            characters = SN.Hunter + " " + SN.Angel;
        }



    }
}
