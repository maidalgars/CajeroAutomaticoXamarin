using Cajero.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cajero
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class DispensarBilletes : ContentPage
    {

        public DispensarBilletes()
        {
            InitializeComponent();
        }

        protected void btnRetirar_click(object sender, EventArgs e)
        {

            int MontoRetiro = 0;
            //Valida que el campo contenga el valor
            if (txtRetirar.Text == null)
            {
                DisplayAlert("Administrar", "Ingrese el valor de billetes.", "Aceptar");
                return;
            }
            else
            {
                MontoRetiro = Int32.Parse(txtRetirar.Text.ToString());
                Cajeros cajero = Cajeros.Retcajero();
                cajero.Cantbilletes();

                Int64 nuevoMonto = 0;
                List<Billetes> BilletesRetirados = new List<Billetes>();

                foreach (var billete in cajero.Cantbilletes().OrderByDescending(b => b.Denominacion).ToList())
                {
                    if (billete.Denominacion <= (MontoRetiro - nuevoMonto))
                    {
                        BilletesRetirados.Add(billete);
                        nuevoMonto += billete.Denominacion;
                    }
                }

                if (nuevoMonto < MontoRetiro)
                    throw new Exception("El cajero no tiene billetes para el valor de billetes solicitado.");
                else if (nuevoMonto == MontoRetiro)
                {
                    foreach (var billete in BilletesRetirados)
                    {
                        //cajero.Cantbilletes().Remove(billete);
                        cajero.RemoveBillete(Int32.Parse(billete.Denominacion.ToString()));
                    }
                }
                //Muestra la lista de billetes correspondiente
                Resources["Billetes"] = BilletesRetirados;
            }
           
        }
    }
}

