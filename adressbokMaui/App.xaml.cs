﻿using adressbokMaui.ViewModels;

namespace adressbokMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
