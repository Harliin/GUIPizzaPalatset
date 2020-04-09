using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Markup;
using AdminGui.Views.Pages;

namespace AdminGui
{

    public class TypeToPageConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((MenyePages)value){
                case MenyePages.Home: 
                    {
                        Hem h = new Hem();
                        h.DataContext = new HomeViewModel();
                        return h;
                    }

                case MenyePages.PizzaMenu:
                    {
                        Pizzas P = new Pizzas();
                        P.DataContext = new PizzasViewModel();
                        return P;
                    }
                 
                case MenyePages.EditPizza:
                    {
                        Edit E = new Edit();
                        E.DataContext = new EditPizzViewModel();
                        return E;
                    }
                case MenyePages.NewPizza:
                    {

                    NewPizza NP = new NewPizza();
                    NP.DataContext = new NewPizzaViewModel();
                    return NP;
                    }


                case MenyePages.Emplyees:
                    {
                        Arbetare A = new Arbetare();
                        A.DataContext = new EmployesViewModel();
                        return A;
                    }

                case MenyePages.NewEmplyee:
                    {
                     NyArbtare NA = new NyArbtare();
                        NA.DataContext = new NewEmployeeViewModel();
                        return NA;
                    } 
                     
                case MenyePages.ChangeEmployee:
                    {
                    ChangeEmployee CE = new ChangeEmployee();
                    CE.DataContext = new ChangeEmployeeViewModel();
                    return CE;
                    }

                case MenyePages.IngredentsMenu:
                    {
                    Ingredent I = new Ingredent();
                    I.DataContext = new IngridentViewModel();
                    return I;
                    }

                case MenyePages.Ovrigt:
                    {
                    Ovright O = new Ovright();
                    O.DataContext = new OvrightVewmodel();
                    return O;
                    }
                case MenyePages.NewOvrigt:
                    {
                        NewOvright NO = new NewOvright();
                        NO.DataContext = new NewOvrigtViewModel();
                        return NO;

                    }

                default:    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new TypeToPageConverter();
        }
    }
}
