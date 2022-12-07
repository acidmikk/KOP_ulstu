namespace ComponentsLibrary.BasharinVisualComponents
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
                if (treeView1.SelectedNode != null)
                {
                    return treeView1.SelectedNode.Index;
                } else
                {
                    return -1;
                }
            }
            set
            {
                if (treeView1.Nodes.Count > 0)
                {
                    if (value < treeView1.Nodes.Count && value > -1)
                    {
                        treeView1.SelectedNode = treeView1.Nodes[value];
                        treeView1.Focus();
                        return;
                    }                
                }
            }
        }
        private List<string> config;
        public void SetConfig(List<string> config)
        {
            if (config == null)
                throw new NullReferenceException("Add not null config");
            this.config = config;
        }
        public void CreateTree<T>(T obj) where T : class, new()
        {
            if (config == null)
                throw new NullReferenceException("Add not null config");
            if (obj == null)
                throw new NullReferenceException("Add not null list of objects");

            var elementType = obj.GetType();
            
            var currentLevelNodes = treeView1.Nodes;
            int curlvl = 1;
            foreach (var nodeName in config)
            {
                var propertyInfo = elementType.GetProperty(nodeName);
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(obj).ToString();
                    if (!currentLevelNodes.ContainsKey(propertyValue))
                    {
                        if (curlvl == config.Count)
                        {
                            currentLevelNodes.Add(propertyValue);
                        }
                        else
                            currentLevelNodes.Add(propertyValue, propertyValue);
                    }
                    if (curlvl != config.Count)
                        currentLevelNodes = currentLevelNodes.Find(propertyValue, false)[0].Nodes;
                }
                else
                {
                    var fieldInfo = elementType.GetField(nodeName);
                    if (fieldInfo != null)
                    {
                        var fieldValue = fieldInfo.GetValue(obj).ToString();
                        if (!currentLevelNodes.ContainsKey(fieldValue))
                        {
                            if (curlvl == config.Count)
                            {
                                currentLevelNodes.Add(fieldValue);
                            }
                            else
                                currentLevelNodes.Add(fieldValue, fieldValue);
                        }
                        if (curlvl != config.Count)
                            currentLevelNodes = currentLevelNodes.Find(fieldValue, false)[0].Nodes;
                    }
                }
                curlvl++;
            }
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
