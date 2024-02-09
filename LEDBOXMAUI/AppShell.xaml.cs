﻿using LEDBOXMAUI.Views;

namespace LEDBOXMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));
        }
    }
}
