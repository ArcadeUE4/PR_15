using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PR_15
{
    public partial class MainPage : ContentPage
    {
        Stopwatch stopwatch = new Stopwatch();
        bool alive = false;
        public MainPage()
        {
            InitializeComponent();
            entry.Text = "";
            DispalyTime();
        }
        private void TimerButtonClicked(object sender, EventArgs e)
        {
            if (entry.Text == "")
            {
                entry.Placeholder = "Вы не ввели заголовок записи";
            }
            else
            {
                if (alive == true)
                {
                    alive = false;
                    RecordPage record = new RecordPage();
                    record.callcells(entry.Text);
                    entry.Text = "";
                    stopwatch.Stop();
                }
                else
                {
                    alive = true;
                    stopwatch.Restart();
                    DispalyTime();
                }
            }
        }
        private async void DispalyTime()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(0.1), OnStopwatchLaunched);
            await Task.Delay(100);
        }

       bool OnStopwatchLaunched()
        {
            stopwatch.Start();
            TimeSpan ts = stopwatch.Elapsed;


            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            label.Text = elapsedTime;

            return alive;

        }
        private void OpenPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecordPage());
        }
        private void EntryChanged(object sender, EventArgs e)
        {
            entry.Placeholder = "Введите заголовок записи";
        }
    }
}
