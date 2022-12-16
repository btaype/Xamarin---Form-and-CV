using dotMorten.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;
using System.Threading.Tasks;


namespace AutoCompleteEntry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    { 
        private List<string> CountriesList;
        public string datos;
        public MainPage()
        {
            
            InitializeComponent();
            GetCountriesFromFile();
        }
       
        
        void ButtonSubmitClicked(object sender, EventArgs e)
        {
            string nombre1 = nombre.Text;
            string nacionalidad1 = nacionalidad.SelectedItem as string;
            string telf1 = telf.Text;
            string correo1 = email.Text;
            string ocupacion1 = ocupacion.Text;
            string nivel = datos;
            


            Application.Current.MainPage.Navigation.PushModalAsync(new Page1(nombre1, nacionalidad1,telf1,correo1,ocupacion1,nivel),true);
        }
        private void GetCountriesFromFile()
        {
            using(var country = typeof(MainPage).Assembly.GetManifestResourceStream("AutoCompleteEntry.Data.Countries.txt"))
            {   

                CountriesList = new StreamReader(country).ReadToEnd().Split('\n').Select(t => t.Trim()).ToList();
            }
        }

        private void contryEntry_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            AutoSuggestBox input = (AutoSuggestBox)sender;

            input.ItemsSource = GetSuggestions(input.Text);
        }

        private List<string> GetSuggestions(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? null : CountriesList.Where(c => c.StartsWith(input, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        private void contryEntry_QuerySubmitted(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {
           
        }
         public void seleccion(object sender,EventArgs args)
        {
            RadioButton rad = sender as RadioButton;
            datos = rad.Content as string;
          
        }
    }
}
