using MobileApp.View;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public Workouts Workouts { get; }

        public static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string BackendUrl = $"http://{IPAddress}:5000";

        public App()
        {
            InitializeComponent();

            Workouts = new Workouts();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }


}