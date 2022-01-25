using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Table = TechTalk.SpecFlow.Table;

namespace SeleniumNUnit.Libraries
{
    class ExcelOperations
    {
        public void CreateXlsFile(string path, Table table)
        {
            IWorkbook workbook;
            IRow excelrow;
            ICell cell;

            workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();
            

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                //ICreationHelper creationHelper = workbook.GetCreationHelper();
                string[] colarr = table.Rows[0].Keys.ToArray<string>();
                excelrow = sheet.CreateRow(0);
                for (int i = 0; i < colarr.Length; i++)
                {
                    cell = excelrow.CreateCell(i);
                    cell.SetCellValue(colarr[i]);// (creationHelper.CreateRichTextString(colarr[i]));
                }
                for (int i = 0; i < table.RowCount; i++)
                {
                    excelrow = sheet.CreateRow(i + 1);
                    string[] rowarr = table.Rows[i].Values.ToArray<string>();
                    for (int j = 0; j < rowarr.Length; j++)
                    {
                        cell = excelrow.CreateCell(j);
                        cell.SetCellValue(rowarr[j]);// (creationHelper.CreateRichTextString(rowarr[j]));
                    }
                }

                workbook.Write(stream);
                workbook.Close();
            }
        }

        public void ReadXlsFile(string filepath)
        {
            HSSFWorkbook hSSFWorkbook;
            using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                hSSFWorkbook = new HSSFWorkbook(file);
            }

            ISheet sheet = hSSFWorkbook.GetSheetAt(0);

            for (int i = 0; i < sheet.LastRowNum; i++)
            {
                string rowvalue = string.Empty;
                for (int j = 0; j < sheet.GetRow(i).LastCellNum; j++)
                {
                    
                    if (sheet.GetRow(i) != null)
                    {
                        string celldata = sheet.GetRow(i).GetCell(j).StringCellValue;
                        rowvalue += celldata + " | ";
                    }
                }
                Serilog.Log.Information(rowvalue);            
            }
        }
    }
}
