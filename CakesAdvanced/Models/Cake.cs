﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Cake
    {
      public string Name {  get; set; }
      public decimal Price {  get; set; }
      private List<Ingredient> _ingredients = new List<Ingredient>();

        public Cake(string name, List<Ingredient> ingredients) 
        {
            Name = name;
            _ingredients = ingredients;
        }
    }
}
