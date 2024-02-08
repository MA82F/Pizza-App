using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_App.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        FirebaseClient firebase;
        public event EventHandler<Pizza> CartItemRemoved;
        public event EventHandler<Pizza> CartItemUpdated;
        public event EventHandler CartCleared;
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
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOption = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                var snackbar = Snackbar.Make($"'{item.Name}'removed from cart", () =>
                {
                    Items.Add(item);
                    RecalculateTotalAmount();
                    CartItemUpdated?.Invoke(this, item);
                }, "Undo",TimeSpan.FromSeconds(5),snackbarOption);

                await snackbar.Show();
            }
        }
        [RelayCommand]
        private async Task ClearCart()
        {

            if(await Shell.Current.DisplayAlert("Confirm clear Cart?", "Do you really want to clear the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();

                CartCleared?.Invoke(this, EventArgs.Empty);

                await Toast.Make("Cart cleared", ToastDuration.Short).Show();

            }
        }

        void InitializeFirebase()
        {
            // Initialize Firebase Realtime Database
            var firebaseUrl = "https://pizza-app-d8b8a-default-rtdb.firebaseio.com/"; // Replace with your Firebase URL
            firebase = new FirebaseClient(firebaseUrl);
        }
        [RelayCommand]
        private async Task PlaceOrder()
        {

            InitializeFirebase();


            try
            {
                    await firebase.Child("Orders").PostAsync(Items); // Add new item to Firebase
                    await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
            }
            catch (Exception ex)
            {
                // Handle exceptions while saving data to Firebase
                Console.WriteLine("Error saving data to Firebase: " + ex.Message);
            }
            Items.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();

        }
    }

}
