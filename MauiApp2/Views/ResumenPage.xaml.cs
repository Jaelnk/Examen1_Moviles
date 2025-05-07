namespace MauiApp2.Views;

public partial class ResumenPage : ContentPage
{
    public ResumenPage()
	{
		InitializeComponent();
    }


    public ResumenPage(string usuario,
                       string nombre, string apellido, string edad,
                       DateTime fecha, string pais, string ciudad,
                       decimal montoInicial, decimal pagoMensual)
    {
        InitializeComponent();
        usuarioLabel.Text = $"Usuario conectado: {usuario}";

        // Asignar valores a labels
        nombreLabel.Text = nombre;
        apellidoLabel.Text = apellido;
        edadLabel.Text = edad;
        fechaLabel.Text = fecha.ToString("d");
        paisLabel.Text = pais;
        ciudadLabel.Text = ciudad;
        montoInicialLabel.Text = montoInicial.ToString("F2");
        pagoMensualLabel.Text = pagoMensual.ToString("F2");
        // Calcular pago total (4 cuotas)
        var pagoTotal = montoInicial + (pagoMensual * 4);
        pagoTotalLabel.Text = pagoTotal.ToString("F2");
    }

    
}