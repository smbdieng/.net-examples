using System;
using System.Windows.Controls;

using Module2.ViewModels;

namespace Module2.Views
{
    public partial class CatalogView : UserControl
    {
        public CatalogView( CatalogViewModel viewModel )
        {
            InitializeComponent();

            // Set the ViewModel as this View's data context.
            this.DataContext = viewModel;
        }
    }
}
