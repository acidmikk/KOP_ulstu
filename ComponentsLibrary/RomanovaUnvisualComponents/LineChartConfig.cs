namespace ComponentsLibrary.RomanovaUnvisualComponents
{
    public class LineChartConfig
    {
        public string FilePath { get; set; }
        public string Header { get; set; }
        public string ChartTitle { get; set; }
        public Dictionary<string, List<int>> Values { get; set; }
        public LegendPosition LegendPosition { get; set; }
    }
}
