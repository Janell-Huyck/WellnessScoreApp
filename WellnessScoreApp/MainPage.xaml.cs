namespace WellnessScoreApp
{
    public partial class MainPage : ContentPage
    {
        string selectedGender = "";
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            selectedGender = "male";
            UpdateColors();
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            selectedGender = "male";
            UpdateColors();
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            selectedGender = "female";
            UpdateColors();
        }

        private void UpdateColors()
        {
            var prefix = selectedGender == "male" ? "Male" : "Female";
            var mainColor = (Color)Application.Current.Resources[prefix + "Main"];
            var accentColor = (Color)Application.Current.Resources[prefix + "Accent"];

            MainScrollView.BackgroundColor = mainColor;

            FrameMale.BorderColor = selectedGender == "male" ? accentColor : Colors.Gray;
            FrameFemale.BorderColor = selectedGender == "female" ? accentColor : Colors.Gray;

            SliderSleep.ThumbColor = accentColor;
            SliderSleep.MinimumTrackColor = accentColor;

            SliderStress.ThumbColor = accentColor;
            SliderStress.MinimumTrackColor = accentColor;

            SliderActivity.ThumbColor = accentColor;
            SliderActivity.MinimumTrackColor = accentColor;
        }

        private void OnBtnSubmitClick(object sender, EventArgs e)
        {
            int score = CalculateWellnessScore();
            LblScore.Text = score.ToString();
            string rating = GetRating(score);
            LblRating.Text = rating;
            ResultsBox.IsVisible = true;
        }

        private int CalculateWellnessScore()
        {
            double sleepHours = SliderSleep.Value;
            double stressLevel = SliderStress.Value;
            double activityMinutes = SliderActivity.Value;

            double rawScore = (sleepHours * 8) - (stressLevel * 5) + (activityMinutes * 0.5);

            if (rawScore < 0) rawScore = 0;
            if (rawScore > 100) rawScore = 100;

            return (int)Math.Round(rawScore);
        }

        private string GetRating(int score)
        {
            switch(score)
            {
                case >= 80: return "Excellent";
                case >= 60: return "Good";
                case >= 40: return "Fair";
                default: return "Poor";
            }
        }
    }
}
