using Newtonsoft.Json;

using static Alaa_Odev3.KurItem;

namespace Alaa_Odev3;


public partial class Doviz : ContentPage
{

    public Doviz()
    {
        InitializeComponent();
    }

    private static Doviz instance;
    public static Doviz page
    {
        get
        {
            if (instance == null)
                instance = new Doviz();
            return instance;
        }
    }
    private async void LoadHaberler(object sender, EventArgs e)
    {
        await Load();
        refreshView.IsRefreshing = false;
    }
    private async void OnRefreshClicked(object sender, EventArgs e)
    {
        refreshView.IsRefreshing = true;
        await Load();
        refreshView.IsRefreshing = false;
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await Load();
    }

    AltinDoviz kurlar;
    async Task Load()
    {

        string jsondata = await GetAltinDovizGuncelKurlar();
        kurlar = JsonConvert.DeserializeObject<AltinDoviz>(jsondata);





        dovizliste.ItemsSource = new List<KurItem>()
        {
            new KurItem()
            {
                Doviz = "Dolar",
                Alis = kurlar.USD.Alis,
                Satis = kurlar.USD.Satis,
                Fark = kurlar.USD.Degisim,
                Yon = GetImage(kurlar.USD.Degisim),

            },

             new KurItem()
            {
                Doviz = "Euro",
                Alis = kurlar.EUR.Alis,
                Satis = kurlar.EUR.Satis,
                Fark = kurlar.EUR.Degisim,
                Yon = GetImage(kurlar.EUR.Degisim),

            },

              new KurItem()
            {
                Doviz = "GBP",
                Alis = kurlar.GBP.Alis,
                Satis = kurlar.GBP.Satis,
                Fark = kurlar.GBP.Degisim,
                Yon = GetImage(kurlar.GBP.Degisim),

            },

               new KurItem()
            {
                Doviz = "QAR",
                Alis = kurlar.QAR.Alis,
                Satis = kurlar.QAR.Satis,
                Fark = kurlar.QAR.Degisim,
                Yon = GetImage(kurlar.QAR.Degisim),

            },

                new KurItem()
            {
                Doviz = "SAR",
                Alis = kurlar.SAR.Alis,
                Satis = kurlar.SAR.Satis,
                Fark = kurlar.SAR.Degisim,
                Yon = GetImage(kurlar.USD.Degisim),

            },

                 new KurItem()
            {
                Doviz = "EGP",
                Alis = kurlar.EGP.Alis,
                Satis = kurlar.EGP.Satis,
                Fark = kurlar.EGP.Degisim,
                Yon = GetImage(kurlar.EGP.Degisim),

            },

                  new KurItem()
            {
                Doviz = "JPY",
                Alis = kurlar.JPY.Alis,
                Satis = kurlar.JPY.Satis,
                Fark = kurlar.JPY.Degisim,
                Yon = GetImage(kurlar.JPY.Degisim),

            },

                   new KurItem()
            {
                Doviz = "CHF",
                Alis = kurlar.CHF.Alis,
                Satis = kurlar.CHF.Satis,
                Fark = kurlar.CHF.Degisim,
                Yon = GetImage(kurlar.CHF.Degisim),

            },

                   new KurItem()
            {
                Doviz = "KWD",
                Alis = kurlar.KWD.Alis,
                Satis = kurlar.KWD.Satis,
                Fark = kurlar.KWD.Degisim,
                Yon = GetImage(kurlar.KWD.Degisim),

            },

                   new KurItem()
            {
                Doviz = "ZAR",
                Alis = kurlar.ZAR.Alis,
                Satis = kurlar.ZAR.Satis,
                Fark = kurlar.ZAR.Degisim,
                Yon = GetImage(kurlar.ZAR.Degisim),

            },

                   new KurItem()
            {
                Doviz = "BHD",
                Alis = kurlar.BHD.Alis,
                Satis = kurlar.BHD.Satis,
                Fark = kurlar.BHD.Degisim,
                Yon = GetImage(kurlar.BHD.Degisim),

            },

                   new KurItem()
            {
                Doviz = "ILS",
                Alis = kurlar.ILS.Alis,
                Satis = kurlar.ILS.Satis,
                Fark = kurlar.ILS.Degisim,
                Yon = GetImage(kurlar.ILS.Degisim),

            },

                   new KurItem()
            {
                Doviz = "LYD",
                Alis = kurlar.LYD.Alis,
                Satis = kurlar.LYD.Satis,
                Fark = kurlar.LYD.Degisim,
                Yon = GetImage(kurlar.LYD.Degisim),

            },

                   new KurItem()
            {
                Doviz = "NOK",
                Alis = kurlar.NOK.Alis,
                Satis = kurlar.NOK.Satis,
                Fark = kurlar.NOK.Degisim,
                Yon = GetImage(kurlar.NOK.Degisim),

            },







        };

    }

    private string GetImage(string str)
    {


        if (str.Contains('-'))
            return "down.png";
        if (str.Equals("%0,00"))
            return "next.png";

        return "up.png";


    }

    private async Task<string> GetAltinDovizGuncelKurlar()
    {
        HttpClient client = new HttpClient();
        string url = "https://finans.truncgil.com/today.json";
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string jsondata = await response.Content.ReadAsStringAsync();
        return jsondata;


    }
}


public class KurItem
{
    public string Doviz { get; set; }
    public string Alis { get; set; }
    public string Satis { get; set; }
    public string Fark { get; set; }
    public string Yon { get; set; }
}

public class AltinDoviz
{
    public string Update_Date { get; set; }
    public Currency USD { get; set; }
    public Currency EUR { get; set; }
    public Currency GBP { get; set; }
    public Currency CHF { get; set; }
    public Currency CAD { get; set; }
    public Currency RUB { get; set; }
    public Currency AED { get; set; }
    public Currency AUD { get; set; }
    public Currency DKK { get; set; }
    public Currency SEK { get; set; }
    public Currency NOK { get; set; }
    public Currency JPY { get; set; }
    public Currency KWD { get; set; }
    public Currency ZAR { get; set; }
    public Currency BHD { get; set; }
    public Currency LYD { get; set; }
    public Currency SAR { get; set; }
    public Currency IQD { get; set; }
    public Currency ILS { get; set; }
    public Currency IRR { get; set; }
    public Currency INR { get; set; }
    public Currency MXN { get; set; }
    public Currency HUF { get; set; }
    public Currency NZD { get; set; }
    public Currency BRL { get; set; }
    public Currency IDR { get; set; }
    public Currency CZK { get; set; }
    public Currency PLN { get; set; }
    public Currency RON { get; set; }
    public Currency CNY { get; set; }
    public Currency ARS { get; set; }
    public Currency ALL { get; set; }
    public Currency AZN { get; set; }
    public Currency BAM { get; set; }
    public Currency CLP { get; set; }
    public Currency COP { get; set; }
    public Currency CRC { get; set; }
    public Currency DZD { get; set; }
    public Currency EGP { get; set; }
    public Currency HKD { get; set; }
    public Currency ISK { get; set; }
    public Currency HRK { get; set; }
    public Currency JOD { get; set; }
    public Currency KRW { get; set; }
    public Currency KZT { get; set; }
    public Currency LBP { get; set; }
    public Currency LKR { get; set; }
    public Currency MAD { get; set; }
    public Currency MDL { get; set; }
    public Currency MKD { get; set; }
    public Currency MYR { get; set; }
    public Currency OMR { get; set; }
    public Currency PEN { get; set; }
    public Currency PHP { get; set; }
    public Currency PKR { get; set; }
    public Currency QAR { get; set; }
    public Currency RSD { get; set; }
    public Currency SGD { get; set; }
    public Currency SYP { get; set; }
    public Currency THB { get; set; }
    public Currency TWD { get; set; }
    public Currency UAH { get; set; }
    public Currency UYU { get; set; }
    public Currency GEL { get; set; }
    public Currency TND { get; set; }
    public Currency BGN { get; set; }
    public GoldCurrency ons { get; set; }
    public GoldCurrency gram_altin { get; set; }
    public GoldCurrency gram_has_altin { get; set; }
    public GoldCurrency ceyrek_altin { get; set; }
    public GoldCurrency yarim_altin { get; set; }
    public GoldCurrency tam_altin { get; set; }
    public GoldCurrency cumhuriyet_altini { get; set; }
    public GoldCurrency ata_altin { get; set; }
    public GoldCurrency on_dort_ayar_altin { get; set; }
    public GoldCurrency on_sekiz_ayar_altin { get; set; }
    public GoldCurrency yirmi_iki_ayar_bilezik { get; set; }
    public GoldCurrency ikibucuk_altin { get; set; }
    public GoldCurrency besli_altin { get; set; }
    public GoldCurrency gremse_altin { get; set; }
    public GoldCurrency resat_altin { get; set; }
    public GoldCurrency hamit_altin { get; set; }
    public GoldCurrency gumus { get; set; }
}

public class Currency
{
    [JsonProperty("Alış")]
    public string Alis { get; set; }
    [JsonProperty("Tür")]
    public string Tur { get; set; }
    [JsonProperty("Satış")]
    public string Satis { get; set; }
    [JsonProperty("Değişim")]
    public string Degisim { get; set; }
}

public class GoldCurrency
{
    [JsonProperty("Alış")]
    public string Alis { get; set; }
    [JsonProperty("Tür")]
    public string Tur { get; set; }
    [JsonProperty("Satış")]
    public string Satis { get; set; }
    [JsonProperty("Değişim")]
    public string Degisim { get; set; }
}