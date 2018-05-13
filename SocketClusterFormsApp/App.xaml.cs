using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SocketClusterFormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MyPage();
        }
    }
}
