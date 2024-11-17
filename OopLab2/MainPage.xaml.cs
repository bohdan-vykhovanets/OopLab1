using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace OopLab2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnFileButtonClicked(object sender, EventArgs e)
        {
            FileMenu.IsVisible = !FileMenu.IsVisible; // Toggle visibility of the File menu
        }

        private async void OnOpenFileClicked(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick an XML file",
                FileTypes = FilePickerFileType.Png
            });

            if (result != null)
            {
                using var stream = await result.OpenReadAsync();
                using var reader = new StreamReader(stream);
                XmlTextBox.Text = await reader.ReadToEndAsync();
            }
            FileMenu.IsVisible = false;
        }

        private async void OnSaveFileClicked(object sender, EventArgs e)
        {
            // Logic to save the XML content; this depends on platform-specific implementations.
            // You may use DependencyService for this, or platform-specific code in MAUI.
            FileMenu.IsVisible = false;
        }

        private async void OnShowHtmlButtonClicked(object sender, EventArgs e)
        {
            // Logic to convert XML to HTML and display it
        }

        private void OnClearAllButtonClicked(object sender, EventArgs e)
        {
            SearchQueryTextBox.Text = string.Empty;
            XmlTextBox.Text = string.Empty;
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0); // Closes the application
        }
    }
}
