namespace notes.ui.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //link para abrir sites em butim
        //await Launcher.Default.OpenAsync("https://aka.ms/maui");
        if (BindingContext is Models.Sobre sobre)
        {
            await Launcher.Default.OpenAsync(sobre.MoreInfoURL);

        }
    }

}