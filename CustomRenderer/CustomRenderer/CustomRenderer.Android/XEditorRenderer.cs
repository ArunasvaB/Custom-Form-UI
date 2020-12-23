using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using CustomRenderer;
using CustomRenderer.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XEditor), typeof(XEditorRenderer))]
namespace CustomRenderer.Android
{
    class XEditorRenderer : EditorRenderer
    {
        public XEditorRenderer(Context context) : base(context)
        {
        }
      


        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.White);
            }
        }
    }
}