using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Interop;
using MaterialDesignThemes.Wpf;


namespace FileExplorerWPF
{

    public partial class MainWindow : Window
    {

        //public static long DirSize(DirectoryInfo dir)
        //{
        //    try
        //    {
        //        return dir.GetFiles().Sum(fi => fi.Length) +
        //             dir.GetDirectories().Sum(di => DirSize(di));
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
        //static long GetDirectorySize(string p)
        //{
        //    // 1.
        //    // Get array of all file names.
        //    string[] a = Directory.GetFiles(p, "*.*");

        //    // 2.
        //    // Calculate total bytes of all files in a loop.
        //    long b = 0;
        //    foreach (string name in a)
        //    {
        //        // 3.
        //        // Use FileInfo to get length of each file.
        //        FileInfo info = new FileInfo(name);
        //        b += info.Length;
        //    }
        //    // 4.
        //    // Return total size
        //    return b;
        //}
        public List<FileInformation> listData = new List<FileInformation>();

        Stack<Histrory> backHistory = new Stack<Histrory>();
        static string currentpath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true) pnlItems.ItemsSource = DataManeger.GetItems(System.IO.Path.GetDirectoryName(ofd.FileName));
        }
        private void View_MyDesktop(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.Desktop();
            currentpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop");
            backHistory.Push(new Histrory(currentpath, false));
        }
        private void View_MyComputer(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.GetDrives();
            backHistory.Push(new Histrory("Drives", true));

        }
        private void Open(object sender, MouseButtonEventArgs e)
        {
            if (pnlItems.SelectedItems.Count == 1)
            {
                FileInformation info = pnlItems.SelectedItems[0] as FileInformation;
                currentpath = info.FullPath;


                if (info.IsFolder)
                {
                    pnlItems.ItemsSource = DataManeger.GetItems(info.FullPath);
                    backHistory.Push(new Histrory(info.FullPath, false));
                    if (backHistory.Count > 1)
                        back_btn.Foreground = new SolidColorBrush(Colors.White);
                }
                else if (info.IsComputer)
                {
                    pnlItems.ItemsSource = DataManeger.GetDrives();
                    backHistory.Push(new Histrory(info.FullPath, true));
                    if (backHistory.Count > 1)
                        back_btn.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(info.FullPath);
                        }
                        catch
                        {
                            MessageBox.Show("It Can't Load The File");
                        }
                    }
                }
            }
            pnlItems.Items.Refresh();
            Option.Visibility = Visibility.Visible;
            GetData();
            sortCombBox.SelectedIndex = -1;
            sortCombBox.Text = "Sort By.....";
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            backHistory = new Stack<Histrory>();
            ActivityDisplay.Visibility = Visibility.Hidden;
            GridPrincipal.Visibility = Visibility.Hidden;
            sortCombBox.SelectedIndex = -1;
            sortCombBox.Text = "Sort By.....";
            Option.Visibility = Visibility.Hidden;
            pnlItems.Visibility = Visibility.Visible;
            sortStack.Visibility = Visibility.Visible;
            View_MyComputer(sender, e);
            GetData();
            back_btn.Visibility = Visibility.Visible;
            back_btn.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void View_MyDownloads(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = null;
            pnlItems.ItemsSource = DataManeger.Downloads();
            currentpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            backHistory.Push(new Histrory(currentpath, false));
        }
        private void View_MyDocuments(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.Documents();
            currentpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents");
            backHistory.Push(new Histrory(currentpath, false));
        }
        private void View_MyMusics(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.Music();
            currentpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Music");
            backHistory.Push(new Histrory(currentpath, false));
        }
        private void View_MyPictures(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.Pictures();
            currentpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Pictures");
            backHistory.Push(new Histrory(currentpath, false));

        }
        private void View_MyVideos(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.Videos();
            currentpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Videos");
            backHistory.Push(new Histrory(currentpath, false));
        }
        private void Close_icon(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
            }
        }
        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (137 + (45 * index)), 0, 0);
        }


        private void Location_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            backHistory = new Stack<Histrory>();
            int index = Location.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    sortStack.Visibility = Visibility.Hidden;
                    Option.Visibility = Visibility.Hidden;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Hidden;
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Home());
                    break;
                case 1:

                    sortStack.Visibility = Visibility.Visible;
                    Option.Visibility = Visibility.Visible;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Visible;
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray); ;
                    View_MyDesktop(sender, e);
                    break;
                case 2:
                    sortStack.Visibility = Visibility.Visible;
                    Option.Visibility = Visibility.Visible;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Visible;
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray); ;
                    View_MyDownloads(sender, e);
                    pnlItems.Items.Refresh();
                    break;
                case 3:
                    sortStack.Visibility = Visibility.Visible;
                    Option.Visibility = Visibility.Visible;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Visible;
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray); ;
                    View_MyDocuments(sender, e);
                    pnlItems.Items.Refresh();
                    break;
                case 4:
                    sortStack.Visibility = Visibility.Visible;
                    Option.Visibility = Visibility.Visible;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Visible;
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray); ;
                    View_MyPictures(sender, e);
                    pnlItems.Items.Refresh();
                    break;
                case 5:
                    sortStack.Visibility = Visibility.Visible;
                    Option.Visibility = Visibility.Visible;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Visible;
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray); ;
                    View_MyMusics(sender, e);
                    pnlItems.Items.Refresh();
                    break;
                case 6:
                    sortStack.Visibility = Visibility.Visible;
                    Option.Visibility = Visibility.Visible;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    ActivityDisplay.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    pnlItems.Visibility = Visibility.Visible;
                    back_btn.Visibility = Visibility.Visible;
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray);
                    View_MyVideos(sender, e);
                    pnlItems.Items.Refresh();
                    break;
                case 7:
                    back_btn.Visibility = Visibility.Hidden;
                    back_btn.IsEnabled = false;
                    sortStack.Visibility = Visibility.Hidden;
                    Option.Visibility = Visibility.Hidden;
                    sortCombBox.SelectedIndex = -1;
                    sortCombBox.Text = "Sort By.....";
                    pnlItems.Visibility = Visibility.Hidden;
                    GridPrincipal.Visibility = Visibility.Hidden;
                    ActivityDisplay.Visibility = Visibility.Visible;
                    ListViewMenu.Items.Clear();
                    ActivityLogContent load = new ActivityLogContent();
                    List<Activity> activities = load.RetriveData();
                    for (int i = activities.Count - 1; i > -1; i--)
                        addNotification(activities[i]);
                    break;
                default:
                    break;
            }

            GetData();
        }

        ///////////////////////////////sort///////////////////////////////////////////////////
        private void SortCombBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sortItems();
        }
        public void sortItems()
        {
            switch (sortCombBox.SelectedIndex)
            {
                case 0:
                    if (pnlItems.IsVisible)
                    {

                        List<FileInformation> listOfItems = new List<FileInformation>();
                        for (int i = 0; i < pnlItems.Items.Count; i++)
                            listOfItems.Add((FileInformation)pnlItems.Items[i]);
                        listOfItems = listOfItems.OrderBy(x => x.dateTime).ToList();
                        listOfItems.Reverse();
                        pnlItems.ItemsSource = listOfItems;

                    }
                    break;
                case 1:
                    if (pnlItems.IsVisible)
                    {

                        List<FileInformation> listOfItems = new List<FileInformation>();
                        for (int i = 0; i < pnlItems.Items.Count; i++)
                            listOfItems.Add((FileInformation)pnlItems.Items[i]);
                        listOfItems = listOfItems.OrderBy(x => x.Name).ToList();
                        pnlItems.ItemsSource = listOfItems;

                    }
                    break;
                case 2:
                    if (pnlItems.IsVisible)
                    {

                        List<FileInformation> listOfItems = new List<FileInformation>();
                        for (int i = 0; i < pnlItems.Items.Count; i++)
                            listOfItems.Add((FileInformation)pnlItems.Items[i]);
                        listOfItems = listOfItems.OrderBy(x => x.Name).ToList();
                        listOfItems.Reverse();
                        pnlItems.ItemsSource = listOfItems;

                    }

                    break;
            }
            pnlItems.Items.Refresh();
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        void addNotification(Activity log)
        {
            Grid x = new Grid();
            x.Height = 80;
            x.Width = 300;
            x.HorizontalAlignment = HorizontalAlignment.Left;

            //image
            PackIcon image = new PackIcon();
            image.Height = 20;
            image.Width = 20;
            image.Margin = new Thickness(-100, 0, 0, 0);
            image.Foreground = new SolidColorBrush(Colors.Wheat);
            image.Kind = PackIconKind.Person;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            //text1
            TextBlock text = new TextBlock();
            text.Text = log.userName;
            text.Margin = new Thickness(30, 0, 0, 0);
            text.Foreground = new SolidColorBrush(Colors.White);
            text.HorizontalAlignment = HorizontalAlignment.Center;
            //opacityMask
            RadialGradientBrush opacityMask = new RadialGradientBrush();
            opacityMask.GradientStops.Add(new GradientStop(Color.FromArgb(220, 220, 220, 0), 0.55));
            opacityMask.GradientStops.Add(new GradientStop(Color.FromArgb(220, 0, 0, 0), 1.0));
            //
            text.OpacityMask = opacityMask;
            //
            //text2
            TextBlock text2 = new TextBlock();
            text2.Text = "\nFile Name : " + log.name + "\nDate : " + log.date + "\nState: " + log.state;
            text2.Margin = new Thickness(18, 0, 0, 0);
            text2.Foreground = new SolidColorBrush(Colors.White);
            text2.OpacityMask = opacityMask;
            text2.HorizontalAlignment = HorizontalAlignment.Center;
            //
            //addToForm
            x.RowDefinitions.Add(new RowDefinition());
            x.Children.Add(text);
            x.Children.Add(text2);
            x.Children.Add(image);
            //

            //borders of the grid
            Border a = new Border();
            a.Width = 450;
            a.BorderThickness = new Thickness(1);
            a.Background = new SolidColorBrush(Color.FromArgb(255, 75, 81, 89));
            a.BorderBrush = new SolidColorBrush(Colors.Black);
            a.CornerRadius = new CornerRadius(0, 60, 0, 40);
            a.Padding = new Thickness(1);
            a.Margin = new Thickness(2);
            a.HorizontalAlignment = HorizontalAlignment.Center;
            a.Child = x;
            //
            Grid y = new Grid();
            y.Height = 80;
            y.Width = 900;
            y.HorizontalAlignment = HorizontalAlignment.Center;
            y.RowDefinitions.Add(new RowDefinition());
            y.Children.Add(a);
            //
            //addrow
            ListViewMenu.Items.Add(y);
        }

        public void loadNotification(string name, string state)
        {
            ActivityLogContent activityLog = new ActivityLogContent();
            activityLog.AddActivity(new Activity(name, state));
            ListViewMenu.Items.Clear();
            ActivityLogContent load = new ActivityLogContent();
            List<Activity> activities = load.RetriveData();
            for (int i = activities.Count - 1; i > -1; i--)
                addNotification(activities[i]);
        }


        private static void DirectoryMove(string sourceDirName, string destDirName, bool moveSubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new System.IO.DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                MessageBox.Show("123");
                Directory.Move(sourceDirName, destDirName);
            }


        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourceDirName, "*", System.IO.SearchOption.AllDirectories))
            {
                if (!string.IsNullOrEmpty(dirPath))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourceDirName, destDirName));
                }
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourceDirName, "*.*", System.IO.SearchOption.AllDirectories))
            {
                if (!string.IsNullOrEmpty(newPath))
                {
                    File.Copy(newPath, newPath.Replace(sourceDirName, destDirName), true);
                }
            }
        }


        private void MiniMiz(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivityDisplay.Visibility = Visibility.Hidden;
            pnlItems.Visibility = Visibility.Hidden;
            GridPrincipal.Visibility = Visibility.Visible;
            Option.Visibility = Visibility.Hidden;
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Home());
            pnlItems.Items.Refresh();
        }

        private void GetData()
        {
            if (listData.Count != 0)
                listData.Clear();
            for (int i = 0; i < pnlItems.Items.Count; i++)
                listData.Add((FileInformation)pnlItems.Items[i]);

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (pnlItems != null)
            {
                String search = SearchTxt.Text.Trim().ToLower();
                if (String.IsNullOrEmpty(search))
                    pnlItems.ItemsSource = listData;
                else
                {
                    var FileFiltered = from fileInfo in listData
                                       let ename = fileInfo.Name.Trim().ToLower()
                                       where
                                       ename.Contains(search)
                                       select fileInfo;
                    pnlItems.ItemsSource = FileFiltered;
                }
            }

        }

        private void paste(object sender, RoutedEventArgs e)
        {
            if (FileItem.type_trans.Equals("cut") || FileItem.type_trans.Equals("copy"))
            {
                try
                {
                    if (FileItem.type.Equals("file"))
                    {
                        if (FileItem.type_trans.Equals("copy"))
                            File.Copy(FileItem.sourcepath, currentpath + "\\" + FileItem.fileName, true);

                        else if (FileItem.type_trans.Equals("cut"))
                            File.Move(FileItem.sourcepath, currentpath + "\\" + FileItem.fileName);
                    }
                    else if (FileItem.type.Equals("folder"))
                    {
                        if (FileItem.type_trans.Equals("copy"))
                            DirectoryCopy(FileItem.sourcepath, currentpath + "\\" + FileItem.fileName, true);

                        else
                            DirectoryMove(FileItem.sourcepath, currentpath + "\\" + FileItem.fileName, true);
                    }
                    loadNotification(FileItem.fileName, FileItem.type_trans);
                    listData.Add((FileInformation)FileItem.copyCutItem);
                    pnlItems.ItemsSource = listData;
                    sortItems();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("YOY SHOULD SELECT FILE OR FOLDER");
        }

        private void NewFolder_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // YesButton Clicked! Let's hide our InputBox and handle the input text.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Do something with the Input
            String input = InputTextBox.Text;
            if (!Directory.Exists(currentpath + "\\" + input))
            {

                Directory.CreateDirectory(currentpath + "\\" + input);
                FileInformation folder = new FileInformation();
                folder.dateTime = DateTime.Now.ToString();
                folder.kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder;
                folder.FullPath = (currentpath + "\\" + input);
                folder.Extension = "";
                folder.size = "";
                folder.Name = input;
                folder.IsFolder = true;
                listData.Add(folder);
                pnlItems.ItemsSource = listData;
                sortItems();
            }
            else
            {
                MessageBox.Show("File is Exists!!", "Warring");
                MessageBox.Show(currentpath);
            }

            // Clear InputBox.
            InputTextBox.Text = String.Empty;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Clear InputBox.
            InputTextBox.Text = String.Empty;
        }



        private void Searchtxt_gotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTxt.Text == "  Search ... " && SearchTxt.Foreground == Brushes.Gray)
            {
                SearchTxt.Text = "  ";
                SearchTxt.Foreground = Brushes.Black;
            }
        }

        private void Searchtxt_Lostfocus(object sender, RoutedEventArgs e)
        {
            if (SearchTxt.Text.Trim() == "" && SearchTxt.Foreground == Brushes.Black)
            {
                SearchTxt.Text = "  Search ... ";
                SearchTxt.Foreground = Brushes.Gray;
            }
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            windowstyle();
        }

        private void MinMax(object sender, RoutedEventArgs e)
        {
            Thickness marginThickness = Menu.Margin;
            if (WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
                maxOrMin.Kind = PackIconKind.SquareInc;

                if (marginThickness.Left == 0)
                {
                    MenuGrid.Width = 50;
                    DisplayArea.Width = 1330;
                    plntContent.Width = 1373;
                }
                else
                {
                    Menu.Margin = new Thickness(195, 0, 0, 0);
                    MenuGrid.Width = 250;
                    DisplayArea.Width = 1130;
                    plntContent.Width = 1073;
                }

            }
            else
            {
                this.WindowState = WindowState.Normal;
                maxOrMin.Kind = PackIconKind.SquareOutline;
                if (marginThickness.Left == 0)
                {
                    Menu.Margin = new Thickness(0, 0, 0, 0);
                    MenuGrid.Width = 50;
                    DisplayArea.Width = 1060;
                    plntContent.Width = 1003;
                }
                else
                {
                    Menu.Margin = new Thickness(145, 0, 0, 0);
                    MenuGrid.Width = 200;
                    DisplayArea.Width = 910;
                    plntContent.Width = 853;
                }


            }

        }
        private void windowstyle()
        {
            Thickness marginThickness = Menu.Margin;
            if (marginThickness.Left == 0)
            {
                SearchTxt.Visibility = Visibility.Visible;
                LocationLabel.Visibility = Visibility.Visible;
                DriverLabel.Visibility = Visibility.Visible;

                if (WindowState == WindowState.Maximized)
                {
                    Menu.Margin = new Thickness(195, 0, 0, 0);
                    MenuGrid.Width = 250;
                    DisplayArea.Width = 1130;
                    plntContent.Width = 1073;
                }
                else
                {
                    Menu.Margin = new Thickness(145, 0, 0, 0);
                    MenuGrid.Width = 200;
                    DisplayArea.Width = 910;
                    plntContent.Width = 853;
                }
            }
            else
            {
                Menu.Margin = new Thickness(0, 0, 0, 0);
                MenuGrid.Width = 50;
                SearchTxt.Visibility = Visibility.Hidden;
                LocationLabel.Visibility = Visibility.Hidden;
                DriverLabel.Visibility = Visibility.Hidden;
                if (WindowState == WindowState.Maximized)
                {
                    DisplayArea.Width = 1330;
                    plntContent.Width = 1273;
                }
                else
                {
                    DisplayArea.Width = 1060;
                    plntContent.Width = 1003;
                }
            }
        }

        private void back_btn_Clicked(object sender, RoutedEventArgs e)
        {

            if (backHistory.Count > 1)
            {
                backHistory.Pop();
                if (!backHistory.Peek().isDrive)
                    pnlItems.ItemsSource = DataManeger.GetItems(backHistory.Peek().path);
                else
                {
                    pnlItems.ItemsSource = DataManeger.GetDrives();
                }
                if (backHistory.Count == 1)
                    back_btn.Foreground = new SolidColorBrush(Colors.Gray);
            }
            GetData();
        }
    }
}
