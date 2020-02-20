using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Locker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LayoutGrid : ContentPage
	{
        int rowHeightValue = 1;
        public LayoutGrid ()
		{
			InitializeComponent ();
            sliderHeight.ValueChanged += SliderHeight_ValueChanged;
        }
        void SliderHeight_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue * 10 > rowHeightValue + .5 && rowHeightValue < 5)
            {
                rowHeightValue++;
            }
            if (e.NewValue * 10 < rowHeightValue - .5 && rowHeightValue > 1)
            {
                rowHeightValue--;
            }
            firstRow.Height = new GridLength(rowHeightValue, GridUnitType.Star);
        }
    }
}