using FileExplorerWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using MaterialDesignThemes.Wpf;

namespace FileExplorerWPF
{
    /// <summary>
    /// Interaction logic for RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        public static FileInformation rename = new FileInformation();
        string type; string old_name;
        public RenameWindow(string Name, string FullPath, string Size, string Extention, string DateModified, string type, PackIconKind icon)
        {
            InitializeComponent();
            txt_path.Text = FullPath;
            txt_fileName.Text = Name;
            txt_DateModified.Text = DateModified;
            txt_Extention.Text = Extention;
            txt_Size.Text = Size;
            this.type = type;
            old_name = FullPath;
            ////////////////////////////////////////////////////////////////////////////
            rename.FullPath = FullPath;
            rename.Name = Name;
            rename.dateTime = DateTime.Now.ToString();
            rename.Extension = Extention;
            rename.size = Size;
            rename.IsFolder = true;
            rename.kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder;
            if (type == "file")
            {

                rename.IsFolder = false;
                rename.kind_file = icon;
            }
            ///////////////////////////////////////////////////////////////////////////

        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_rename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] files = old_name.Split('\\'); string newpath = "";
                for (int i = 0; i < files.Length - 1; i++)
                {
                    newpath += files[i] + '\\';
                }
                if (type.Equals("file"))
                {

                    File.Move(old_name, newpath + txt_fileName.Text + txt_Extention.Text);
                    rename.FullPath = newpath + txt_fileName.Text + txt_Extention.Text;
                    rename.Name = txt_fileName.Text;
                    //////////////////////////////////////////////////
                    string itemDeleted = files[files.Length - 1].Split('.')[0];
                    List<FileInformation> items = ((MainWindow)Application.Current.MainWindow).listData;
                    for (int i = 0; i < items.Count; i++)
                        if (items[i].Name == itemDeleted)
                            items.RemoveAt(i);
                    items.Add(rename);
                    ((MainWindow)Application.Current.MainWindow).listData = items;
                    ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = null;
                    ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = items;
                    ((MainWindow)Application.Current.MainWindow).sortItems();
                    ////////////////////////////////////////////////


                }
                else if (type.Equals("folder"))
                {
                    string[] files1 = old_name.Split('\\');
                    Directory.Move(old_name, newpath + txt_fileName.Text);
                    rename.FullPath = newpath + txt_fileName.Text;
                    rename.Name = txt_fileName.Text;
                    ///////////////////////////////////////////////////////
                    string itemDeleted = files1[files1.Length - 1];
                    List<FileInformation> items = ((MainWindow)Application.Current.MainWindow).listData;
                    for (int i = 0; i < items.Count; i++)
                        if (items[i].Name == itemDeleted)
                            items.RemoveAt(i);
                    items.Add(rename);
                    ((MainWindow)Application.Current.MainWindow).listData = items;
                    ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = null;
                    ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = items;
                    ((MainWindow)Application.Current.MainWindow).sortItems();
                    ////////////////////////////////////////////////////////
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }
}
