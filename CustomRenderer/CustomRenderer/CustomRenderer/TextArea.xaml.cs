using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomRenderer;
using Xamarin.Forms;

namespace CustomRenderer
{
    public partial class TextArea : ContentPage
    {
        
        public TextArea()
        {
            InitializeComponent();
         
        }

        protected override void OnAppearing()
        {
           if( ! string.IsNullOrEmpty(Help.unTruncated))
           {
                Area.Text  =  Help.unTruncated;
           }else
           {
               Area.Text = Help.areaText;
           }
        }

        protected override void OnDisappearing()
        {
           
            Help.areaText = Area.Text;
            Help.unTruncated = Area.Text;

        }
    }


}