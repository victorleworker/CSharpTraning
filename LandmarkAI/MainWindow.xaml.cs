using LandmarkAI.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files(*.png;*.jpg)|*.png;*.jpg;*.jpeg| All files(*.*)|*.*";
         //   dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));
                MakePredictionAsync(fileName);
            }

        }

        private async void MakePredictionAsync(string fileName)
        {
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/97dfc669-38c6-4dc4-9206-298947dd8050/image?iterationId=21c5feb8-292d-4ea6-b881-6ff9a14915fc";
            string prediction_key = "67ac619a42c5491bbe484bc00524ae80";
            string content_type = "application/octet-stream";
            var file = File.ReadAllBytes( fileName);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", prediction_key);            
                using(var content=new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content_type);
                    var response=await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    List<Prediction> predictions = (JsonConvert.DeserializeObject<CustomVision>(responseString)).predictions;
                    predictionsListView.ItemsSource = predictions;
                }
            }

        }
    }
}
