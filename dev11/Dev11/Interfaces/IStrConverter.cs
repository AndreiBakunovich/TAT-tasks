using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev11.Interfaces
{
    //interface necessary for the bi-directional conversion
    interface IStrConverter
    {
        string StrLatinToCirillicConverter(string data);
        string StrCirillicToLatinConverter(string data);
    }
}
