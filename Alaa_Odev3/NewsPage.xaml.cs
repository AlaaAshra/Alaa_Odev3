using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Alaa_Odev3;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Alaa_Odev3;
using Microsoft.Maui;

namespace Alaa_Odev3
{
    public partial class NewPage : ContentPage
    {
        public NewPage()
        {
            InitializeComponent();
            lstKategori.ItemsSource = Kategori.liste;

            selectedCategory = Kategori.liste[0];
            Load();
        }

        Kategori selectedCategory = null;

        private async void LoadHaberler(object sender, EventArgs e)
        {
            await Load();
            refreshView.IsRefreshing = false;
        }
        private async void OnShareClicked(object sender, EventArgs e)
        {

        }
        public async Task ShareUri(string uri, IShare share)
        {
            await share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,

            });
        }

        private async void OnRefreshClicked(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = true;
            await Load();
            refreshView.IsRefreshing = false;
        }

        async Task Load()
        {
            if (selectedCategory != null)
            {
                string jsondata = await Servisler.HaberleriGetir(selectedCategory);
                if (!string.IsNullOrEmpty(jsondata))
                {
                    var haberler = JsonSerializer.Deserialize<HaberRoot>(jsondata);
                    lstHaberler.ItemsSource = haberler.items;
                }
            }
        }

        private async void lstKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCategory = lstKategori.SelectedItem as Kategori;
            await Load();
        }

        private void lstHaberler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var url = (lstHaberler.SelectedItem as Item)?.link;
            if (url != null)
            {
                NewsDetailPage page = new NewsDetailPage(url);
                Navigation.PushAsync(page);
            }
        }
    }

    public class Kategori
    {
        public string Baslik { get; set; }
        public string Link { get; set; }

        public static List<Kategori> liste = new List<Kategori>()
        {
            new Kategori() { Baslik = "Manşet", Link = "https://www.trthaber.com/manset_articles.rss" },
            new Kategori() { Baslik = "Son Dakika", Link = "https://www.trthaber.com/sondakika_articles.rss" },
            new Kategori() { Baslik = "Gündem", Link = "https://www.trthaber.com/gundem_articles.rss" },
            new Kategori() { Baslik = "Ekonomi", Link = "https://www.trthaber.com/ekonomi_articles.rss" },
            new Kategori() { Baslik = "Spor", Link = "https://www.trthaber.com/spor_articles.rss" },
            new Kategori() { Baslik = "Bilim Teknoloji", Link = "https://www.trthaber.com/bilim_teknoloji_articles.rss" },
            new Kategori() { Baslik = "Güncel", Link = "https://www.trthaber.com/guncel_articles.rss" },

        };
    }

    public class HaberRoot
    {
        public List<Item> items { get; set; }
    }

    public class Enclosure
    {
        public string link { get; set; }
    }

    public class Item
    {
        public string link { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string pubDate { get; set; }
        public Enclosure enclosure { get; set; }
    }

    public static class Servisler
    {
        public static async Task<string> HaberleriGetir(Kategori ctg)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = $"https://api.rss2json.com/v1/api.json?rss_url={ctg.Link}";
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string jsondata = await response.Content.ReadAsStringAsync();
                return jsondata;
            }
            catch
            {
                return null;
            }
        }
    }
}
