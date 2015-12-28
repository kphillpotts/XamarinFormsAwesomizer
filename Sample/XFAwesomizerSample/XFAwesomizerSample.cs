using System;

using Xamarin.Forms;
using System.Linq.Expressions;

namespace XFAwesomizerSample
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new AnimationSamples();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

