using System.IO;
using NPOI.OpenXml4Net.OPC;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Classes
{
    class Spreadsheet
    {   

        public Spreadsheet()
        {

        }

        public ISheet Read (string filePath, int sheetIndex = 0)
        {

            XSSFWorkbook wb;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                OPCPackage pkg = OPCPackage.Open(file);
                wb = new XSSFWorkbook(pkg);
                
            }
            
            string firstSheet = wb.GetSheetName(sheetIndex);

            ISheet sheet = wb.GetSheet(firstSheet);

            return sheet;
        }
    }
}