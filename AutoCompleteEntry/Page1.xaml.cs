using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoCompleteEntry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1(string nombre1,string nacionalidad1,string telf1,string  correo1,string ocupacion1,string nivel1)
        {
            InitializeComponent();
            nombre.Text = nombre1;
            nacionalidadd.Text = nacionalidadd.Text + nacionalidad1;
            telf.Text = telf1;
            correo.Text = correo1;
            ocupacion.Text = ocupacion1;
            nivel.Text= nivel.Text+nivel1;





        }
    }
}