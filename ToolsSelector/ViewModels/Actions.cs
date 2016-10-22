using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ToolsSelector.Models;

namespace ToolsSelector.ViewModels
{
    public class  Actions /*: INotifyPropertyChanged*/
    {
        //public List<Tool> Tools { get; set; }

        //public Actions()
        //{
        //    this.G = new List<Tool>();
        //}

        public List<Tool> X
        {
            get;
            private set;
        }

        //private Country _selectedCountry
        //{
        //    get
        //    {
        //        return _selectedCountry;
        //    }
        //    set
        //    {
        //        _selectedCountry = value;
        //        /* WARNING: The following code causes the CollectionChanged 
        //             event to get fired multiple times! */
        //        this.Cities.Clear();
        //        foreach (City city in _selectedCountry.Cities)
        //            this.Cities.Add(city);
        //    }
        //}
    }
}
