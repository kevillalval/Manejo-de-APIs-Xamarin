using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppManejoAPIs.Paginas.ConsumeAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAPI : ContentPage
    {
        public PageAPI()
        {
            InitializeComponent();
        }

        //private string Url = "http://192.168.100.7:3000/estudiantes";
        private string Url = "https://estudiante.fly.dev/estudiantes";


        private Models.Estudiantes[] Estudiantes { get; set; }

        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = new
    RemoteCertificateValidationCallback
    (
       delegate { return true; }
    );
                wc.Headers.Add("Content-Type", "application/json");
                var json = wc.DownloadString(Url + "/" + txtId.Text);
                var estudiantes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Estudiantes>>(json);

                if (estudiantes != null && estudiantes.Count > 0)
                {
                    var estudiante = estudiantes[0]; // Obtén el primer estudiante del arreglo
                    txtId.Text = estudiante.id_estudiante.ToString();
                    txtCedula.Text = estudiante.cedula;
                    txtNombres.Text = estudiante.nombres;
                    txtApellidos.Text = estudiante.apellidos;
                    txtEmail.Text = estudiante.email;
                    txtNivel.Text = estudiante.nivel.ToString();
                    txtMateria1.Text = estudiante.materias;
                    txtMateria2.Text = estudiante.materia2;
                }
                else
                {
                    txtId.Text = "";
                    txtCedula.Text = "";
                    txtNombres.Text = "";
                    txtApellidos.Text = "";
                    txtEmail.Text = "";
                    txtNivel.Text = "";
                    txtMateria1.Text = "";
                    txtMateria2.Text = "";
                }
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = new
    RemoteCertificateValidationCallback
    (
       delegate { return true; }
    );
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Estudiantes
                {
                    id_estudiante = txtId.Text,
                    cedula = txtCedula.Text,
                    nombres = txtNombres.Text,
                    apellidos = txtApellidos.Text,
                    email = txtEmail.Text,
                    nivel = int.Parse(txtNivel.Text),
                    materias = txtMateria1.Text,
                    materia2 = txtMateria2.Text
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Url, "POST", json);
                lblDatos.Text = "DATOS INSERTADOS CON EXITO !!";
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = new
    RemoteCertificateValidationCallback
    (
       delegate { return true; }
    );
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Estudiantes
                {
                    id_estudiante = txtId.Text,
                    cedula = txtCedula.Text,
                    nombres = txtNombres.Text,
                    apellidos = txtApellidos.Text,
                    email = txtEmail.Text,
                    nivel = int.Parse(txtNivel.Text),
                    materias = txtMateria1.Text,
                    materia2 = txtMateria2.Text
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Url + "/" + txtId.Text, "PUT", json);
                lblDatos.Text = "DATOS ACTUALIZADOS CON ÉXITO";

            }
        }
        private void Button_Clicked_3(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback = new
    RemoteCertificateValidationCallback
    (
       delegate { return true; }
    );
                wc.Headers.Add("Content-Type", "application/json");
                wc.UploadString(Url + "/" + txtId.Text, "DELETE", "");
                lblDatos.Text = "DATOS BORRADOS CON ÉXITO";

                txtId.Text = "";
                txtCedula.Text = "";
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtEmail.Text = "";
                txtNivel.Text = "";
                txtMateria1.Text = "";
                txtMateria2.Text = "";
            }
        }
    }
}