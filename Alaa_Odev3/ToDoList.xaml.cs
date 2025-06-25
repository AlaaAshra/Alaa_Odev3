using Alaa_Odev3.Model;
using System.Collections.ObjectModel;

namespace Alaa_Odev3
{
    public partial class ToDoList : ContentPage
    {
        private ObservableCollection<TaskItem> tasks;

        public ToDoList()
        {
            InitializeComponent();
            tasks = new ObservableCollection<TaskItem>();
            taskListView.ItemsSource = tasks;


            MessagingCenter.Subscribe<AddTaskPage, TaskItem>(this, "AddTask", (sender, task) =>
            {
                tasks.Add(task);
            });
        }

        private async void addClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }

        private void refClicked(object sender, EventArgs e)
        {

            RefreshTasks();
        }

        private void OnCompleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.BindingContext is TaskItem task)
            {
                task.IsComplete = !task.IsComplete;
                DisplayAlert("Complete", $"Task {task.Name} marked as {(task.IsComplete ? "complete" : "incomplete")}.", "Tamam");
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.BindingContext is TaskItem task)
            {
                bool confirm = await DisplayAlert("Silinsin mi?", "Silmeyi onayla", "Evet", "Hayır");
                if (confirm)
                {
                    tasks.Remove(task);
                    DisplayAlert("Silindi", $"Task {task.Name} Silindi.", "Tamam");
                }
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.BindingContext is TaskItem task)
            {
                string newName = await DisplayPromptAsync("Düzenle", "Yeni Görev Adı:", initialValue: task.Name);
                string newDetail = await DisplayPromptAsync("Düzenle", "Yeni Detay:", initialValue: task.Detail);
                string newDate = await DisplayPromptAsync("Düzenle", "Yeni Tarih (yyyy/MM/dd):", initialValue: task.Date.ToString("yyyy/MM/dd"));
                string newTime = await DisplayPromptAsync("Düzenle", "Yeni Saat (HH:mm):", initialValue: task.Time.ToString(@"hh\:mm"));

                if (newName != null && newDetail != null && DateTime.TryParse(newDate, out DateTime dateResult) && TimeSpan.TryParse(newTime, out TimeSpan timeResult))
                {
                    task.Name = newName;
                    task.Detail = newDetail;
                    task.Date = dateResult;
                    task.Time = timeResult;
                }
            }
        }

        private void RefreshTasks()
        {
            taskListView.ItemsSource = null;
            taskListView.ItemsSource = tasks;
        }
    }
}