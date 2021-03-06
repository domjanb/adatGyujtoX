﻿using adatGyujtoX.Modell;
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
	public partial class FPage : ContentPage
	{
		public FPage ()
		{
			InitializeComponent ();

            //Constans.nextPage();
            if (Constans.aktQuestion.question_type== "Radioboxes")
            {
                //Navigation.PushModalAsync(new Radioboxes());
                //Navigation.PushModalAsync(new FCheckBox());
                Navigation.PushModalAsync(new FRadioButton());
                

            }
            else if (Constans.aktQuestion.question_type == "Kepes")
            {
                Navigation.PushModalAsync(new Fkepes2());
            }
            else if(Constans.aktQuestion.question_type == "Number")
            {
                Navigation.PushModalAsync(new FNumbers());
            }
            else if (Constans.aktQuestion.question_type == "String")
            {
                Navigation.PushModalAsync(new FString());
            }
            else if (Constans.aktQuestion.question_type == "Gombok")
            {
                Navigation.PushModalAsync(new FGombok());
            }
            else if (Constans.aktQuestion.question_type == "SzurRadio2")
            {
                Navigation.PushModalAsync(new FSzurCheckbox2());
            }
            else if (Constans.aktQuestion.question_type == "SzurRadio")
            {
                Navigation.PushModalAsync(new FSzurRadio());
            }
            else if (Constans.aktQuestion.question_type == "TablesRadio")
            {
                Navigation.PushModalAsync(new FTablesRadio());
            }
            else if (Constans.aktQuestion.question_type == "Checkboxes")
            {
                Navigation.PushModalAsync(new FCheckBox() );
            }
            else if (Constans.aktQuestion.question_type == "SorbaRendezo")
            {
                Navigation.PushModalAsync(new FSorbarendezo());
            }
            //break;
        }
    }
}