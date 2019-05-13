using Cajero.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cajero
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminBilletes : ContentPage
    {
        public AdminBilletes()
        {
            InitializeComponent();
        }

        protected void btnGuardar_click(object sender, EventArgs e)
        {
            Int32 intCantidad = 0;
            Int32 intValor = 0;
            Cajeros cajero = Cajeros.Retcajero();

            if (txtCantidad.Text == null)
            {
                DisplayAlert("Administrador", "Ingrese la cantidad de billetes.", "Aceptar");
                return;
            }
            else if (txtValor.Text == null)
            {
                DisplayAlert("Administrador", "Ingrese la denominación del billetes.", "Aceptar");
                return;
            }
            else
            {
                intCantidad = Int32.Parse(txtCantidad.Text);
                intValor = Int32.Parse(txtValor.Text);     
                cajero.AddBillete(intValor, intCantidad);
            }
            //Muestra la lista de billetes correspondiente
            Resources["Admin"] = cajero.Cantbilletes();
            //lstAdmin.ItemsSource = cajero.Cantbilletes();


        }
    }
}