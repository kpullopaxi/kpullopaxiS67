using System.Net;

namespace kpullopaxiS67.vistas;

public partial class Insertar : ContentPage
{
	public Insertar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            HttpClient cliente = new HttpClient();

            var parametros = new List<KeyValuePair<string, string>>
{
    new KeyValuePair<string, string>("nombre", txtNombre.Text),
    new KeyValuePair<string, string>("apellido", txtApellido.Text),
    new KeyValuePair<string, string>("edad", txtEdad.Text)
};

            var contenido = new FormUrlEncodedContent(parametros);


            var respuesta = cliente.PostAsync("http://127.0.0.1/moviles/post.php", contenido);

            if (!respuesta.IsCompletedSuccessfully)
            {

                Navigation.PushAsync(new Home());

            }
            else
            {

                DisplayAlert("Alerta", "Error en la solicitud", "Cerrar");
            }
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }

    }

 
}