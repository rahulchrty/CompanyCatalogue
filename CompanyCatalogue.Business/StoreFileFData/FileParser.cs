using CompanyCatalogue.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CompanyCatalogue.Business
{
    public class FileParser : IFileParser
    {
        private ISpreadsheetCellValue _spreadsheetCellValue;
        public FileParser(ISpreadsheetCellValue spreadsheetCellValue)
        {
            _spreadsheetCellValue = spreadsheetCellValue;
        }
        public DataTable Parse(string filePath)
        {
            DataTable dtCompanyCatalogue = new DataTable();
            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();
                foreach (Cell cell in rows.ElementAt(0))
                {
                    dtCompanyCatalogue.Columns.Add(_spreadsheetCellValue.GetCellValue(spreadSheetDocument, cell));
                }
                foreach (Row row in rows.Skip(1))
                {
                    DataRow tempRow = dtCompanyCatalogue.NewRow();

                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        tempRow[i] = _spreadsheetCellValue.GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                    }
                    dtCompanyCatalogue.Rows.Add(tempRow);
                }
            }
            return dtCompanyCatalogue;
        }
    }
}
