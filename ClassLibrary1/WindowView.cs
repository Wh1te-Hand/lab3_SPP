using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowHandler 
{
    public class WindowView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public void LoadAssembly(object o, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter += "Dll files(*.dll)|*.dll";
            if (fileDialog.ShowDialog() == false)
                return;
           // MessageBox.Show(fileDialog.FileName, fileDialog.FileName, MessageBoxButton.OKCancel, MessageBoxImage.Question);


        }

    }
}
