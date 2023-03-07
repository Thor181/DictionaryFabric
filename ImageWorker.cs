using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DictionaryFabricApplication
{
    internal class ImageWorker
    {
        internal static byte[] ConvertImageToByteArray(string fileImage)
        {
            byte[] imageData;
            using (System.IO.FileStream fs = new System.IO.FileStream(fileImage, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }
            return imageData;
        }

        internal static BitmapImage LoadImage(out byte[] imageByteArray)
        {
            OpenFileDialog loadPhoto = new OpenFileDialog();
            loadPhoto.Filter = "Файлы изображений|*.bmp;*.jpg;*.gif;*.png;*.tif|Все файлы|*.*";
            if ((bool)loadPhoto.ShowDialog()!)
            {
                var image = new BitmapImage(new Uri(loadPhoto.FileName));
                imageByteArray = ImageWorker.ConvertImageToByteArray(loadPhoto.FileName);
                return image;
            }
            imageByteArray = new byte[0];
            return new BitmapImage();
        }
    }
}
