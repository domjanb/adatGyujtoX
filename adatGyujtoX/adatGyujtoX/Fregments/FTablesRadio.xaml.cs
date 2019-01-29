﻿using adatGyujtoX.Controls;
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
	public partial class FTablesRadio : ContentPage
	{
		public FTablesRadio ()
		{
			InitializeComponent ();
            var myScroll = new ScrollView();
            var myStack = new StackLayout();
            myScroll.Content = myStack;

            //myLayout.Children.Add(myScroll);

            Label kerdes = new Label();
            kerdes.Text = Constans.aktQuestion.question_title;
            myStack.Children.Add(kerdes);

            var darab = 4;
            TablesRadio tablesSor = new TablesRadio
            {
                Text = "1subidubisuiuu",
                ValaszDB =4,
        };
            //tablesSor.Text = "1subidubisuiuu";
            //tablesSor.ValaszDB = darab;
            tablesSor.BackgroundColor = Color.AliceBlue;
            myStack.Children.Add(tablesSor);

            TablesRadio tablesSor2 = new TablesRadio();
            tablesSor2.Text = "2subidubisuiusu aksdmn,sadna";
            tablesSor2.ValaszDB = darab;
            tablesSor2.BackgroundColor = Color.AntiqueWhite;
            myStack.Children.Add(tablesSor2);

            TablesRadio tablesSor3 = new TablesRadio();
            tablesSor3.Text = "3subidubisuiuu subidubisuiuu subidubisuiuu subidubisuiuu subidubisuiuu subidubisuiuu subidubisuiuu v";
            tablesSor3.ValaszDB = darab;
            tablesSor3.BackgroundColor = Color.AliceBlue;
            myStack.Children.Add(tablesSor3);

            TablesRadio tablesSor4 = new TablesRadio();
            tablesSor4.Text = "4subidubisuiuu";
            tablesSor4.ValaszDB = darab;
            tablesSor4.BackgroundColor = Color.AntiqueWhite;
            myStack.Children.Add(tablesSor4);

            var idx = 0;
            foreach (var item in Constans.aktQuestion.items)
            {
                idx++;
                TablesRadio button = new TablesRadio();
                button.Text = item;

                //button.FontSize = "Large";
                //button.BackgroundColor = Color.Transparent;
                if (idx % 2 != 1)
                {
                    button.BackgroundColor = Color.AliceBlue;
                }
                else
                {
                    tablesSor2.BackgroundColor = Color.AntiqueWhite;
                }

                //listCheckbox.Add(button);
                //button.Opacity = 1;
                //button.CheckedChange += Button_CheckedChange;
                myStack.Children.Add(button);
            }
            myLayout.Children.Add(myScroll);
        }
        private void Button_CheckedChange(object sender, bool e)
        {
            //throw new NotImplementedException();
        }
        private void _Continue_Clicked(object sender, EventArgs e)
        {

            Constans.nextPage();
            Navigation.PushModalAsync(new FPage());
        }

    }
}