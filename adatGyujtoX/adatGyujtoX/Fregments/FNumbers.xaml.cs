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
	public partial class FNumbers : ContentPage
	{
		public FNumbers ()
		{
			InitializeComponent ();
            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myLayout.Children.Add(kerdes);
            

        }

        private void _Continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}