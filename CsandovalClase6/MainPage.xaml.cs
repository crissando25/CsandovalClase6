using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace CsandovalClase6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.26/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<CsandovalClase6.ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
            Obtener();
        }

        public  async void Obtener()
        {
            var content = await client.GetStringAsync(Url);
            List<CsandovalClase6.ws.Datos> posts = JsonConvert.DeserializeObject<List<CsandovalClase6.ws.Datos>>(content);
            _post = new ObservableCollection<CsandovalClase6.ws.Datos>(posts);
          lista.ItemsSource = _post;   

        }
        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }
        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {            
            await Navigation.PushAsync(new ActualizarRegistro());
           
        }
    }

    
}
