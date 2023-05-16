 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CsandovalClase6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }
        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //CREAR UNA VARIABLE TIPO WET CLACEAN
                WebClient cliente = new WebClient();
                //varuable que almacene los datos
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("ID  ", txtTbl_jz_id.Text);
                parametros.Add("Nombre", txttbl_jz_nombre.Text);
                parametros.Add("Grupo", txttbl_jz_grupo_t.Text);          
            //esta variable se coinecta para el envio de los datos
            cliente.UploadValues("http://192.168.1.26/moviles/post.php", "POST", parametros);
            DisplayAlert("Alerta", "dato ingresado", "cerrar");
            txtTbl_jz_id.Text = "";
            txttbl_jz_nombre.Text = "";
            txttbl_jz_grupo_t.Text = "";
            
        }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "CERRAR");
    }
}

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }
    }
}
