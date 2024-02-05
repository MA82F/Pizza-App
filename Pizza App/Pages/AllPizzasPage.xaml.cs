namespace Pizza_App.Pages;

public partial class AllPizzasPage : ContentPage
{
	private readonly AllPizzaViewModel _allPizzaViewModel;

    public AllPizzasPage(AllPizzaViewModel allPizzaViewModel)
	{
        InitializeComponent();
        _allPizzaViewModel = allPizzaViewModel;
        BindingContext = _allPizzaViewModel;
	}
}