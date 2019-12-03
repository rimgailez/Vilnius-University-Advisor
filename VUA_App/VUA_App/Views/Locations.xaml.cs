using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Locations : ContentPage
    {
        public Locations()
        {
            InitializeComponent();
            MyListView.ItemsSource = GetLocationStrings();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Location location = null;
            #region find location clicked
            switch (e.Item)
            {
                case "Sveikatos ir sporto centras":
                    location = new Location(54.726822, 25.327943);
                    break;
                case "Astronomijos observatorija":
                    location = new Location(54.682819, 25.254229);
                    break;
                case "Botanikos sodas":
                    location = new Location(54.736316, 25.402964);
                    break;
                case "Botanikos sodas Vingio skyrius":
                    location = new Location(54.682966, 25.232023);
                    break;
                case "Centriniai rūmai":
                    location = new Location(54.682576, 25.287647);
                    break;
                case "Mokslinės komunikacijos ir informacijos centras":
                    location = new Location(54.722854, 25.328217);
                    break;
                case "Centrinė biblioteka":
                    location = new Location(54.682788, 25.287514);
                    break;
                case "Chemijos fakultetas":
                    location = new Location(54.675856, 25.273508);
                    break;
                case "Komunikacijos fakultetas":
                    location = new Location(54.722141, 25.333184);
                    break;
                case "Ekonomikos fakultetas":
                    location = new Location(54.722034, 25.332141);
                    break;
                case "Istorijos fakultetas":
                    location = new Location(54.683157, 25.287071);
                    break;
                case "Teisės fakultetas":
                    location = new Location(54.722285, 25.332172);
                    break;
                case "Matematikos ir informatikos fakultetas (Naugarduko g.)":
                    location = new Location(54.675099, 25.273872);
                    break;
                case "Matematikos ir informatikos fakultetas (Baltupių g.)":
                    location = new Location(54.729736, 25.263417);
                    break;
                case "Skaitmeninių tyrimų ir skaičiavimo centras (MIF Šaltinių g.)":
                    location = new Location(54.674745, 25.273563);
                    break;
                case "Medicinos fakultetas":
                    location = new Location(54.682847, 25.258616);
                    break;
                case "Gamtos mokslų fakultetas":
                    location = new Location(54.68252, 25.259805);
                    break;
                case "Filologijos fakultetas":
                    location = new Location(54.683186, 25.287742);
                    break;
                case "Filosofijos fakultetas":
                    location = new Location(54.683622, 25.287491);
                    break;
                case "Fizikos fakultetas":
                    location = new Location(54.722145, 25.331106);
                    break;
                case "Tarptautinių santykių ir politikos mokslų institutas":
                    location = new Location(54.67852, 25.284398);
                    break;
                case "Taikomųjų mokslų Institutas":
                    location = new Location(54.721657, 25.332123);
                    break;
                case "Užsienio kalbų institutas":
                    location = new Location(54.683215, 25.287922);
                    break;
                case "Biochemijos institutas":
                    location = new Location(54.753195, 25.263304);
                    break;
                case "Biotechnologijos institutas":
                    location = new Location(54.624332, 25.141378);
                    break;
                case "Matematikos ir informatikos institutas":
                    location = new Location(54.751873, 25.26379);
                    break;
                case "Teorinės fizikos ir astronomijos institutas":
                    location = new Location(54.694592, 25.265104);
                    break;
                case "Vilniaus universiteto Verslo mokykla":
                    location = new Location(54.724911, 25.33622);
                    break;
                case "Duomenų mokslo ir skaitmeninių technologijų institutas":
                    location = new Location(54.751873, 25.26379);
                    break;
                default:
                    return;
            }
            #endregion find location clicked
            await Map.OpenAsync(location, new MapLaunchOptions{ Name = (string) e.Item });

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        ObservableCollection<string> GetLocationStrings()
        {
            return new ObservableCollection<string>
            {
                "Centriniai rūmai",
                "Chemijos fakultetas",
                "Komunikacijos fakultetas",
                "Ekonomikos fakultetas",
                "Istorijos fakultetas",
                "Teisės fakultetas",
                "Matematikos ir informatikos fakultetas (Naugarduko g.)",
                "Matematikos ir informatikos fakultetas (Baltupių g.)",
                "Skaitmeninių tyrimų ir skaičiavimo centras (MIF Šaltinių g.)",
                "Medicinos fakultetas",
                "Gamtos mokslų fakultetas",
                "Filologijos fakultetas",
                "Filosofijos fakultetas",
                "Fizikos fakultetas",
                "Vilniaus universiteto Verslo mokykla",
                "Centrinė biblioteka",
                "Mokslinės komunikacijos ir informacijos centras",
                "Tarptautinių santykių ir politikos mokslų institutas",
                "Taikomųjų mokslų Institutas",
                "Užsienio kalbų institutas",
                "Biochemijos institutas",
                "Biotechnologijos institutas",
                "Teorinės fizikos ir astronomijos institutas",
                "Duomenų mokslo ir skaitmeninių technologijų institutas",
                "Sveikatos ir sporto centras",
                "Astronomijos observatorija",
                "Botanikos sodas",
                "Botanikos sodas Vingio skyrius",
            };
        }
    }
}
