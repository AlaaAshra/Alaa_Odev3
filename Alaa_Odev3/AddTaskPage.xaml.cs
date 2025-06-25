using Alaa_Odev3.Model;
using System.Formats.Tar;


namespace Alaa_Odev3
{
    public partial class AddTaskPage : ContentPage
    {
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private async void tamamClicked(object sender, EventArgs e)
        {

            string taskName = taskEntry.Text;
            string taskDetail = taskEditor.Text;
            DateTime taskDate = taskDatePicker.Date;
            TimeSpan taskTime = taskTimePicker.Time;


            MessagingCenter.Send(this, "AddTask", new TaskItem
            {
                Name = taskName,
                Detail = taskDetail,
                Date = taskDate,
                Time = taskTime
            });

            await DisplayAlert("Tamam", "Görev başarıyla kaydedildi", "Tamam");
            await Navigation.PopAsync();
        }

        private async void iptalClicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }
    }
}
