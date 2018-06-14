using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace testApp.UI
{
    public class MyDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var name = item as string;
            if(name.StartsWith("s") || name.StartsWith("r"))
            {
                return new DataTemplate(typeof(BigTemplateView));
            }
            return new DataTemplate(typeof(SmallTemplateView));
        }
    }
}
