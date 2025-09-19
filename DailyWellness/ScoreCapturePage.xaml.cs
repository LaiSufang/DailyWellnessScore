using Android.Speech.Tts;
using Java.Text;

namespace DailyWellness;

public partial class ScoreCapturePage : ContentPage
{
	string genderChoice;

    public ScoreCapturePage(string choice)
	{
		InitializeComponent();
		genderChoice = choice;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		double sleepHrs = double.Parse(LbSleepHours.Text);
		double stressLvl = double.Parse(LbStressLevel.Text);
		double activityMins = double.Parse(LbActivityMinutes.Text);
		double wellnessScore = (sleepHrs*8) - (stressLvl*5) + (activityMins*0.5);
		string maleExcellent = "Maintain routine; include resistance training 2–3× per week; ensure protein intake across meals.";
		string femaleExcellent = "Keep strong habits; add yoga/pilates for recovery; prioritize calcium + vitamin D intake.";
		string maleGood = "Improve recovery with an earlier bedtime; add 15 min of light cardio or stretching; keep hydration steady.";
		string femaleGood = "Boost energy with a balanced breakfast; add 15 min of walking; focus on iron-rich foods if feeling low.";
		string maleFair = "Aim for +1 hour of sleep; reduce caffeine after noon; schedule light mobility or an easy walk.";
		string femaleFair = "Increase sleep consistency; reduce evening screen time; include calming routines like meditation or journaling.";
		string malePoor = "Rest today; avoid strenuous workouts; focus on hydration and 20–30 min of gentle walking.";  
		string femalePoor = "Prioritize rest and self-care; consider a short nap if possible; gentle yoga/stretching only.";

		string genderBasedStatus = "";
        string statusLb = "";

		if (wellnessScore < 0) wellnessScore = 0;
		else if (wellnessScore > 100) wellnessScore = 100;
		else
		{
            if (genderChoice.Equals("Male"))
            {
                if (wellnessScore >= 80 && wellnessScore <= 100)
                {
                    genderBasedStatus = maleExcellent;
                    statusLb = "Excellent";
                }
                else if (wellnessScore >= 60 && wellnessScore < 80)
                {
                    genderBasedStatus = maleGood;
                    statusLb = "Good";
                }
                else if (wellnessScore >= 40 && wellnessScore < 60)
                {
                    genderBasedStatus = maleFair;
                    statusLb = "Fair";
                }
                else
                {
                    genderBasedStatus = malePoor;
                    statusLb = "Poor";
                }
            }
            else
            {
                if (wellnessScore >= 80 && wellnessScore <= 100)
                {
                    genderBasedStatus = femaleExcellent;
                    statusLb = "Excellent";
                }
                else if (wellnessScore >= 60 && wellnessScore < 80)
                {
                    genderBasedStatus = femaleGood;
                    statusLb = "Good";
                }
                else if (wellnessScore >= 40 && wellnessScore < 60)
                {
                    genderBasedStatus = femaleFair;
                    statusLb = "Fair";
                }
                else
                {
                    genderBasedStatus = femalePoor;
                    statusLb = "Poor";
                }
            }
        }
        await DisplayAlert("Your wellness score is: " + wellnessScore.ToString() + statusLb, genderBasedStatus, "OK");
        Application.Current.MainPage = new WellnessScorePage();

    }
}