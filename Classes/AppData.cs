using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GazLink.Classes
{
    class AppData
    {
        public static Frame frame;
        public static GazLinkEntities context = new GazLinkEntities();
        public static int idApp;
        public static Worker workerLogIn;
        public static Worker workr;
        public static Product prod;
        public static Client client;
        public static bool checkEdit;
    }
}
