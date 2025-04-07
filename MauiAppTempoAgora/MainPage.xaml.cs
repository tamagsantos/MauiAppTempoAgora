namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                
            } catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Ok");
             }
        }

        private void Button_Clicked(System.Object sender, System.EventArgs e)
        {

        }
    }

}
