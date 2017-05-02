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
using SuaveControls.MaterialButton.Android;
using SuaveControls.MaterialButton.Shared;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MaterialButton), typeof(MaterialButtonRenderer))]
namespace SuaveControls.MaterialButton.Android
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
            Control.Elevation = materialButton.Elevation;
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
                Control.Elevation = materialButton.Elevation;
            }
        }
    }
}