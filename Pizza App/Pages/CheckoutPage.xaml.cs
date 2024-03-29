namespace Pizza_App.Pages;

public partial class CheckoutPage : ContentPage
{
    public CheckoutPage()
	{
		InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        img.ScaleTo(1.5);
        msg.ScaleTo(1);

        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(1);

        homebtn.FadeTo(1,length:500);
        await homebtn.ScaleTo(1);
    }

    private async void homebtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}",animate:true);
    }
}