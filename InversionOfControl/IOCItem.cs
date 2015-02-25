using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControl
{
    public class IOCItem
    {
        public IOCItem()
        {

        }

        public IOCItem(Type Interface, string ClassName)
            : this(Interface, ClassName, string.Empty)
        {
        }

        public IOCItem(Type Interface, string ClassName, string Country)
        {
            this.Interface = Interface;
            this.ClassName = ClassName;
           // this.Country = Country;
        }


        public Type Interface { get; private set; }

       // public string Country { get; private set; }

        public string ClassName { get; private set; }
    }
}
