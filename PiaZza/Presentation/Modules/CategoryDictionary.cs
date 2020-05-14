using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Modules
{
    public static  class CategoryDictionary
    {
        private static Dictionary<string, List<string>> _dictionary = new Dictionary<string, List<string>>()
        {
            {
                "Electronics", new List<string>{"Mobile phones","Accessories","Computers","TV","Others"}
            },
            {
                "Vehicles", new List<string>{"Cars","Trucks","BIG trucks","Motorcylces","Others"}
            },
            {
                "Estates", new List<string>{ "Sell", "Rent","Buy","Hire","Others"}
            },
            {
                "Pets", new List<string>{"Pets","Pet Food","Others"}
            },
            { 
                "Home and garden", new List<string>{"Furniture","Home accessories","Garden tools","Others"}
            }
        };
        public static Dictionary<string,List<string>> Dictionary{ get { return _dictionary; } }
    }
}
