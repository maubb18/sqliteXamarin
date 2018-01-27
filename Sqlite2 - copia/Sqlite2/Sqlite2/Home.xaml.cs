using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sqlite2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            this.Padding = Device.OnPlatform(new Thickness(10, 20, 10, 10),new Thickness(10),new Thickness(10));

            using (var datos = new DataAccess())
            {
                listaListView.ItemsSource = datos.GetDocente();
            }
            agregarButton.Clicked += AgregarButton_Clicked;
        }

        private async void AgregarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar los nombres", "Aceptar");
                nombresEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar los apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(salarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar el salario", "Aceptar");
                salarioEntry.Focus();
                return;
            }

            var docente = new Docente
            {
                Nombres = nombresEntry.Text,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Salario = decimal.Parse(salarioEntry.Text),
                Doctorado = doctoradoSwitch.IsToggled
            };

            using (var datos = new DataAccess())
            {
                datos.InsertDocente(docente);
                listaListView.ItemsSource = datos.GetDocente();
            }

            nombresEntry.Text = string.Empty;
            apellidosEntry.Text = string.Empty;
            salarioEntry.Text = string.Empty;
            fechaContratoDatePicker.Date = DateTime.Now;
            doctoradoSwitch.IsToggled = true;
            await DisplayAlert("Confirmación!!", " Docente agregado ", "Aceptar");

        }
    }
}