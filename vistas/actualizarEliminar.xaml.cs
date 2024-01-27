using kpullopaxiS67.modelos;
using System.Net;

namespace kpullopaxiS67.vistas;

public partial class actualizarEliminar : ContentPage
{
	public actualizarEliminar(Estudiantes datos)
	{
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
        txtCodigo.IsEnabled = false;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;

            string url = "http://127.0.0.1/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;

            HttpClient cliente = new HttpClient();

            var parametros = new List<KeyValuePair<string, string>>
                    {
                            new KeyValuePair<string, string>("codigo", codigo),
                            new KeyValuePair<string, string>("nombre", nombre),
                            new KeyValuePair<string, string>("apellido", apellido),
                            new KeyValuePair<string, string>("edad", edad)
                         };

            var contenido = new FormUrlEncodedContent(parametros);

            var respuesta = cliente.PutAsync(url, contenido);

            if (!respuesta.IsCompletedSuccessfully)
            {
                Navigation.PushAsync(new Home());
            }
            else
            {
                DisplayAlert("ERROR", "Error en la solicitud", "CERRAR");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;

            string url = "http://127.0.0.1/moviles/post.php?codigo=" + codigo;

            HttpClient cliente = new HttpClient();

            var respuesta = cliente.DeleteAsync(url);

            if (respuesta.IsCompletedSuccessfully)
            {
                DisplayAlert("ERROR", "Error en la solicitud", "CERRAR");

            }
            else
            {
                Navigation.PushAsync(new Home());

            }
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }

    }
}