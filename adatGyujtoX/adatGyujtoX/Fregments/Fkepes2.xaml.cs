using adatGyujtoX.Modell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Fregments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Fkepes2 : ContentPage
	{
        List<ImageButton> listButtons = new List<ImageButton>();
        List<StackLayout> listLayout = new List<StackLayout>();
        public Fkepes2 ()
		{
			InitializeComponent ();
            var myScroll = new ScrollView();
            var myStack = new StackLayout();
            myScroll.Content = myStack;

            var lalal = new StackLayout();

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myStack.Children.Add(kerdes);

            int itemDb = Constans.aktQuestion.choices.Count;

            //var lt = new Constans.LayoutTomb();
            for (var i = 0; i < itemDb / 2; i++)
            {
                Constans.myLayout.Add("neve" + Convert.ToString(i), new StackLayout());
            }

            int sor = -1;
            int idx = 0;
            var oszlop = 0;
            int nevindex = 1;
            var mostStack = new StackLayout();
            foreach (var item in Constans.aktQuestion.choices)
            {
                idx++;
                oszlop = 1;
                if (idx % 2 != 1)
                {
                    nevindex = nevindex + 1;
                }
                else
                {
                    sor++;
                    oszlop = 0;
                    myStack.Children.Add(mostStack);
                }
                var neve = "neve" + Convert.ToString(nevindex);
                ImageButton button = new ImageButton();
                string duma = ((string)item).ToLower();
                if (duma == "egyéb")
                {
                    duma = "other";
                }
                string ffile = Path.Combine(Constans.myFilePath, duma.ToLower() + "_logo.png");
                button.Source = ImageSource.FromFile(ffile);
                button.Aspect = Aspect.Fill;
                
                button.VerticalOptions = LayoutOptions.CenterAndExpand;
                button.HorizontalOptions = LayoutOptions.CenterAndExpand;
                listButtons.Add(button);
                
                button.Clicked += button_Clicked;
                foreach(var itemL in Constans.myLayout)
                {
                    if (itemL.Key == neve)
                    {

                        itemL.Value.Children.Add(button);
                    }
                }
                //regForm2.Children.Add(button, oszlop, sor);

            }
            foreach (var itemL in Constans.myLayout)
            {
                myLayout.Children.Add(itemL.Value);
                
            }
            //myStack.Children.Add(regForm2);
            myLayout.Children.Add(myScroll);
        }
        private void button_Clicked(object sender, EventArgs e)
        {
            /*Button mostNyomi = (Button)sender;
            foreach (Button button in listButtons)
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
            }*/


            Debug.WriteLine("nyomi");


        }
        private void _Continue_Clicked(object sender, EventArgs e)
        {

            Constans.nextPage();
            Navigation.PushModalAsync(new FPage());
        }
    }
}