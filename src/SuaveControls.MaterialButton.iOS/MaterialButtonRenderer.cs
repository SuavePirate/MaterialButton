using SuaveControls.MaterialButton.iOS;
using SuaveControls.MaterialButton.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(MaterialButton), typeof(MaterialButtonRenderer))]
namespace SuaveControls.MaterialButton.iOS
{
    public class MaterialButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            UpdateShadow();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == "Elevation")
            {
                UpdateShadow();
            }
        }

        private void UpdateShadow()
        {

            var materialButton = (Shared.MaterialButton)Element;

            // Update shadow to match better material design standards of elevation
            Layer.ShadowRadius = materialButton.Elevation;
            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOffset = new CGSize(2, 2);
            Layer.ShadowOpacity = 0.80f;
            Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
            Layer.MasksToBounds = false;

        }
    }
}
