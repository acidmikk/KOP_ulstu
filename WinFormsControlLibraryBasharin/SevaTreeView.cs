using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsControlLibraryBasharin
{
    public partial class SevaTreeView : UserControl
    {
        public SevaTreeView()
        {
            InitializeComponent();
            treeView1.AfterSelect += (sender, e) => _event?.Invoke(sender, e);
        }
        private event EventHandler _event;

        public event EventHandler SelectedNodeChanged
        {
            add
            {
                _event += value;
            }
            remove
            {
                _event -= value;
            }
        }
        public int SelectedIndex
        {
            get
            {
                return treeView1.SelectedNode != null ? treeView1.SelectedNode.Index : -1;
            }
            set
            {
                if (value > -1 && value < treeView1.Nodes.Count)
                {
                    treeView1.SelectedNode = treeView1.Nodes[value];
                    treeView1.Focus();
                    return;
                }
                throw new IndexOutOfRangeException();
            }
        }
        private List<string> config;
        public void SetConfig(List<string> config)
        {
            if (config == null)
                throw new NullReferenceException("Add not null config");
            this.config = config;
        }

        public T GetSelectedNode<T>() where T : class, new()
        {
            if (treeView1.SelectedNode == null)
                return null;

            var curNode = treeView1.SelectedNode;
            if (curNode.Nodes.Count > 0)
                throw new Exception("Choose last node of tree (leaf)");

            var Vals = new List<string>();
            while (curNode != null)
            {
                Vals.Add(curNode.Text);
                curNode = curNode.Parent;
            }

            Vals.Reverse();
            var item = new T();
            var count = item.GetType().GetProperties().Length;
            for (int i = 0; i < config.Count; ++i)
            {
                if (i < count)
                {
                    var pinfo = item.GetType().GetProperty(config[i]);
                    if (pinfo != null)
                        pinfo.SetValue(item, Convert.ChangeType(Vals[i], pinfo.PropertyType));
                }
                else
                {
                    var finfo = item.GetType().GetField(config[i]);
                    if (finfo != null)
                    {
                        finfo.SetValue(item, Convert.ChangeType(Vals[i], finfo.FieldType));
                    }
                }
            }
            return item;
        }

        public void Clear()
        {
            treeView1.Nodes.Clear();
        }
    }
}
