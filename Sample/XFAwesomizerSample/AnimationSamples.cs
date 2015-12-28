using System;

using Xamarin.Forms;
using System.Windows.Input;
using XamarinFormsAwesomizer;

namespace XFAwesomizerSample
{
    public class AnimationSamples : ContentPage
    {
        public ICommand tapCommand { get; private set;} 
        private BoxView bv;
        Picker picker;

        public AnimationSamples()
        {
            Padding = 30;

            tapCommand = new Command(PerformAnimation);

            bv = new BoxView();
            bv.HorizontalOptions = LayoutOptions.Center;
            bv.VerticalOptions = LayoutOptions.Center;
            bv.WidthRequest = 200;
            bv.HeightRequest = 200;
            bv.Color = Color.Red;

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Command = tapCommand;
            bv.GestureRecognizers.Add(tap);

            picker = new Picker();
            picker.Items.Add("Shake Horizontal");
            picker.Items.Add("Shake Vertical");
            picker.SelectedIndex = 0;

            var layout = new StackLayout();
            layout.Children.Add(bv);
            layout.Children.Add(picker);
            this.Content = layout;
        }

        public void PerformAnimation()
        {
            switch (picker.Items[picker.SelectedIndex])
            {
                case "Shake Horizontal":
                    bv.ShakeHorizontally();
                    break;
                case "Shake Vertical":
                    bv.ShakeVertically();
                    break;
                default:
                    break;
            }
        }
    }
}


