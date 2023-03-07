using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DictionaryFabricApplication
{
    internal class ImageConverter
    {
        internal static ImageSource ByteArrayToImageSource(byte[] sourceArray)
        {
            BitmapImage bitmapImage = new();
            using (MemoryStream ms = new MemoryStream(sourceArray))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
    }
}
