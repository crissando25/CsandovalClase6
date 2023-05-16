using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CsandovalClase6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarRegistro : ContentPage
    {
        public ActualizarRegistro()
        {
            InitializeComponent();
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e, string urlRequest)
        {       
            HttpClient client = new HttpClient();
            var content = new DatosRequest
            {
                id = Convert.ToInt32(txtTbl_jz_id.Text),
                tbl_jz_nombre = txttbl_jz_nombre.Text,
                tbl_jz_grupo_t = txttbl_jz_grupo_t.Text,
                tbl_g_observaciones = txttbl_g_observaciones.Text,
            };
            string jsonData = JsonConvert.SerializeObject(content);
            var vehicleRequest = new StringContent(jsonData, Encoding.UTF8, "application/json");*/
            string urlRequest; = $"{"http://192.168.1.26/moviles/post.php"}?id={content.id}&Nombre={content.tbl_jz_nombre}&Grupo={content.tbl_jz_grupo_t}&observaciones={content.tbl_g_observaciones};
            var response = await client.PutAsync(urlRequest, null); //vehicleRequest si usamos content en el servicio php
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync();
                await DisplayAlert("Éxito!", "Se actualizó la información", "Aceptar");
                await Navigation.PushAsync(new MainPage());
            }
            else
                await DisplayAlert("Error!", "No se pudo actualizar la información", "Aceptar");

        }


    }
}