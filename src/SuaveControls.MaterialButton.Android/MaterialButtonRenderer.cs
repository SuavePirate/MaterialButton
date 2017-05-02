using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms;
using SuaveControls.MaterialButton.Droid;
using SuaveControls.MaterialButton.Shared;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics;
using Android.Support.V4.View;

[assembly: ExportRenderer(typeof(MaterialButton), typeof(MaterialButtonRenderer))]
namespace SuaveControls.MaterialButton.Droid
{
    public class MaterialButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        /// <summary>
        /// Set up the elevation from load
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null)
                return;

            var materialButton = (Shared.MaterialButton)Element;


            // we need to reset the StateListAnimator to override the setting of Elevation on touch down and release.
            Control.StateListAnimator = new Android.Animation.StateListAnimator();

            // set the elevation manually
            ViewCompat.SetElevation(this, materialButton.Elevation);
            ViewCompat.SetElevation(Control, materialButton.Elevation);
        }

        public override void Draw(Canvas canvas)
        {
            var materialButton = (Shared.MaterialButton)Element;
            Control.Elevation = materialButton.Elevation;
            base.Draw(canvas);
        }

        /// <summary>
        /// Update the elevation when updated from Xamarin.Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == "Elevation")
            {
                var materialButton = (Shared.MaterialButton)Element;
                ViewCompat.SetElevation(this, materialButton.Elevation);
                ViewCompat.SetElevation(Control, materialButton.Elevation);
                UpdateLayout();
            }
        }
    }
}