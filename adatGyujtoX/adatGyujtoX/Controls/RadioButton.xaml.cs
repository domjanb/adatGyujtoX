﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace adatGyujtoX.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RadioButton : ContentView
	{
        public static readonly BindableProperty TextProprty =
            BindableProperty.Create(
                "Text",
                typeof(string),
                typeof(RadioButton),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((RadioButton)bindable).textLabel.Text = (string)newValue;
                    if (((string)newValue).Length == 0)
                    {
                        ((RadioButton)bindable).textLabel.IsVisible = false;

                    }
                    else
                    {
                        ((RadioButton)bindable).textLabel.IsVisible = true;
                    }
                }
                );
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                "FontSize",
                typeof(double),
                typeof(RadioButton),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((RadioButton)bindable).textLabel.FontSize = (double)newValue;
                    ((RadioButton)bindable).boxLabel.FontSize = (double)newValue;
                }
                );
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                "IsChecked",
                typeof(bool),
                typeof(RadioButton),
                false,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((RadioButton)bindable).boxLabel.Text = (bool)newValue ? "⚫" : "⚪";
                    
                    ((RadioButton)bindable).CheckedChange?.Invoke(((RadioButton)bindable), (bool)newValue);
                }
                );
        
        
        
        public event EventHandler<bool> CheckedChange;
        
        public bool _myIschecked;
        public bool myIschecked
        {
            get { return _myIschecked; }
            set
            {
                this._myIschecked = value;
                boxLabel.Text = (bool)_myIschecked ? "⚫" : "⚪"; 
                //CheckedChange?.Invoke(this, (bool)_myIschecked);

                //myFrame.BackgroundColor = _myIschecked ? Color.White : Color.Aqua;
                //myFrame.CornerRadius = _myIschecked ? 0 : 20;
            }

        }

        public bool _enModositok;
        public bool enModositok
        {
            get { return _enModositok; }
            set
            {
                this._enModositok = value;
                //boxLabel.Text = (bool)_myIschecked ? "⚫" : "⚪";
                //CheckedChange?.Invoke(this, (bool)_myIschecked);

                //myFrame.BackgroundColor = _myIschecked ? Color.White : Color.Aqua;
                //myFrame.CornerRadius = _myIschecked ? 0 : 20;
            }

        }


        public RadioButton ()
		{
			InitializeComponent ();
		}
        public string Text
        {
            set { SetValue(TextProprty, value); }
            get { return (string)GetValue(TextProprty); }
        }
        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }
        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }
        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
            if (!_enModositok)
            {
                CheckedChange?.Invoke(this, IsChecked);
            }
            //_myIschecked = !_myIschecked;
            //IsChecked =_myIschecked  ;
            //boxLabel.Text = (bool)_myIschecked ? "⚫" : "⚪";
            
        }
        
    }
}