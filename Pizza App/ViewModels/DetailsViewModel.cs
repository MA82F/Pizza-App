using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_App.ViewModels
{
    [QueryProperty(nameof(Pizza),nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel) {
            _cartViewModel = cartViewModel;
        }

        [ObservableProperty]
        private Pizza _pizza;

        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
        }
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Pizza.CartQuantity > 0)
            {
                Pizza.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
            }
        }
        [RelayCommand]
        private async Task ViewCart()
        {
            if(Pizza.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage),animate:true);
            }
            else
            {
                await Toast.Make("Please select the quantity using + button", ToastDuration.Short).Show();
            }
        }
    }
}
