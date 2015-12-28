using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace XamarinFormsAwesomizer
{
    public static class ViewAnimationExtensions
    {

        private static Rectangle FromOffSet (this Rectangle rectangle, double xOffset = 0, double yOffSet = 0)
        {
            Rectangle rect = new Rectangle(rectangle.Location.Offset(xOffset, yOffSet), rectangle.Size);
            return rect;
        }

        public static void ShakeHorizontally(this View view, float strength = 12.0f, uint duration = 500)
        {
            var parentAnimation = new Animation
            {
                { 0,  .2, new Animation(x => view.TranslationX = x, 0, -strength, Easing.Linear, null)},
                { .2, .4, new Animation(x => view.TranslationX = x, -strength, strength, Easing.Linear, null)},
                { .4, .6, new Animation(x => view.TranslationX = x, strength, -strength * .66F, Easing.Linear, null)},
                { .6, .8, new Animation(x => view.TranslationX = x, -strength * .66F, strength * 33F, Easing.Linear, null)},
                { .8,  1, new Animation(x => view.TranslationX = x, strength * 33F, 0, Easing.Linear, null)},
            };
            parentAnimation.Commit(view, "ShakeHorizontally", 16, duration, Easing.Linear, null, null);
        }

        public static void ShakeVertically(this View view, float strength = 12.0f, uint duration = 500)
        {
            var parentAnimation = new Animation();
            var y1 = new Animation(v => view.TranslationY = v, 0, -strength, Easing.Linear, null);
            var y2 = new Animation(v => view.TranslationY = v, -strength, strength, Easing.Linear, null);
            var y3 = new Animation(v => view.TranslationY = v, strength, -strength * .66f, Easing.Linear, null);
            var y4 = new Animation(v => view.TranslationY = v, -strength*.66f, strength*.33f, Easing.Linear, null);
            var y5 = new Animation(v => view.TranslationY = v, strength*.33f, 0, Easing.Linear, null);

            parentAnimation.Add(0, .2, y1);
            parentAnimation.Add(.2, .4, y2);
            parentAnimation.Add(.4, .6, y3);
            parentAnimation.Add(.6, .8, y4);
            parentAnimation.Add(.8, 1, y5);
            parentAnimation.Commit(view, "ShakeVertically", 16, duration,Easing.Linear,null,null);
        }

        public static void Pop(this View view, uint duration, int repeatCount, float force)
        {
            var y1 = new Animation(v => view.Scale = v, 1, 1 + (.2*force), Easing.Linear, null);
            var y2 = new Animation(v => view.Scale = v, 1 + (.2*force), 1 + (-.2*force), Easing.Linear, null);
            var y3 = new Animation(v => view.Scale = v, 1 + (-.2*force), 1 + (.2*force), Easing.Linear, null);
            var y4 = new Animation(v => view.Scale = v, 1 + (.2*force), 1, Easing.Linear, null);

            var count = 0;

            var parentAnimation = new Animation();
            parentAnimation.Add(0, .25, y1);
            parentAnimation.Add(.25, .5, y2);
            parentAnimation.Add(.5, .75, y3);
            parentAnimation.Add(.75, 1, y4);
            parentAnimation.Commit(view, "Pop", 16, duration, Easing.Linear,null,() =>
                {
                    count++;
                    Debug.WriteLine("repeat count " + count + " of " + repeatCount);
                    return count < repeatCount;
                });
        }


    }
}

