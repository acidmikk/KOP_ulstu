namespace ComponentsLibrary.MyUnvisualComponents.HelperModels
{
    public class ComponentWordTableConfig<T>
    {
        public WordInfo WordInfo { get; set; }
        public List<int> ColumnsWidth { get; set; }
        public List<int> RowsHeight { get; set; }
        public List<string> Headers { get; set; }
        public List<string> PropertiesQueue { get; set; }
        public List<T> ListData { get; set; }
    }
}
