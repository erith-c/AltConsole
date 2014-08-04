﻿using AltConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AltConsole
{
    public class WpfControlInput : IInputHandler
    {
        public event EventHandler<InputEventArgs> Input;

        public WpfControlInput(UIElement wpfControl)
        {
            wpfControl.KeyDown += wpfControl_KeyDown;
            wpfControl.TextInput += wpfControl_TextInput;
        }

        void wpfControl_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var lol = e.Text.ToCharArray();
            if(lol.Length > 1)
            {
                System.Diagnostics.Debug.Fail("Okay, TextInput contains more than one char...");
            } 
            else if(lol.Length == 0)
            {
                System.Diagnostics.Debug.Fail("TextInput doesn't contain anything!");
            }
            var chr = lol[0];

            OnCharacterInput(chr);


        }

        void wpfControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected virtual void OnCharacterInput(char inputCharacter)
        {
            var evnt = Input;
            if(evnt != null)
            {
                evnt(this, new InputEventArgs(inputCharacter));
            }
        }
    }
}