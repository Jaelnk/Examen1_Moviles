namespace MauiApp2.Views;

using Microsoft.Maui.Controls;
public partial class RegistroPage : ContentPage
{

    private const decimal COSTO_TOTAL = 1500m;
    public string Usuario { get; set; }
    public RegistroPage(string usuario)
    {
        InitializeComponent();
        // Cargar lista de países
        paisPicker.ItemsSource = new[] { "Ecuador", "Colombia", "Perú" };
        paisPicker.SelectedIndex = 0;

        // Cargar ciudades (puede mejorarse con diccionario)
        ciudadPicker.ItemsSource = new[] { "Quito", "Guayaquil", "Cuenca" };
        ciudadPicker.SelectedIndex = 0;

        Usuario = usuario;

        usuarioLabel.Text = $"Usuario conectado: {usuario}";

    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        if (!decimal.TryParse(montoInicialEntry.Text, out var inicial) || inicial < 0)
        {
            await DisplayAlert("Error", "Ingrese un monto inicial válido.", "OK");
            return;
        }

        if (inicial >= COSTO_TOTAL)
        {
            await DisplayAlert("Error", $"El monto inicial debe ser menor a {COSTO_TOTAL:F2}.", "OK");
            return;
        }

        // Calcular saldo restante
        var resto = COSTO_TOTAL - inicial;
        // 4 cuotas con 4% adicional sobre cada cuota
        var cuotaBase = resto / 4;
        var costoAdicional = COSTO_TOTAL * 0.04m;
        var cuotaConInteres = cuotaBase + costoAdicional;
        pagoMensualEntry.Text = cuotaConInteres.ToString("F2"); 

 
    }

    private async void VerResumen_Clicked(object sender, EventArgs e)
    {
        var nombre = nombreEntry.Text?.Trim() ?? string.Empty;
        var apellido = apellidoEntry.Text?.Trim() ?? string.Empty;
        //var edad = edadEntry.Text?.Trim() ?? string.Empty;
        var fecha = fechaPicker.Date;
        var pais = paisPicker.SelectedItem?.ToString() ?? string.Empty;
        var ciudad = ciudadPicker.SelectedItem?.ToString() ?? string.Empty;
        var inicial = decimal.TryParse(montoInicialEntry.Text, out var m) ? m : 0m;
        var pagoMensual = decimal.TryParse(pagoMensualEntry.Text, out var p) ? p : 0m;

        var edadText = edadEntry.Text?.Trim() ?? string.Empty;
        if (!int.TryParse(edadText, out int edad) || edad <= 18 || edad > 80)
        {
            await DisplayAlert("Error", "Ingrese una edad válida mayor que 18.", "OK");
            return;
        }

        await Navigation.PushAsync(new ResumenPage(Usuario, nombre, apellido, edadText,
                                              fecha, pais, ciudad,
                                              inicial, pagoMensual));

    }
}