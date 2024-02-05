

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
        [RelayCommand]
        private async Task GoToAllPizzasPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object> {
                [nameof(AllPizzaViewModel.FromSearch)] = fromSearch
        };
            await Shell.Current.GoToAsync(nameof(AllPizzasPage), animate:true,parameters);
        }
    }
}
