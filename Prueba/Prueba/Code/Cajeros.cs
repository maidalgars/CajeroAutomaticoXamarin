using System;
using System.Collections.Generic;
using System.Text;

namespace Cajero.Code
{
    class Cajeros
    {
        List<Billetes> Billetes = new List<Billetes>();

        static private Cajeros cajero;
        private Cajeros()
        {
            //Billetes.Add(new Billetes() { Denominacion = 50000 });
            //Billetes.Add(new Billetes() { Denominacion = 50000 });
            //Billetes.Add(new Billetes() { Denominacion = 20000 });
            //Billetes.Add(new Billetes() { Denominacion = 20000 });
            //Billetes.Add(new Billetes() { Denominacion = 20000 });
            //Billetes.Add(new Billetes() { Denominacion = 20000 });
            //Billetes.Add(new Billetes() { Denominacion = 20000 });
            //Billetes.Add(new Billetes() { Denominacion = 20000 });
            //Billetes.Add(new Billetes() { Denominacion = 10000 });
            //Billetes.Add(new Billetes() { Denominacion = 10000 });
            //Billetes.Add(new Billetes() { Denominacion = 10000 });
            //Billetes.Add(new Billetes() { Denominacion = 10000 });
        }

        static public Cajeros Retcajero() {

            if (cajero == null) {

                cajero = new Cajeros();
            }
            return cajero;
        }

        public List<Billetes> Cantbilletes()
        {
            return Billetes;
        }
        
        public void AddBillete(Int32 intDenominacion, Int32 intCant) {

            for (int i = 0; i < intCant; i++)
            {
                Billetes.Add(new Billetes() { Denominacion = intDenominacion });
            }
        }
        public void RemoveBillete(Int32 intDenominacion)
        {
            Billetes.Remove(new Billetes() { Denominacion = intDenominacion });
        }
    }
}
