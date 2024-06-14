using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.ui.Models
{
    class Sobre
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoURL => "https://aka.ms/maui";
        public string Menssage => "Este aplicativo foi desenvolvido em .Net Maui com XAML e C#";
    }
}
