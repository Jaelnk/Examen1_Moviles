namespace MauiApp2.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    // Matriz de usuarios y contraseñas
    private readonly (string user, string pass)[] credentials = new[] {
        ("estudiante", "moviles"),
        ("uisrael", "2024")
    };


    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var user = usuarioEntry.Text?.Trim() ?? "";
        var pass = passwordEntry.Text?.Trim() ?? "";

        // Validar credenciales
        bool valid = credentials.Any(c => c.user == user && c.pass == pass);
        if (!valid)
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            return;
        }

        // Navegar a Registro
       //await Shell.Current.GoToAsync($"/registro?user={Uri.EscapeDataString(user)}");
        await Navigation.PushAsync(new RegistroPage(user));

    }
}