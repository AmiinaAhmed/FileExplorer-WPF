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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes;
using System.IO;


namespace FileExplorerWPF
{

    partial class FileItem : UserControl
    {
        public static string sourcepath = "", fileName = "", type, type_trans = "";
        public static FileInformation copyCutItem = new FileInformation();

        public FileItem()
        {
            InitializeComponent();

        }
        private static void DirectorDelete(string sourceDirName, bool deleteSub)
        {
            Directory.Delete(sourceDirName, true);
        }
        private void MouseEnterColorChange(object sender, MouseEventArgs e)
        {
            BeginStoryboard(Resources["LightsUpBackgroundAnimation"] as Storyboard);
        }

        private void MouseLeaveColorChange(object sender, MouseEventArgs e)
        {
            BeginStoryboard(Resources["LightsDownBackgroundAnimation"] as Storyboard);
        }
        private void Proparties_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MyPackIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.Folder)
                {
                    RenameWindow RW = new RenameWindow(txtName.Text, this.Tag.ToString(), Size.Tag.ToString(), txtExtention.Text, dateTImetxt.Tag.ToString(), "folder", MyPackIcon.Kind);
                    RW.Show();
                }
                else
                {

                    RenameWindow RW = new RenameWindow(txtName.Text, this.Tag.ToString(), Size.Tag.ToString(), txtExtention.Text, dateTImetxt.Tag.ToString(), "file", MyPackIcon.Kind);
                    RW.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToLoad_(object sender, RoutedEventArgs e)
        {
            if (MyPackIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.Disc)
                Options.Visibility = Visibility.Hidden;

        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            string[] files1 = this.Tag.ToString().Split('\\');
            fileName = files1[files1.Length - 1];
            sourcepath = this.Tag.ToString();
            type_trans = "copy";
            type = "folder";
            ////////////////////////////////////////////////////////
            copyCutItem.dateTime = dateTImetxt.Tag.ToString();
            copyCutItem.FullPath = this.Tag.ToString();
            copyCutItem.size = Size.Tag.ToString();
            copyCutItem.Extension = txtExtention.Text;
            copyCutItem.Name = fileName;
            copyCutItem.IsFolder = true;
            copyCutItem.kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder;
            ///////////////////////////////////////////////////////////////////
            if (MyPackIcon.Kind != MaterialDesignThemes.Wpf.PackIconKind.Folder && MyPackIcon.Kind != MaterialDesignThemes.Wpf.PackIconKind.Disc)
            {
                type = "file";
                //////////////////////////////////////////////////////////////////
                copyCutItem.IsFolder = false;
                copyCutItem.Name = fileName.Split('.')[0];
                /////////////////////////////////////////////////////////////////
                //////////////////////////////////////
                copyCutItem.kind_file = MyPackIcon.Kind;

                ///////////////////////////////////////////////////////////////////
            }


        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            string[] files1 = this.Tag.ToString().Split('\\');
            fileName = files1[files1.Length - 1];
            sourcepath = this.Tag.ToString();
            type_trans = "cut";
            type = "folder";
            ////////////////////////////////////////////////////////
            copyCutItem.dateTime = dateTImetxt.Tag.ToString();
            copyCutItem.FullPath = this.Tag.ToString();
            copyCutItem.size = Size.Tag.ToString();
            copyCutItem.Extension = txtExtention.Text;
            copyCutItem.Name = fileName;
            copyCutItem.IsFolder = true;
            copyCutItem.kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder;
            ///////////////////////////////////////////////////////////////////
            if (MyPackIcon.Kind != MaterialDesignThemes.Wpf.PackIconKind.Folder && MyPackIcon.Kind != MaterialDesignThemes.Wpf.PackIconKind.Disc)
            {
                type = "file";
                ////////////////////////////////////////////////////////////////
                copyCutItem.kind_file = MyPackIcon.Kind;
                copyCutItem.IsFolder = false;
                copyCutItem.Name = fileName.Split('.')[0];
                /////////////////////////////////////////////////////////////////
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string[] files1 = this.Tag.ToString().Split('\\');
            string fileName2 = files1[files1.Length - 1];
            string sourcepath2 = this.Tag.ToString();
            if (MyPackIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.Folder)
            {

                string itemDeleted = fileName2;
                DirectorDelete(sourcepath2, true);
                content_all_info.Children.Clear();
                ///////////////////////////////////////////////////////
                List<FileInformation> items = ((MainWindow)Application.Current.MainWindow).listData;
                for (int i = 0; i < items.Count; i++)
                    if (items[i].Name == itemDeleted)
                        items.RemoveAt(i);

                ((MainWindow)Application.Current.MainWindow).listData = items;
                ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = null;
                ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = items;
                ////////////////////////////////////////////////////////



            }
            else
            {
                File.Delete(sourcepath2);
                content_all_info.Children.Clear();
                string itemDeleted = fileName2.Split('.')[0];
                List<FileInformation> items = ((MainWindow)Application.Current.MainWindow).listData;
                for (int i = 0; i < items.Count; i++)
                    if (items[i].Name == itemDeleted)
                        items.RemoveAt(i);
                ((MainWindow)Application.Current.MainWindow).listData = items;
                ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = null;
                ((MainWindow)Application.Current.MainWindow).pnlItems.ItemsSource = items;


            }
           ((MainWindow)Application.Current.MainWindow).loadNotification(fileName2, "Deleted");





        }



    }
}