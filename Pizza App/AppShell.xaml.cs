﻿namespace Pizza_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CartPage),typeof(CartPage));
        }
    }
}
