using System;
using Xamarin.Forms;

namespace CustomRenderer
{
    public class MainPageViewModel
    {
        private ContentPage myView;
        private ContentPage myView2;
        private Label Error;
        private Label Empty;
        private Entry TextField;
        private Label CoverLabel;
        private Editor Area;
    
        private Label areaCover;
        public MainPageViewModel(ContentPage view)
        {
            myView = view;
            TextField = myView.FindByName<Entry>("TextField");
            Error = myView.FindByName<Label>("Error");
            Empty = myView.FindByName<Label>("Empty");
            CoverLabel = myView.FindByName<Label>("CoverLabel");
            Area = myView.FindByName<Editor>("Area");
           

            areaCover = myView.FindByName<Label>("areaCover");
           
            TextField.Unfocused += TextField_Unfocused;
            
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

       
        void TextField_Unfocused(object sender, FocusEventArgs e)
        {
            
            Error.IsVisible = false;
            Empty.IsVisible = false;
            string shortText = TextField.Text;
            
            if (TextField.Text == null)
            {
                Error.IsVisible = false;
                Empty.IsVisible = true;
            
            }
            else if (!(TextField.Text == null))
            {
                Empty.IsVisible = false;
                Error.IsVisible = true;
            }
            else if(TextField.Text == null)
            {
                Error.IsVisible = false;
                Empty.IsVisible = true;
            }

            if (isValid())
            {
                Error.IsVisible = false;
                
                myView.DisplayAlert("Success !", "Submitted Email", "OK");
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
        
        }
    }
