using adatGyujtoX.Controls;
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
            myLayout.Margin = new Thickness(10, 0, 10, 0);
            var myScroll = new ScrollView();
            var myStack = new StackLayout();
            //myStack.VerticalOptions = LayoutOptions.FillAndExpand;
            //myStack.HorizontalOptions = LayoutOptions.FillAndExpand;
            //myStack.Padding = new Thickness(21, 20, 20, 20);
            //myStack.Margin = new Thickness(20, 20, 20, 20);
            myScroll.Content = myStack;

            //var lalal = new StackLayout();

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            kerdes.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            myStack.Children.Add(kerdes);

            /*StackLayout mostSl = new StackLayout();
            mostSl.HorizontalOptions = LayoutOptions.Fill;
            mostSl.VerticalOptions = LayoutOptions.Fill;
            mostSl.Padding = new Thickness(1, 1, 1, 1);
            mostSl.Margin = new Thickness(1, 1, 1, 1);*/
            //string duma = "other";

            /*MyImageButton button = new MyImageButton();
            string ffile = Path.Combine(Constans.myFilePath, duma.ToLower() + "_logo.png");
            button.Source = ImageSource.FromFile(ffile);
            int padding = Convert.ToInt16(Constans.ScreenWidth / 7 / 2);
            button.Padding = new Thickness(0, 0, 0, 0);
            //button.Aspect = Aspect.AspectFill;

            //button.VerticalOptions = LayoutOptions.FillAndExpand;
            //button.HorizontalOptions = LayoutOptions.FillAndExpand;
            //button.Aspect = Aspect.AspectFill;
            //button.Margin = new Thickness(10, 10, 10, 10);
            //button.Padding = new Thickness(1, 5, 1, 5);
            button.BackgroundColor = Color.Red;
            //listButtons.Add(button);
            //mostSl.Children.Add(button);
            myStack.Children.Add(button);
            myLayout.Children.Add(myScroll);*/

            int itemDb = Constans.aktQuestion.choices.Count;

            //var lt = new Constans.LayoutTomb();
            for (var i = 0; i < itemDb / 2; i++)
            {
                Constans.myLayout.Add("neve" + Convert.ToString(i),
                    new StackLayout { Orientation = StackOrientation.Horizontal,
                        VerticalOptions  = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                        
                        

                    });
            }

            int sor = -1;
            int idx = 0;
            var oszlop = 0;
            int nevindex = 1;
            
            
            foreach (var item in Constans.aktQuestion.choices)
            {
                
                oszlop = 1;
                //if (idx % 2 != 1)
                if (idx < 2)
                {
                    idx++;
                    
                }
                else
                {
                    nevindex = nevindex + 1;
                    idx = 1;
                    sor++;
                    oszlop = 0;
                    
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
                int padding = Convert.ToInt16(Constans.ScreenWidth / 7/2);
                button.Padding = new Thickness(0, 10, 0, 10);
                //button.Aspect = Aspect.AspectFill;

                button.VerticalOptions = LayoutOptions.FillAndExpand;
                button.HorizontalOptions = LayoutOptions.FillAndExpand;
                button.Aspect = Aspect.AspectFill;
                listButtons.Add(button);

                //Image button2 = new Image();
                //button2.Source = ImageSource.FromFile(ffile);
                //button2.VerticalOptions = LayoutOptions.StartAndExpand;
                //button2.Aspect = Aspect.AspectFill;


                button.Clicked += button_Clicked;
                foreach(var itemL in Constans.myLayout)
                {
                    if (itemL.Key == neve)
                    {
                        Debug.WriteLine("sl.Height");
                        StackLayout sl = (StackLayout)(itemL.Value);
                        Debug.WriteLine(sl.Height);
                        itemL.Value.Children.Add(button);
                        //sl.VerticalOptions = LayoutOptions.FillAndExpand;
                        Debug.WriteLine(button.Height);
                        sl.MinimumHeightRequest = button.Height;
                        
                        Debug.WriteLine(sl.Height);

                    }
                }
            //regForm2.Children.Add(button, oszlop, sor);

        }
            foreach (var  itemL in Constans.myLayout)
            {
                //StackLayout stack = itemL.Value;
                //stack.Orientation= StackOrientation.Horizontal;
                myStack.Children.Add(itemL.Value);

                
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