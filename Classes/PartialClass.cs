using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GazLink
{
    public partial class Client
    {
        public string FIO { get => $"{LastName} {FirstName} {MiddleName}"; }
    }

    public partial class Product
    {
        public ImageSource ImgSource
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Photo))
                    return null;

                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "\\" + Photo.Trim();

                return new BitmapImage(new Uri(projectDirectory));
            }
        }

        public int count = 1;
        public string countProductInCheque
        {
            get
            {
                return Convert.ToString(count);
            }
        }

        public int PriceCount
        {
            get
            {
                if (count == 1)
                {
                    return Convert.ToInt32(Price);
                }
                else
                {
                    return Convert.ToInt32(Price) * count;
                }
            }
        }
    }
}
