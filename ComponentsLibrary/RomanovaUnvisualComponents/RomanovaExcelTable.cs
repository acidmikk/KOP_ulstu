using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace ComponentsLibrary.RomanovaUnvisualComponents
{
    public partial class RomanovaExcelTable : Component
    {
        char[] colIndex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        //Указывается порядок столбцов в таблице
        public List<string> columnsName = new List<string>();
        public RomanovaExcelTable()
        {
            InitializeComponent();
        }

        public RomanovaExcelTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CreateTableExcel<T>(string path, string title, List<MergeCells> mergeCells, int[] colsWidth, string[] headings, List<T> data) where T : class, new()
        {
            if (path != string.Empty && title != string.Empty && mergeCells != null && colsWidth != null && headings != null && data != null)
            {
                if (columnsName == null)
                {
                    throw new Exception("Не заполнены названия колонок");
                }

                var excelApp = new Excel.Application();

                excelApp.SheetsInNewWorkbook = 1;

                excelApp.Workbooks.Add();

                Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.Worksheets.get_Item(1);

                workSheet.Cells[1, "A"] = title;

                //Добавление всех заголовков
                if (colsWidth.Length == headings.Length)
                {
                    for (int j = 1; j <= headings.Length; j++)
                    {
                        if (!headings[j - 1].Equals(string.Empty))
                        {
                            workSheet.Cells[2, j] = headings[j - 1];
                            workSheet.Columns[j].ColumnWidth = colsWidth[j - 1];
                            workSheet.Cells[2, j].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            workSheet.Cells[2, j].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            workSheet.Cells[2, j].Font.Bold = true;
                        }
                        else
                        {
                            throw new Exception("Не все заголовки имеют данные");
                        }
                    }
                }
                else
                {
                    throw new Exception("Кол-во заголовков не соответствует кол-ву размеров столбцов");
                }

                //Индексы столбцов для объединения
                List<int> mergeInds = new List<int>();

                //Объединение ячеек по столбцам
                foreach (var merge in mergeCells)
                {
                    mergeInds.AddRange(merge.CellIndexes);

                    //Сдвигаем объединяемые ячейки на строку вниз
                    Excel.Range rangeToCopy = workSheet.get_Range
                        ($"{colIndex[merge.CellIndexes[0]]}2", $"{colIndex[merge.CellIndexes[merge.CellIndexes.Length - 1]]}2").Cells;
                    Excel.Range rangeToInsert = workSheet.get_Range
                        ($"{colIndex[merge.CellIndexes[0]]}3", $"{colIndex[merge.CellIndexes[merge.CellIndexes.Length - 1]]}3").Cells;
                    rangeToInsert.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, rangeToCopy.Cut());

                    //Объединяем сверху ячейки и вводим шапку
                    Excel.Range rangeMerge = workSheet.get_Range
                       ($"{colIndex[merge.CellIndexes[0]]}2", $"{colIndex[merge.CellIndexes[merge.CellIndexes.Length - 1]]}2").Cells;
                    rangeMerge.Merge();
                    workSheet.Cells[2, merge.CellIndexes[0] + 1] = merge.Heading;
                    workSheet.Cells[2, merge.CellIndexes[0] + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    workSheet.Cells[2, merge.CellIndexes[0] + 1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    workSheet.Cells[2, merge.CellIndexes[0] + 1].Font.Bold = true;
                }

                //Объединение ячеек по строкам, которые не объединяются по столбцам
                for (int j = 1; j <= headings.Length; j++)
                {
                    if (!mergeInds.Contains(j - 1))
                    {
                        // Выделяем диапазон ячеек
                        Excel.Range range = workSheet.get_Range($"{colIndex[j - 1]}2", $"{colIndex[j - 1]}3").Cells;
                        // Производим объединение
                        range.Merge();
                    }
                }

                //Заполение данными
                int i = 4;
                foreach (var item in data)
                {
                    var fields = item.GetType().GetProperties();
                    if (fields.Count() == columnsName.Count())
                    {
                        for (int j = 0; j < fields.Count(); j++)
                        {
                            int colIndex = 0;
                            var field = item.GetType().GetProperties()[j];
                            var value = field.GetValue(item);
                            if (value != null)
                            {
                                //Ищем соответствующую колонку для поля класса
                                foreach (var column in columnsName)
                                {
                                    if (column == field.Name)
                                    {
                                        colIndex = columnsName.IndexOf(column) + 1;
                                        break;
                                    }
                                }
                                if (colIndex != 0)
                                {
                                    workSheet.Cells[i, colIndex] = value;
                                }
                                else
                                {
                                    throw new Exception($"Соответствующая колонка в таблице для поля {field.Name} = {value} не найдена");
                                }
                            }
                            else
                            {
                                throw new Exception("Поле имеет пустое значение");
                            }
                        }
                        i++;
                    }
                    else
                    {
                        throw new Exception("Кол-во полей объекта не соответствует кол-ву столбцов в таблице");
                    }
                }

                //Добавляем границы у таблицы
                for (int str = 2; str <= (data.Count() + 3); str++)
                {
                    for (int j = 1; j < headings.Length + 1; j++)
                    {
                        workSheet.Cells[str, j].BorderAround(true);
                    }
                }

                excelApp.Application.ActiveWorkbook.SaveAs(path);
                excelApp.Workbooks.Close();
                excelApp.Quit();
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
