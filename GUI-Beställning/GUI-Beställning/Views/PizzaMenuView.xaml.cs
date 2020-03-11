﻿using GUI_Beställning.ViewModels;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for PizzaMenuView.xaml
    /// </summary>
    public partial class PizzaMenuView : UserControl
    {
        public PizzaMenuView()
        {
            InitializeComponent();

            this.DataContext = new PizzaMenuViewModel();
        }
    }
}
