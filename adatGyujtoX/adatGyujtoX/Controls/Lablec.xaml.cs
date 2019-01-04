using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lablec
	{
		public Lablec ()
		{
			InitializeComponent ();
		}

        private void _Back_Clicked(object sender, EventArgs e)
        {

        }

        private void _Continue_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("volt nyomi");
            //DisplayAlert("Continue ", "volt nyomi", "Cancel");
        }
    }
}