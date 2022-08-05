using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppConvertidorU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Convertidor : ContentPage
    {
        double cm;
        double m;
        double cambio;
        //tasas respecto al dolar
        double[] valorDolar = new double[] {1.00, 0.98, 4306.00, 20.33, 3.90};
        double[] valorEuro = new double[] { 1.02, 1, 4407.77, 20.81, 3.99 };
        int indexInicial;
        int indexfinal;
        double operacionResuelta;
        public Convertidor()
        {
            InitializeComponent();
        }

        private double operacionesDolar(double cambio, int indexfinal)
        {
            
            if (indexfinal == 0)
            {
                cambio = cambio * valorDolar[SeleccionaMonedaFinal.SelectedIndex];
            }
            else if (indexfinal == 1)
            {
                cambio = cambio * valorDolar[indexfinal];
            }
            else if (indexfinal == 2)
            {
                cambio = cambio * valorDolar[indexfinal];
            }
            else if (indexfinal == 3)
            {
                cambio = cambio * valorDolar[indexfinal];
            }
            else if (indexfinal == 4)
            {
                cambio = cambio * valorDolar[indexfinal];
            }

            return cambio;
        }
        private double oprecionMonedaOther(double cambio, int indexfinal, int indexinicial)
        {
            cambio = cambio * (1 / valorDolar[indexInicial]) * valorDolar[indexfinal];
            //cambio = Convert.ToDouble(txtcm.Text);
            return cambio;
        }
        public void Calcular()
        {
            indexInicial = SeleccionaMonedaInicial.SelectedIndex;
            indexfinal = SeleccionaMonedaFinal.SelectedIndex;

            cambio = Convert.ToDouble(txtcm.Text);

            //de dolar a euro
            if (indexInicial == 0)
            {
                //es dolar                
                operacionResuelta = operacionesDolar(cambio, indexfinal);
            } else
            {
                operacionResuelta = oprecionMonedaOther(cambio, indexfinal, indexInicial);
            }
            string moneda = SeleccionaMonedaFinal.SelectedItem as String;
            reslbl.Text = operacionResuelta.ToString() +" "+ moneda;
        }
        

        private void validar()
        {
            if (!string.IsNullOrEmpty(txtcm.Text))
            {
                Calcular();
            }else
            {
                DisplayAlert("Error", "Ingrese una cantidad", "OK");    
            }
        }

        private void btnVolver_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            if(SeleccionaMonedaInicial.SelectedIndex==-1 || SeleccionaMonedaFinal.SelectedIndex == -1)
            {
                DisplayAlert("Conversion", "Seleccione Tipo de Modenas", "Ok");
                return;
            }
            //string moneda = SeleccionaMonedaFinal.SelectedItem as String;
            validar();
        }
    }
}