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
            foreach (var ns in namespaces)
            {
                collection.Add(new TreeView(ns.Value.ToString(), TypesToObservableCollection(ns.Value.Types)));
            }
            return collection;
        }
        private ObservableCollection<TreeView> TypesToObservableCollection(List<ExportedTypeInfo> types)
        {
            var collection = new ObservableCollection<TreeView>();
            foreach (var type in types)
            {
                collection.Add(new TreeView(type.ToString(), TypeMembersToObservableCollection(type)));
            }
            return collection;
        }



        private ObservableCollection<TreeView> TypeMembersToObservableCollection(ExportedTypeInfo type)
        {
            var collection = new ObservableCollection<TreeView>();
/*            foreach (var field in type.Fields)
            {
                collection.Add(new TreeNode(field.ToString()));
            }

            foreach (var property in type.Properties)
            {
                collection.Add(new TreeNode(property.ToString()));
            }*/

            foreach (var method in type.Methods)
            {
                collection.Add(new TreeView(method.ToString()));
            }

            return collection;
        }


    }
}
