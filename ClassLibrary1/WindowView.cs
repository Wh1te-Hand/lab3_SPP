using DisplayInfo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowHandler 
{
    public class WindowView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TreeView> _nodes;
        private AssemblyBrowser assembly;
        public ObservableCollection<TreeView> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void LoadAssembly(object o, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter += "Dll files(*.dll)|*.dll";
            if (fileDialog.ShowDialog() == false)
                return;
           
            assembly = AssemblyLoader.Load(fileDialog.FileName);
            Nodes = new ObservableCollection<TreeView>
            {
                new TreeView(assembly.ToString(), NamespacesToObservableCollection(assembly.Namespaces))
            };
        }

        private ObservableCollection<TreeView> NamespacesToObservableCollection(Dictionary<string, ExportedNsInfo> namespaces)
        {
            var collection = new ObservableCollection<TreeView>();
  /*          foreach (var ns in namespaces)
            {
                collection.Add(new TreeView(ns.Value.ToString(), TypesToObservableCollection(ns.Value.Types)));
            }*/
            return collection;
        }

    }
}
