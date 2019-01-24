using adatGyujtoX.Controls;
using adatGyujtoX.Modell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Fregments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FRadioButton : ContentPage
	{
        List<RadioButton> listCheckbox = new List<RadioButton>();
        public FRadioButton ()
		{
			InitializeComponent ();
		
            var myScroll = new ScrollView();
            var myStack = new StackLayout();
            myScroll.Content = myStack;

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
                myStack.Children.Add(kerdes);

                foreach (var item in Constans.aktQuestion.choices)
                {
                    RadioButton button = new RadioButton();
                    button.Text = item;
                    //button.HorizontalOptions = LayoutOptions.Start;
                    //button.FontSize = "Large";
                    button.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    button.BackgroundColor = Color.Transparent;
                int padding = Convert.ToInt16(Constans.ScreenWidth / 7);
                button.Padding = new Thickness(padding, 0, padding, 0);
                listCheckbox.Add(button);
                    //button.Opacity = 1;
                    button.CheckedChange += Button_CheckedChange;
                    myStack.Children.Add(button);
                }
                //myLayout
                myLayout.Children.Add(myScroll);
            }
        private void Button_CheckedChange(object sender, bool e)
        {
            //throw new NotImplementedException();
            Debug.WriteLine("volt nyomi");
        }
        private void _Continue_Clicked(object sender, EventArgs e)
        {

            Constans.nextPage();
            Navigation.PushModalAsync(new FPage());
        }

    }
}