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
            /*var myScroll = new ScrollView();
            var myStack = new StackLayout();
            myScroll.Content = myStack;*/

            //var lalal = new StackLayout();

            /*Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myStack.Children.Add(kerdes);*/

            /*StackLayout mostsl = new StackLayout();
            mostsl.Orientation = StackOrientation.Horizontal;
            mostsl.HorizontalOptions = LayoutOptions.FillAndExpand;*/

            /*ImageButton buttonx = new ImageButton();
            string dumax = "egyéb";
            if (dumax == "egyéb")
            {
                dumax = "other";
            }
            string ffilex = Path.Combine(Constans.myFilePath, dumax.ToLower() + "_logo.png");
            buttonx.Source = ImageSource.FromFile(ffilex);
            buttonx.HorizontalOptions = LayoutOptions.FillAndExpand;
            buttonx.Aspect = Aspect.AspectFill;
            
            myLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            myLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            myLayout.Children.Add(buttonx);*/

            /*ImageButton buttony = new ImageButton();
            var dumay = "egyéb";
            if (dumay == "egyéb")
            {
                dumay = "other";
            }
            var ffiley = Path.Combine(Constans.myFilePath, dumay.ToLower() + "_logo.png");
            buttony.Source = ImageSource.FromFile(ffiley);
            buttony.Aspect = Aspect.AspectFill;
            buttony.HorizontalOptions = LayoutOptions.FillAndExpand;
            mostsl.Children.Add(buttony);*/
            //myStack.Children.Add(mostsl);



            /*int itemDb = Constans.aktQuestion.choices.Count;

            //var lt = new Constans.LayoutTomb();
            for (var i = 0; i < itemDb / 2; i++)
            {
                Constans.myLayout.Add("neve" + Convert.ToString(i),
                    new StackLayout { Orientation = StackOrientation.Horizontal,
                        
                        
                        

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
                //button.Aspect = Aspect.AspectFill;
                
                //button.VerticalOptions = LayoutOptions.FillAndExpand;
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

                
            }*/
            //myStack.Children.Add(regForm2);
            //myLayout.Children.Add(myScroll);
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