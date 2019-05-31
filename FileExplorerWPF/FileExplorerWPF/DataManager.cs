using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace FileExplorerWPF
{
    class DataManeger
    {
        // convert the size to human readable
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }


        // checks if the corresponding file/folder is available (openable).
        public static bool IsAvailable(string file, bool isFolder)
        {
            if (!isFolder)
            {
                if ((File.GetAttributes(file) & FileAttributes.Hidden) != FileAttributes.Hidden)
                    return true;
                else
                    return false;
            }
            else
            {
                try
                {
                    object[] files = Directory.GetFiles(file);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        // Loads files and folders (items) from a folder.
        public static List<FileInformation> GetItems(string path)
        {
            List<FileInformation> items = new List<FileInformation>();
            string[] files = Directory.GetFiles(path);
            string[] folders = Directory.GetDirectories(path);
            List<string> allFiles = new List<string>();
            allFiles.AddRange(files);
            // Add folder items into the collection
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.RelativeOrAbsolute)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }
            //Add file items into the colection
            return retrieveData(allFiles, items);
        }



        // Gets the drives :)
        public static List<FileInformation> GetDrives()
        {
            List<FileInformation> driveList = new List<FileInformation>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {

                    driveList.Add(new FileInformation()
                    {

                        Name = "(" + drive.RootDirectory.FullName + ") " + drive.VolumeLabel,
                        FullPath = drive.RootDirectory.FullName,
                        Extension = "",
                        // ImagePath = new BitmapImage(new Uri("Images/drive.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Disc,
                        IsFolder = true
                    });
                }
            }
            return driveList;
        }



        // Loads the Desktop
        public static List<FileInformation> Desktop()
        {
            List<FileInformation> items = new List<FileInformation>();

            FileInformation myComputer = new FileInformation()
            {
                Name = "My Computer",
                Extension = "",
                FullPath = "",
                IsComputer = true,
                IsFolder = false,
                //ImagePath = new BitmapImage(new Uri("Images/laptop_black.png", UriKind.Relative))
                kind_file = MaterialDesignThemes.Wpf.PackIconKind.ComputerClassic
            };
            items.Add(myComputer);
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            string[] adFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            string[] folders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }
            return retrieveData(allFiles, items);
        }



        // Loads the Documents
        public static List<FileInformation> Documents()
        {
            List<FileInformation> items = new List<FileInformation>();
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
            string[] adFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            string[] folders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }
            return retrieveData(allFiles, items);
        }


        // Loads the Music
        public static List<FileInformation> Music()
        {
            List<FileInformation> items = new List<FileInformation>();
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
            string[] adFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            string[] folders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }
            return retrieveData(allFiles, items);
        }


        // Loads the pictures
        public static List<FileInformation> Pictures()
        {
            List<FileInformation> items = new List<FileInformation>();
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
            string[] adFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            string[] folders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }
            return retrieveData(allFiles, items);
        }


        // Loads the Downloads
        public static List<FileInformation> Downloads()
        {
            List<FileInformation> items = new List<FileInformation>();
            //sstring path = Environment.SpecialFolder.UserProfile + @"\Downloads";
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string[] files = Directory.GetFiles(downloadsPath);
            //string[] adFiles = Directory.GetFiles(downloadsPath);
            string[] folders = Directory.GetDirectories(downloadsPath);
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            //allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }


            return retrieveData(allFiles, items);
        }


        // Loads the Videos
        public static List<FileInformation> Videos()
        {
            List<FileInformation> items = new List<FileInformation>();
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
            string[] adFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            string[] folders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);

                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        //ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        kind_file = MaterialDesignThemes.Wpf.PackIconKind.Folder,
                        dateTime = info.LastAccessTime.ToString("dd MMMM yyyy hh:mm:ss tt"),
                        size = FormatBytes(info.EnumerateFiles().Sum(file => file.Length)),
                        IsFolder = true
                    });
                }
            }


            return retrieveData(allFiles, items);
        }
        private static List<FileInformation> retrieveData(List<string> files, List<FileInformation> items)
        {
            foreach (string file in files)
            {
                if (IsAvailable(file, false))
                {

                    //////////////////////////////////////////


                    if (Regex.IsMatch(file.ToLower(), @".jpg|.png|.gif$"))
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.Image,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    else if (Regex.IsMatch(file.ToLower(), @".mp3$"))
                    {
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.Music,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    }
                    else if (Regex.IsMatch(file.ToLower(), @".rar$"))
                    {
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.Archive,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    }
                    else if (Regex.IsMatch(file.ToLower(), @".zip$"))
                    {
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.Style,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    }
                    else if (Regex.IsMatch(file.ToLower(), @".exe$"))
                    {
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.Layers,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    }
                    else if (Regex.IsMatch(file.ToLower(), @".mp4|.avi$"))
                    {
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.Video,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    }

                    else if (Regex.IsMatch(file.ToLower(), @".txt|.ppt$"))
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.FileDocumentOutline,
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });
                    else
                        items.Add(new FileInformation()
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            FullPath = file,
                            Extension = Path.GetExtension(file),
                            //ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                            kind_file = MaterialDesignThemes.Wpf.PackIconKind.FiberManualRecord,
                            //SignalCellularNoSim
                            dateTime = Directory.GetLastAccessTime(file).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            size = FormatBytes(new System.IO.FileInfo(file).Length),
                            IsFolder = false
                        });

                    ////////////////////////////////////////
                }
            }

            return items;
        }

    }

}
