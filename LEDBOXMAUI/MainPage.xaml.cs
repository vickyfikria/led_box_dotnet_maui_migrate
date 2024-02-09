using LEDBOXMAUI.ViewModels;

namespace LEDBOXMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainViewModel mvm)
        {
            InitializeComponent();
            BindingContext = mvm;
        }



        private void Bt_changeAlias(object sender, EventArgs e)
        {
            Console.WriteLine();
        }



        /// <summary>
        /// Apre la finestra dei credits
        /// </summary>
        public async void openCredits()
        {

            //await Navigation.PushAsync(new CreditsView());


        }

    }

}
