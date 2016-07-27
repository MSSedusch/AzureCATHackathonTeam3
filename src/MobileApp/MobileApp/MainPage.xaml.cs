using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public Dictionary<AssetType, List<Asset>> Assets { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoadAssets()
        {
            //WebClient
        }
    }
}
