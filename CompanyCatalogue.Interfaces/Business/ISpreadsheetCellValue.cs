using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CompanyCatalogue.Interfaces
{
    public interface ISpreadsheetCellValue
    {
        string GetCellValue(SpreadsheetDocument document, Cell cell);
    }
}
