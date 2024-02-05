using Pizza_App.Services;
using System.Collections.ObjectModel;
using Pizza_App.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pizza_App.ViewModels
{
    public partial class HomeViewModel: ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public HomeViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }
    }
}
