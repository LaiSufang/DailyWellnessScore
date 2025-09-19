namespace DailyWellness;

public partial class WellnessScorePage : ContentPage
{
    string choice = "female";

    public WellnessScorePage()
	{
		InitializeComponent();
	}

    private void TapMale_Tapped(object sender, TappedEventArgs e)
    {
        MaleFrame.BorderColor = Color.FromArgb("#00FFFF");
        choice = "Male";
    }

    private void TapFemale_Tapped(object sender, TappedEventArgs e)
    {
        FemaleFrame.BorderColor = Color.FromArgb("00FFFF");
        choice = "Female";    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("You chose:", choice, "OK");
        Application.Current.MainPage = new ScoreCapturePage(choice);

    }
}