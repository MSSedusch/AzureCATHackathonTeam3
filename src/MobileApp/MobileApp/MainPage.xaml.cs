using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public Dictionary<AssetType, List<Asset>> Assets { get; set; } = new Dictionary<AssetType, List<Asset>>();

        public MainPage()
        {
            InitializeComponent();

            //this.LoadAssetsAsync();

            this.Assets.Add(new AssetType() { Name = "Stock" }, new List<Asset>());

            this.lvAssetTypes.ItemsSource = this.Assets.Keys;
        }

        private async void LoadAssetsAsync()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync($"{Settings.Instance.WebURL}\\asset");

            var assets = JsonConvert.DeserializeObject<List<Asset>>(response);

            foreach (var asset in assets)
            {
                if (!this.Assets.ContainsKey(asset.Type))
                {
                    this.Assets.Add(asset.Type, new List<Asset>());
                }

                this.Assets[asset.Type].Add(asset);
            }
        }

        private void AssetType_Tapped(object sender, EventArgs e)
        {

        }
    }
}
