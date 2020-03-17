using GUI_Kock.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Kock.Views
{
    /// <summary>
    /// Interaction logic for PreparingOrderView.xaml
    /// </summary>
    public partial class PreparingOrderView : ReactiveUserControl<PreparingOrderViewModel>
    {
        public PreparingOrderView()
        {
            InitializeComponent();
        }
    }
}
