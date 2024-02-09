using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LEDBOXMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LEDBOXMAUI.ViewModels
{
    public partial  class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            
        }


        [RelayCommand]
        Task BT_PlayList() => Shell.Current.GoToAsync($"../{nameof(PlayListPage)}");

        [RelayCommand]
        Task BT_MatchScore() => Shell.Current.GoToAsync($"../{nameof(MatchScorePage)}");

        async void Bt_Playlist_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Navigation.PushAsync(new PlaylistView());
        }

        async void Bt_MatchScore_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MatchScoreView());

        }

        async void Bt_Practice_Clicked(object sender, System.EventArgs e)
        {

            //TODO modificato per consentire il recupero delle practice dal LEDBox 14/12/2019s
            //await Navigation.PushAsync(new PracticeTabbedView(AppResources.practice, Color.DarkSeaGreen, 0));

            await Navigation.PushAsync(new PracticeView(AppResources.practice, Color.DarkSeaGreen, 0));



        }

        async void Bt_Text_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CustomListView());

        }

    }
}
