using System.IO;
using NPOI.OpenXml4Net.OPC;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Classes
{
    class Spreadsheet
    {   
        public ISheet Read (string filePath, int sheetIndex = 0)
        {
            using var file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var pkg = OPCPackage.Open(file);
            var wb = new XSSFWorkbook(pkg);
            var firstSheet = wb.GetSheetName(sheetIndex);
            var sheet = wb.GetSheet(firstSheet);
            return sheet;
        }
    }
}