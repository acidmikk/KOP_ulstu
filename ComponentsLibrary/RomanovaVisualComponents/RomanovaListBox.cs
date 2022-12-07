using System.Reflection;

namespace ComponentsLibrary.RomanovaVisualComponents
{
    public partial class RomanovaListBox : UserControl
    {

        public RomanovaListBox()
        {
            InitializeComponent();
        }
        List<string> names = new List<string>();

        private string layoutString;
        private char openSymbol;
        private char endSymbol;

        public int index
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }

        public void LayoutString(string layoutString, char openSymbol, char endSymbol)
        {
            this.layoutString = layoutString;
            this.openSymbol = openSymbol;
            this.endSymbol = endSymbol;

            names = GetStringNames();
        }

        private List<string> GetStringNames()
        {
            char[] layoutStringChars = layoutString.ToCharArray();
            names = new List<string>();

            for (int i = 0; i < layoutStringChars.Length; i++)
            {
                if (layoutStringChars[i] == openSymbol)
                {
                    string name = null;
                    int j = 0;
                    for (j = i + 1; layoutStringChars[j] != endSymbol; j++)
                    {
                        name += layoutStringChars[j];
                    }
                    i = j;
                    names.Add(name);
                }
            }
            return names;
        }

        private string FillString<T>(T obj)
        {
            List<string> values = new List<string>();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            foreach (var n in names)
            {
                foreach (var p in properties)
                {
                    if (p.Name.Equals(n))
                    {
                        values.Add(p.GetValue(obj).ToString());
                    }
                }
            }

            string str = layoutString;
            for (int i = 0; i < values.Count; i++)
            {
                str = str.Replace(openSymbol + names[i] + endSymbol, values[i]);
            }
            return str;
        }

        public void Fill<T>(T obj)
        {
            listBox.Items.Add(FillString(obj));
            listBox.Refresh();
        }

        public void ClearAll()
        {
            listBox.Items.Clear();
        }

        public T GetSelectedItem<T>() where T : class, new()
        {
            T obj = new T();
            List<string> names = GetStringNames();

            string[] layoutWordsArray = layoutString.Split(' ');
            string[] selectedWordsArray = listBox.SelectedItem.ToString().Split(' ');

            List<string> keyWords = new List<string>();
            int[] prop_index = new int[GetStringNames().Count];
            for (int i = 0; i < layoutWordsArray.Length; i++)
            {
                if (layoutWordsArray[i].Contains(openSymbol) && layoutWordsArray[i].Contains(endSymbol))
                {
                    keyWords.Add(null);
                }
                else keyWords.Add(layoutWordsArray[i]);
            }

            int prop_number = 0;
            for (int i = 0; i < layoutWordsArray.Length; i++)
            { 
                if (keyWords[i] != null)
                {
                    for (int j = 0; j < selectedWordsArray.Length; j++)
                    {
                        if (layoutWordsArray[i] == selectedWordsArray[j])
                        {
                            prop_index[prop_number] = j;
                        }
                    }
                    prop_number++;
                }
                if (prop_number == -1)
                    return null;
            }


            for (int i = 0; i < prop_index.Length; i++)
            {
                PropertyInfo property = typeof(T).GetProperty(names[i]);
                string value = null;
                if ((i + 1) != prop_index.Length)
                {
                    for (int j = prop_index[i] + 1; j < prop_index[i + 1]; j++)
                    {
                        value += selectedWordsArray[j] + " ";
                    }
                }
                else {
                    for (int j = prop_index[i] + 1; j < selectedWordsArray.Length; j++)
                    {
                        value += selectedWordsArray[j] + " ";
                    }
                }
                property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
            }
            return obj;
        }

    }
}
