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
	public partial class Radioboxes : ContentPage
	{
        //string bumbuc_false = "\U0001F518";
        //string bumbuc_true = "\U000123FA";

        //string bumbuc_false = "\U000125CB";
        //string bumbuc_true = "\U000125C9";

        
        Color semiTransparentColor = new Color(0, 0, 0, 0.9);
        List<Button> listButtons = new List<Button>();
        public Radioboxes ()
		{
			InitializeComponent ();

            var myScroll = new ScrollView();
            var myStack = new StackLayout();
            myScroll.Content = myStack;

            //myLayout.Children.Add(myScroll);

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myStack.Children.Add(kerdes);


            foreach (var item in Constans.aktQuestion.choices)
            {
                Button button = new Button();
                button.Text = Constans.bumbuc_false + "  "+item;
                button.HorizontalOptions= LayoutOptions.Start;
                //button.FontSize = "Large";
                button.Font = Font.SystemFontOfSize(NamedSize.Small);
                button.BackgroundColor = Color.Transparent;
                listButtons.Add(button);
                //button.Opacity = 1;
                button.Clicked += button_Clicked;
                myStack.Children.Add(button);
            }


            myLayout.Children.Add(myScroll);

            MyCheckBox mc = new MyCheckBox();
            //mc.IsCheckedChanged += Mc_IsCheckedChanged;
            
            mc.label = "bebebebebe";
            myLayout.Children.Add(mc);
            Debug.WriteLine("kezdodik");

            /*myCheckbox cb = new myCheckbox();
            cb.Shape = Shape.Rectangle;
            cb.IsCheckedChanged += Cb_IsCheckedChanged;
            myLayout.Children.Add(cb);

            myCheckbox cb2 = new myCheckbox();
            cb2.Shape=Shape.Circle;
            cb2.IsCheckedChanged += Cb_IsCheckedChanged;
            myLayout.Children.Add(cb2);*/





        }

        private void Mc_IsCheckedChanged(object sender, MyCheckBox e)
        {
            Debug.WriteLine("NNNNNYYYYYYEEEERRRRRRT");
            //throw new NotImplementedException();
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Button mostNyomi=(Button)sender;
            foreach(Button button in listButtons)
            {
                string eleje = button.Text;
                string eleje2 = Convert.ToString(eleje.ElementAt(0));
                string vege = eleje.Substring(1, eleje.Length - 1);
                if (button.Id == mostNyomi.Id)
                {
                    button.Text = Constans.bumbuc_true + vege;
                }
                else
                {
                    button.Text = Constans.bumbuc_false + vege;
                }
            }


            Debug.WriteLine("nyomi");


        }

        private void Cb_IsCheckedChanged(object sender, TappedEventArgs e)
        {
            if (e.Parameter.Equals(true))
            {
                Debug.WriteLine("valami volt - true");
            }
            else
            {
                Debug.WriteLine("valami volt - false");
            }
            

        }
        private void _Continue_Clicked(object sender, EventArgs e)
        {
            
            Constans.nextPage();
            Navigation.PushModalAsync(new FPage());
        }
    }
}