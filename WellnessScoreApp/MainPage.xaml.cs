namespace WellnessScoreApp
{
    public partial class MainPage : ContentPage
    {
        string selectedGender = "";
        public MainPage()
        {
            InitializeComponent();
            SliderSleep.ValueChanged += OnInputChanged;
            SliderStress.ValueChanged += OnInputChanged;
            SliderActivity.ValueChanged += OnInputChanged;
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
            UpdateResults();
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            selectedGender = "female";
            UpdateColors();
            UpdateResults();
        }

        private void OnInputChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateResults();
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
            UpdateResults();
            ResultsBox.IsVisible = true;
        }

        private void UpdateResults()
        {
            int score = CalculateWellnessScore();
            string rating = GetRating(score);
            LblScore.Text = score.ToString();
            LblRating.Text = rating;
            LblRecommendation.Text = GetRecommendation(rating);
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

        private string GetRecommendation(string rating)
        {
            switch (rating)
            {
                case "Excellent":
                    return selectedGender == "male"
                        ? "You're a champion. Keep crushing those weights, eating steak, and leading. Maybe grunt a little louder so everyone knows you're winning."
                        : "You're doing so well! Remember to stay pretty while you exercise—maybe some yoga in a cute outfit. Don't forget to smile; it's good for your face.";
                case "Good":
                    return selectedGender == "male"
                        ? "You're slipping. Man up: go to bed earlier, do some push-ups, and drink water like a normal human. No excuses."
                        : "Aww, rough day? Try a nice bubble bath, a balanced breakfast so you don't get hangry, and a little walk. Maybe paint your nails after—self-care!";
                case "Fair":
                    return selectedGender == "male"
                        ? "Get it together. More sleep, less caffeine, and move your body. Sitting on the couch isn't a hobby."
                        : "Sweetie, you're run ragged. Less screen time, more meditation and journaling. Have you tried a calming face mask? So relaxing.";
                case "Poor":
                    return selectedGender == "male"
                        ? "Rest day. No heavy lifting. Hydrate, take a short walk, and don't be a hero. The gym will still be there tomorrow."
                        : "You should wear extra pink ribbons in your hair today. Cute little girly girls like you should take good care of their hair. Maybe a nap, then some gentle yoga. So delicate.";
                default:
                    return "";
            }
        }
    }
}
