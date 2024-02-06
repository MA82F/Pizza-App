using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_App.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public ObservableCollection<Pizza> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(i => i.Name == pizza.Name);
            if (item != null)
            {
                item.CartQuantity = pizza.CartQuantity;
            }
            else
            {
                Items.Add(pizza.Clone());
            }
            RecalculateTotalAmount();
        }
        [RelayCommand]
        private void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();
            }
        }
        [RelayCommand]
        private async Task ClearCart()
        {

            if(await Shell.Current.DisplayAlert("Confirm clear Cart?", "Do you really want to clear the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                await Toast.Make("Cart cleared", ToastDuration.Short).Show();

            }
        }
        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            RecalculateTotalAmount();
            //go to check out page
        }
    }

}
