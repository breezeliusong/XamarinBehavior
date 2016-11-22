using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBehavior
{
    public class CustomBehavior:Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryChanged;
            base.OnAttachedTo(bindable);
            //perform setup
        }

        private void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Green : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryChanged;
            base.OnDetachingFrom(bindable);
            //perform clean up
        }
    }
}
