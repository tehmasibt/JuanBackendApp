﻿using JuanBackendApp.Models;

namespace JuanBackendApp.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Setting> Settings { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
