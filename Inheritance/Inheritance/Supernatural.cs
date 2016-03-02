using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Supernatural
    {
        protected string angelName = "Castiel";
        protected string hunterName = "Dean";

        public string Hunter { get; set; }
        public string Angel { get; set; }

        public Supernatural()
        {
            Angel = angelName;
            Hunter = hunterName;
        }



    }
}
