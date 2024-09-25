using Module02Exercise01.ViewModel;
using System.Threading.Tasks;
namespace Module02Exercise01.View;

public partial class AddEmployee : ContentPage
{
	public AddEmployee()
	{
		InitializeComponent();
	}

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High
                });
            }

            if (location != null)
            {
                var placemarks = await Geocoding.Default.GetPlacemarksAsync
                    (location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    AddressLabelProvince.Text = $"{placemark.SubAdminArea}";
                    AddressLabelMunicipality.Text = $"{placemark.Locality}";
                    AddressLabelCoordinates.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";
                }
                else
                {
                    AddressLabelMunicipality.Text = "Unable to determine the Province";
                    AddressLabelProvince.Text = "Unable to determine the Province";
                    AddressLabelCoordinates.Text = "Unable to determine the Coordinates";
                }
                //end of Geocoding
            }

            else
            {
                AddressLabelMunicipality.Text = "Unable to determine the Province";
                AddressLabelProvince.Text = "Unable to determine the Province";
                AddressLabelCoordinates.Text = "Unable to determine the Coordinates";
            }

        }
        catch (Exception ex)
        {
            AddressLabelMunicipality.Text = $"Error: {ex.Message}";
            AddressLabelProvince.Text = $"Error: {ex.Message}";
            AddressLabelCoordinates.Text = $"Error: {ex.Message}";
        }
    }

    private async void OnCapturePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                //Capture a photo using MediaPicker
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An Error has occured: {ex.Message}", "OK");
        }
    }
    //Load Photo and display it in the Image container

    private async Task LoadPhotoAsync(FileResult photo)
    {
        if (photo == null)
            return;

        Stream stream = await photo.OpenReadAsync();

        CaptureImage.Source = ImageSource.FromStream(() => stream);
    }
}