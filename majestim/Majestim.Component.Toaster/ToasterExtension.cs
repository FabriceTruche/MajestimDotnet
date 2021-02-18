using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ToastNotifications
{
    public static class ToasterExtension
    {
        public static void Toaster(this Form currentForm, string title, string text, ToasterType toasterType=ToasterType.Info,  int duration=3, AnimationMethod animation=AnimationMethod.Fade, AnimationDirection direction=AnimationDirection.Right)
        {
            ToasterForm form = new ToasterForm(currentForm, title,  text, toasterType, duration, animation, direction);
            form.Show();
        }

        public static void AutoToasterButton(this Form currentForm)
        {
            Control.ControlCollection controls = currentForm.Controls;

            foreach (Control ctrl in currentForm.Controls)
            {
                if (ctrl is Button button)
                {
                    button.Click += (sender, args) => currentForm.Toaster(button.Name, button.Text + " - Done.");
                }
            }
        }
    }
}