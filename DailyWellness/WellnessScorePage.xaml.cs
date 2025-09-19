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
        FemaleFrame.BorderColor = Color.FromArgb("#808080");
        choice = "Male";
    }

    private void TapFemale_Tapped(object sender, TappedEventArgs e)
    {
        FemaleFrame.BorderColor = Color.FromArgb("#00FFFF");
        MaleFrame.BorderColor = Color.FromArgb("#808080");
        choice = "Female";    
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //double sleepHrs = double.Parse(LbSleepHours.Text);
        //double stressLvl = double.Parse(LbStressLevel.Text);
        //double activityMins = double.Parse(LbActivityMinutes.Text);
        double activityMins = SliderActivityMinutes.Value;
        double sleepHrs = SliderSleepHours.Value;
        double stressLvl = SliderStressLevel.Value;

        double wellnessScore = (sleepHrs * 8) - (stressLvl * 5) + (activityMins * 0.5);
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
            if (choice.Equals("Male"))
            {
                if (wellnessScore >= 80 && wellnessScore <= 100)
                {
                    genderBasedStatus = maleExcellent;
                    statusLb = " (Excellent)";
                }
                else if (wellnessScore >= 60 && wellnessScore < 80)
                {
                    genderBasedStatus = maleGood;
                    statusLb = " (Good)";
                }
                else if (wellnessScore >= 40 && wellnessScore < 60)
                {
                    genderBasedStatus = maleFair;
                    statusLb = " (Fair)";
                }
                else
                {
                    genderBasedStatus = malePoor;
                    statusLb = " (Poor)";
                }
            }
            else
            {
                if (wellnessScore >= 80 && wellnessScore <= 100)
                {
                    genderBasedStatus = femaleExcellent;
                    statusLb = " (Excellent)";
                }
                else if (wellnessScore >= 60 && wellnessScore < 80)
                {
                    genderBasedStatus = femaleGood;
                    statusLb = " (Good)";
                }
                else if (wellnessScore >= 40 && wellnessScore < 60)
                {
                    genderBasedStatus = femaleFair;
                    statusLb = " (Fair)";
                }
                else
                {
                    genderBasedStatus = femalePoor;
                    statusLb = " (Poor)";
                }
            }
        }
        int roundedScore = (int)Math.Round(wellnessScore);
        DisplayAlert("Your wellness score is: " + roundedScore.ToString() + statusLb, genderBasedStatus, "OK");

    }
}