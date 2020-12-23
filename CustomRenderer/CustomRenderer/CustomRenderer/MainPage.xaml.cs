using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Hardware;
using Xamarin.Forms;

namespace CustomRenderer
{
    public partial class MainPage : ContentPage
    {

        
        public MainPage()
        {
            InitializeComponent();
            
            
        }

        protected override void OnAppearing()
        {
            if (!string.IsNullOrEmpty( Help.areaText))
            {
                if (Help.areaText.Length > 20)
                {
                    areaCover.Text = Help.areaText.Substring(0, 19) + "....";
                    ;
                }
                else
                {
                    areaCover.Text = Help.areaText;
                }
            }

        }

        

        async void OnNextPageButtonClicked (object sender, EventArgs e)
        {
            Help.areaText = areaCover.Text;
            await Navigation.PushAsync (new TextArea());
            
        }

        bool isValid()
        {
            String email = TextField.Text;
            if (TextField.Text == null)
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
          
        void Submit(object sender, EventArgs args)
        {
            Error.IsVisible = false;
            Empty.IsVisible = false;
            string shortText = TextField.Text;
            if (TextField.Text == null)
            {
                Error.IsVisible = false;
                Empty.IsVisible = true;
            }

            else if (!(TextField.Text == null) && !isValid())
            {
                Empty.IsVisible = false;
                Error.IsVisible = true;
            }else if(TextField.Text == null)
            {
                Error.IsVisible = false;
                Empty.IsVisible = true;
            }

            if (isValid())
            {
                Error.IsVisible = false;
                DisplayAlert ("Success !", "Submitted Email", "OK");
            }

            if (TextField.Text.Length > 20)
            {
          
                CoverLabel.Text = TextField.Text.Substring(0, 15) + "....";    

            }else if (TextField.Text.Length <= 20)
            {
                CoverLabel.Text = TextField.Text;
            }
            
            TextField.IsVisible = false;
            CoverLabel.IsVisible = true;
            
        }
        bool swapped = false;
      //language change
      void Swap(object sender, EventArgs args)
        {
            CoverLabel.IsVisible = false;
            if (swapped == false)
            {
                CoverLabel.IsVisible = false;
                Error.IsVisible = false;
                Empty.IsVisible = false;

                TextField.IsVisible = false;
                Emailabel.IsVisible = false;

                OtherField.IsVisible = true;
                OtherLabel.IsVisible = true;
                swapped = true;
            }else if (swapped == true)
            {
                
                Error.IsVisible = false;
                Empty.IsVisible = false;

                OtherField.IsVisible = false;
                OtherLabel.IsVisible = false;
                
                TextField.IsVisible = false;
                Emailabel.IsVisible = true;
                CoverLabel.IsVisible = true;
                swapped = false;
            }
        }
      //save text entry in a label
      private bool wasClicked = false;
      void ChangeText(object sender, EventArgs args)
      {
          if(!wasClicked){ 
            wasClicked = true;
            String  labelText = CoverLabel.Text;
            TextField.Text = labelText; 
            CoverLabel.IsVisible = false;
            TextField.IsVisible = true;
          }
          if (wasClicked)
          {
              CoverLabel.IsVisible = false;
              TextField.IsVisible = true;
          }
      }

     
    }

    public static class Help
    {
        public static String areaText;
        public static String unTruncated;

    }
}
