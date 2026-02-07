namespace WellnessScoreApp
{
    public partial class MainPage : ContentPage
    {
        string selectedGender = "";
        public MainPage()
        {
            InitializeComponent();
            SetGenderMale();
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            SetGenderMale();
        }

        private void SetGenderMale()
        {
            selectedGender = "male";
            FrameMale.BorderColor = Colors.Blue;
            FrameFemale.BorderColor = Colors.Transparent;
            MainScrollView.BackgroundColor = Colors.PowderBlue;
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            SetGenderFemale();
        }

        private void SetGenderFemale()
        {
            selectedGender = "male";
            FrameMale.BorderColor = Colors.Transparent;
            FrameFemale.BorderColor = Colors.HotPink;
            MainScrollView.BackgroundColor = Colors.LightPink;
        }
    }
}
