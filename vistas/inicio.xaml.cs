using kpullopaxiS67.modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace kpullopaxiS67.vistas;

public partial class inicio : ContentPage
{
    private const string Url = "http://172.28.64.1:8080/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiantes> estud;

    public inicio()
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

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new agregar());

    }

    private void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoestudiante = (Estudiantes)e.SelectedItem;
        Navigation.PushAsync(new actualizarEliminar(objetoestudiante));
    }
}