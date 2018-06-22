using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Location = Xamarin.Essentials.Location;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace LocationTest
{
	public partial class App : Application
	{
	    public static Location DeviceLocation;

		public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override async void OnStart ()
		{
			// Handle when your app starts
		    DeviceLocation = await GetCurrentLocation();
		}

	    public static async Task<Location> GetCurrentLocation()
	    {
	        try
	        {
	            var location = await Geolocation.GetLastKnownLocationAsync();

	            if (location != null)
	            {
	                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
	                return location;
	            }
            }
	        catch (FeatureNotSupportedException fnsEx)
	        {
                // Handle not supported on device exception
                Console.WriteLine("Feature not supported");
	            throw;
	        }
	        catch (PermissionException pEx)
	        {
	            // Handle permission exception
	            Console.WriteLine("Permission not granted");
	            throw;
	        }
            catch (Exception ex)
	        {
	            // Unable to get location
                Console.WriteLine(ex);
	            throw;
            }

            Console.WriteLine("Could not get location");
	        return null;
	    }

	    protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
