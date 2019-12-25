using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri_20.Models;

namespace C_Bageri_20.ViewModels
{
    // vy som skapar data till hemsidan
    public class HomeViewModel
    {
        public IEnumerable<Product> Lista { get; set; }
    }
}
