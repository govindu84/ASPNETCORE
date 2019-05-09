using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Model;

namespace ASPNETCore.ViewModels
{
    public class HomeListViewModel
    {
        public Employee employee { get; set; }
        public string PageTitle { get; set; }
        public string Heading { get; set; }
       
    }
}
