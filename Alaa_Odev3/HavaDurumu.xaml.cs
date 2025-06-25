using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Alaa_Odev3;

public partial class HavaDurumu : ContentPage
{
    public ObservableCollection<SehirHavaDurumu> Sehirler { get; set; }
    public ICommand DeleteCommand { get; }

    public HavaDurumu()
    {
        InitializeComponent();
        Sehirler = new ObservableCollection<SehirHavaDurumu>();
        CitiesCollectionView.ItemsSource = Sehirler;

        DeleteCommand = new Command<SehirHavaDurumu>(OnDelete);
        BindingContext = this;
    }

    private async void addClicked(object sender, EventArgs e)
    {
        string sehir = await DisplayPromptAsync("Şehir:", "Şehir ismi", "Tamam", "Vazgeç");

        if (!string.IsNullOrWhiteSpace(sehir))
        {
            sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);

            sehir = sehir.Replace('Ç', 'C');
            sehir = sehir.Replace('Ğ', 'G');
            sehir = sehir.Replace('İ', 'I');
            sehir = sehir.Replace('Ö', 'O');
            sehir = sehir.Replace('Ü', 'U');
            sehir = sehir.Replace('Ş', 'S');

            Sehirler.Add(new SehirHavaDurumu() { Name = sehir });
        }
    }

    private void OnDelete(SehirHavaDurumu sehirHavaDurumu)
    {
        if (sehirHavaDurumu != null && Sehirler.Contains(sehirHavaDurumu))
        {
            Sehirler.Remove(sehirHavaDurumu);
        }
    }

    private void refClicked(object sender, EventArgs e)
    {

        var updatedSehirler = new ObservableCollection<SehirHavaDurumu>(Sehirler);
        Sehirler.Clear();
        foreach (var sehir in updatedSehirler)
        {
            Sehirler.Add(sehir);
        }
        CitiesCollectionView.ItemsSource = Sehirler;
    }
}

public class SehirHavaDurumu
{
    public string Name { get; set; }
    public string Source => $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={Name}&basla=1&bitir=5&rC=111&rZ=fff";
}
