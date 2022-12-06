using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowHandler

{
    public class TreeView : INotifyPropertyChanged
    {
        // variables
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<TreeView> _nodes;
        public ObservableCollection<TreeView> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
                OnPropertyChanged();
            }
        }
        // methods
        public TreeView() { }
        public TreeView(string name, ObservableCollection<TreeView> nodes = null)
        {
            Name = name;
            Nodes = nodes;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
