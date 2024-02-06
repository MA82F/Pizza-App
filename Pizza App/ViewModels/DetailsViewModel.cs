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
        public DetailsViewModel() { 

        }

        [ObservableProperty]
        private Pizza _pizza;

        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuantity++;
        }
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Pizza.CartQuantity > 0)
            {
                Pizza.CartQuantity--;
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
