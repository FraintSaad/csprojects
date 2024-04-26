using CakesLibrary.Models;
using System.Collections.ObjectModel;

namespace CakesBlazor.ViewModels
{
    public class IndexViewModel
    {
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<string> Recipes { get; set; } = new ObservableCollection<string>();
        private Storage _storage;
        private Kitchen _kitchen;
    }
}
