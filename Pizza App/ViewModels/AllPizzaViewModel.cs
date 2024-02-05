using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_App.ViewModels
{
    [QueryProperty(nameof(FromSearch),nameof(FromSearch))]
    public partial class AllPizzaViewModel:ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public AllPizzaViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetAllPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }
        [ObservableProperty]
        private bool _fromSearch;
        [ObservableProperty]
        private bool _searching;
        [RelayCommand]
        private async Task SearchPizzas(string searchTerm)
        {
            Pizzas.Clear();
            Searching = true;
            foreach (var pizza in _pizzaService.SearchPizzas(searchTerm))
            {
                Pizzas.Add(pizza);
            }
            Searching = false;

        }
    }
}
