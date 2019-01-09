using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using adatGyujtoX.Controls;
using adatGyujtoX.Modell;
using System.Diagnostics;

namespace adatGyujtoX.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Radiobutton : ContentPage
    {
        
        public Radiobutton ()
		{
			InitializeComponent ();

            myCheckbox cb = new myCheckbox();
            cb.Shape = Shape.Rectangle;
            cb.IsCheckedChanged += Cb_IsCheckedChanged;
            my2Layout.Children.Add(cb);
            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            my2Layout.Children.Add(kerdes);

            
        }
        private void Cb_IsCheckedChanged(object sender, TappedEventArgs e)
        {
            //checkbox.IsCheckedChanged?.Invoke(checkbox, new TappedEventArgs((bool)newValue));
            if (e.Parameter.Equals(true))
            {
                Debug.WriteLine("valami volt - true");
            }
            else
            {
                Debug.WriteLine("valami volt - false");
            }


        }
        
    }
}