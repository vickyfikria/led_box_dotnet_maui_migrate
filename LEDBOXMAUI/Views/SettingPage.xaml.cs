using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using CommunityToolkit.Mvvm.Input;
using LEDBOXMAUI.Interfaces;
using LEDBOXMAUI.Model;
using LEDBOXMAUI.Resources;



namespace LEDBOXMAUI.Views
{
    public partial class SettingView : ContentPage
    {

        public SettingView()
        {
            InitializeComponent();
        }

        async void Bt_Save_Clicked(object sender, System.EventArgs e)
        {

            if (App.conn == null || !App.conn.isConnected())
            {
                App.DisplayAlert(AppResources.error_connection);
                return;
            }

            if (panel.IsEnabled == false)
                return;

            if (mode_execute.SelectedIndex == 1)
            {
                ip_master.Text = validateIPAddress(ip_master.Text);
                if (ip_master.Text == "")
                {
                    App.DisplayAlert(AppResources.master_ip_not_valid);
                    return;
                }
            }

            if (network_mode.SelectedIndex == 1)
            {
                network_ip.Text = validateIPAddress(network_ip.Text);
                if (network_ip.Text == "")
                {
                    App.DisplayAlert(AppResources.network_ip_not_valid);
                    return;
                }

                network_subnet.Text = validateIPAddress(network_subnet.Text);
                if (network_subnet.Text == "")
                {
                    App.DisplayAlert(AppResources.network_subnet_not_valid);
                    return;
                }

                network_gateway.Text = validateIPAddress(network_gateway.Text);
                if (network_gateway.Text == "")
                {
                    App.DisplayAlert(AppResources.network_gateway_not_valid);
                    return;
                }
            }

            APILedbox.config[] configs = new APILedbox.config[10];

            configs[0] = new APILedbox.config() { section = "WIFI", field = "mode", value = wifi_mode.SelectedIndex == 0 ? "ap" : "client", device = App.deviceName };
            configs[1] = new APILedbox.config() { section = "WIFI", field = "ssid", value = "'" + wifi_ssid.Text + "'", device = App.deviceName };
            configs[2] = new APILedbox.config() { section = "WIFI", field = "psk", value = "'" + wifi_psk.Text + "'", device = App.deviceName };
            configs[3] = new APILedbox.config() { section = "LAYOUT", field = "modifier", value = modifier.SelectedIndex == 0 ? "" : "specular", device = App.deviceName };
            configs[4] = new APILedbox.config() { section = "GENERAL", field = "mode", value = mode_execute.SelectedIndex == 0 ? "master" : "slave", device = App.deviceName };
            configs[5] = new APILedbox.config() { section = "GENERAL", field = "ip_master", value = ip_master.Text, device = App.deviceName };

            configs[6] = new APILedbox.config() { section = "NETWORK", field = "mode", value = network_mode.SelectedIndex == 0 ? "dhcp" : "static", device = App.deviceName };
            configs[7] = new APILedbox.config() { section = "NETWORK", field = "ip", value = network_ip.Text, device = App.deviceName };
            configs[8] = new APILedbox.config() { section = "NETWORK", field = "subnet", value = network_subnet.Text, device = App.deviceName };
            configs[9] = new APILedbox.config() { section = "NETWORK", field = "gateway", value = network_gateway.Text, device = App.deviceName };



            App.conn.SendMessage(App.api.createSetConfigsMessage(configs));

            DependencyService.Get<IMessage>().ShortAlert(AppResources.config_saved);


            var answer = await App.main.DisplayAlert(AppResources.reboot, AppResources.reboot_app, AppResources.yes, AppResources.no);

            if (answer)
            {
                App.conn.SendMessage(App.api.createRebootMessage());
                App.conn.DisconnectToLedbox();
            }

            //Navigation.PopAsync();
        }

        void mode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (wifi_mode.SelectedIndex)
            {
                case 0:
                    wifi_ssid_panel.IsVisible = false;
                    wifi_psk_panel.IsVisible = false;
                    break;
                case 1:
                    wifi_ssid_panel.IsVisible = true;
                    wifi_psk_panel.IsVisible = true;
                    break;

            }
        }

        [RelayCommand]
        void Change()
        {
            switch (wifi_mode.SelectedIndex)
            {
                case 0:
                    wifi_ssid_panel.IsVisible = false;
                    wifi_psk_panel.IsVisible = false;
                    break;
                case 1:
                    wifi_ssid_panel.IsVisible = true;
                    wifi_psk_panel.IsVisible = true;
                    break;

            }

        }

        void DeletePlaylistImage(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }

        void DeletePlaylistAudio(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }


        void DeleteMatchscore(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }

        void DeletePractice(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }


        void DeleteMedia(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }

        void updateLedbox(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }


        void restartLedbox(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }


        void restartDHCP(object sender, System.EventArgs e)
        {
            Console.WriteLine();
        }

        


        string validateIPAddress(string ipaddress)
        {
            IPAddress ip;
            bool ValidateIP = IPAddress.TryParse(ipaddress, out ip);
            if (ip != null)
                return ip.ToString();
            else
                return "";

        }
    }
}
