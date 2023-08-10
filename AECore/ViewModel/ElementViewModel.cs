using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AECore.Model;

namespace AECore.ViewModel
{
    internal class ElementViewModel : DependencyObject
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        //свойство dependency object
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ElementViewModel), new PropertyMetadata(""));

        //конструктор класса
        public ElementViewModel()
        {
            Element elem = Element.GetExample();
            Name = elem.Name;
        }
    }
}
