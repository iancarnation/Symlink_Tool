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

                    fileItem.Content = System.IO.Path.GetFileNameWithoutExtension(droppedFilePath);
                    fileItem.ToolTip = droppedFilePath;

                    LinkLocation.Items.Add(fileItem);
                }
            }
        }

        private void RunJunction(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Users\ian.rich\Tools\Sysinternals\junction.exe";
        }

    }
}
