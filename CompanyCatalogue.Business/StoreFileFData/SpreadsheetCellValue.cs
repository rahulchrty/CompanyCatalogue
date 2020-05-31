using CompanyCatalogue.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;

namespace CompanyCatalogue.Business
{
    public class SpreadsheetCellValue : ISpreadsheetCellValue
    {
        string cellValue = string.Empty;
        public string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            cellValue = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                cellValue =  stringTablePart.SharedStringTable.ChildElements[Int32.Parse(cellValue)].InnerText.Trim();
            }
            return cellValue;
        }
    }
}
