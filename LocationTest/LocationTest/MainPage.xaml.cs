using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocationTest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    async Task OnRefreshClicked(object sender, EventArgs e)
	    {
            Console.WriteLine("refresh location");
	        if (App.DeviceLocation == null)
	        {
	            App.DeviceLocation = await App.GetCurrentLocation();
	        }

	        locationText.Text = $"Location: {App.DeviceLocation.Latitude}, {App.DeviceLocation.Longitude}";
        }
    }
}
