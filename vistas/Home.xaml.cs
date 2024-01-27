namespace kpullopaxiS67.vistas;
using kpullopaxiS67.modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

public partial class Home : ContentPage
{
    private const string Url = "http://127.0.0.1/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiantes> estud;
   
    public Home()
    {
        InitializeComponent();
        Obtener();
    }


    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Estudiantes> mostrarEstudiante = JsonConvert.DeserializeObject<List<Estudiantes>>(content);
        estud = new ObservableCollection<Estudiantes>(mostrarEstudiante);
        listaEstudiante.ItemsSource = estud;


    }



    private void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoestudiante = (Estudiantes)e.SelectedItem;
        Navigation.PushAsync(new actualizarEliminar(objetoestudiante));
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Insertar());
    }
}