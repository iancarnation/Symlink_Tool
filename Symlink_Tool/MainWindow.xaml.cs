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
using System.Media;

namespace Symlink_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string newLinkPath, source, linkName;

        SoundPlayer player = new SoundPlayer(Properties.Resources.LOZ_Secret);
       

        private void SourceFolderDropped(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                SourceLocation.Items.Clear();

                string[] droppedFilePaths =
                    e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string droppedFilePath in droppedFilePaths)
                {
                    ListBoxItem fileItem = new ListBoxItem();

                    source = droppedFilePath;
                    linkName = System.IO.Path.GetFileNameWithoutExtension(droppedFilePath);

                    fileItem.Content = System.IO.Path.GetFileNameWithoutExtension(droppedFilePath);
                    fileItem.ToolTip = droppedFilePath;

                    SourceLocation.Items.Add(fileItem);
                }
            }
        }

        private void LinkFolderDropped(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                LinkLocation.Items.Clear();

                string[] droppedFilePaths =
                    e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string droppedFilePath in droppedFilePaths)
                {
                    ListBoxItem fileItem = new ListBoxItem();

                    newLinkPath = droppedFilePath;

                    fileItem.Content = System.IO.Path.GetFileNameWithoutExtension(droppedFilePath);
                    fileItem.ToolTip = droppedFilePath;

                    LinkLocation.Items.Add(fileItem);
                }
            }
        }

        private void RunJunction(object sender, RoutedEventArgs e)
        {
            // junction command: junction <path to new link> "<path to source>"

            string arg1 = newLinkPath + "\\" + linkName;
            string arg2 = "\"" + source + "\"";

            string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;

            string filePath = currentDir + "junction.exe";
            string arguments = "\"" + arg1 + "\"" + " " + "\"" + arg2 + "\""; // enclosing args in quotes to handle spaces in path

            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath, arguments);
                player.Play();
            }

        }

    }
}
