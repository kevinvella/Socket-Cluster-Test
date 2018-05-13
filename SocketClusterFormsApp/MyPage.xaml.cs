using System;
using System.Collections.Generic;
using SocketClusterFormsApp.Services;
using Xamarin.Forms;

namespace SocketClusterFormsApp
{
    public partial class MyPage : ContentPage
    {
        SocketClusterService socketCluster;
        public MyPage()
        {
            InitializeComponent();

            socketCluster = new SocketClusterService();
        }
    }
}
