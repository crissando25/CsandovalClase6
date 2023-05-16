using System;
using System.Collections.Generic;
using System.Linq;
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

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {       
            HttpClient client = new HttpClient();
            var content = new DatosRequest
            {
                id = Convert.ToInt32(text.Text),
               brand = TxtMarca.Text,
                model = TxtModelo.Text,
                year = Convert.ToInt32(TxtAnio.Text),
                plate = TxtPlaca.Text,
                color = TxtColor.Text,
            };
            string jsonData = JsonConvert.SerializeObject(content);
            var vehicleRequest = new StringContent(jsonData, Encoding.UTF8, "application/json");*/
            string urlRequest = $"{Url}?id={content.id}&brand={content.brand}&model={content.model}&year={content.year}&plate={content.plate}&color={content.color}";
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