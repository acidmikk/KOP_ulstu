namespace ComponentsLibrary.RomanovaUnvisualComponents
{
    public class MergeCells
    {
        public string Heading;
        public int[] CellIndexes;

        public MergeCells(string heading, int[] cellIndexes)
        {
            Heading = heading;
            CellIndexes = cellIndexes;
        }
    }
}
