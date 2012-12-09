using System;
using System.Windows.Controls;

using Microsoft.Practices.Unity;

using Module1.ViewModels;

namespace Module1.Views
{
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();
        }

        // Shows how to specify the view model dependency using a
        // Dependency attribute, rather than as a constructor parameter.
        [Dependency]
        public EditViewModel ViewModel
        {
            set { this.DataContext = value; }
        }
    }
}
