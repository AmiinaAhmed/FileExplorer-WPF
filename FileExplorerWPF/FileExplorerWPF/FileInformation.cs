using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;

namespace FileExplorerWPF
{
    public class FileInformation
    {
        public string dateTime { get; set; }
        public string size { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string Extension { get; set; }
        public bool IsFolder { get; set; }
        public BitmapImage ImagePath { get; set; }
        public bool IsComputer { get; set; }
        public PackIconKind kind_file { get; set; }
    }
}
