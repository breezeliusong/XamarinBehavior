using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBehavior
{
    public class CustomBehavior1:Behavior<Entry>
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", 
                typeof(bool), typeof(CustomBehavior1), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view,bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view,object oldValue,object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }
            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.Behaviors.Add(new CustomBehavior1());
            }else
            {
                var toRemove = entry.Behaviors.FirstOrDefault(b => b is CustomBehavior1);
                if (toRemove != null)
                {
                    entry.Behaviors.Remove(toRemove);
                }
            }
        }
    }
}
