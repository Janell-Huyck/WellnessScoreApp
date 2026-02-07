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
    }
}
