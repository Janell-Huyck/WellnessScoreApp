namespace WellnessScoreApp
{
    public partial class MainPage : ContentPage
    {
        string selectedGender = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            selectedGender = "male";
            FrameMale.BorderColor = Colors.Blue;
            FrameFemale.BorderColor = Colors.Transparent;

        }
    }
}
