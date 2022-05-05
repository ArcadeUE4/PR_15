using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PR_15
{
    public partial class RecordPage : ContentPage
    {
        public RecordPage()
        {
            InitializeComponent();
        }

        private void ReturnClick(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
        public void callcells(string cell)
        {
            TextCell cellText = new TextCell() { Text = cell };
            Table.Add(cellText);
            Table.Add(cellText);
        }
    }
}