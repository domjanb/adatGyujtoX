using adatGyujtoX.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Fregments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FString : ContentPage
	{
		public FString ()
		{
			InitializeComponent ();
            var myScroll = new ScrollView();
            var myStack = new StackLayout();
            myScroll.Content = myStack;

            //myLayout.Children.Add(myScroll);

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myStack.Children.Add(kerdes);

            Entry lblDuma = new Entry();
            myStack.Children.Add(lblDuma);
            /*foreach (var item in Constans.aktQuestion.choices)
            {
                Button button = new Button();
                button.Text = Constans.bumbuc_false + "  " + item;
                button.HorizontalOptions = LayoutOptions.Start;
                //button.FontSize = "Large";
                button.Font = Font.SystemFontOfSize(NamedSize.Small);
                button.BackgroundColor = Color.Transparent;
                listButtons.Add(button);
                //button.Opacity = 1;
                button.Clicked += button_Clicked;
                myStack.Children.Add(button);
            }*/


            myLayout.Children.Add(myScroll);
        }
        private void _Continue_Clicked(object sender, EventArgs e)
        {

            Constans.nextPage();
            Navigation.PushModalAsync(new FPage());
        }
    }
}