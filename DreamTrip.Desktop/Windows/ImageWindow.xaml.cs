using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DreamTrip.Desktop.ViewModels;
using Path = System.Windows.Shapes.Path;

namespace DreamTrip.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        private static readonly string PathAPI = MainWindowViewModel.PathAPI + "ImageSource";
        public ImageWindow()
        {
            InitializeComponent();
        }
        
        //async public Task<HttpResponseMessage> UploadImage()
        //{
        //    var form = new MultipartFormDataContent();

        //    var fs = File.OpenRead(ImageFile.Text);
        //    var streamContent = new StreamContent(fs);

        //    var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
        //    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

        //    form.Add(imageContent, "image");
        //    var response = MainWindowViewModel.Client.PostAsync(PathAPI, form).Result;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ImageFile.Text = filename;
            }
        }
    }
}
