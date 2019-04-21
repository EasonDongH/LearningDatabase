using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace StudentManager.ExcelPrint
{
    /// <summary>
    /// 从DataGridView中导出数据
    /// </summary>
    class DataExport
    {
        /// <summary>
        /// 将当前DataGridView中的数据导出到Excel中
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public bool Export(DataGridView dgv)
        {
            //定义Excel应用对象
            Microsoft.Office.Interop.Excel.Application excelApp =
                new Microsoft.Office.Interop.Excel.Application();
            //定义Excel工作表对象
            Microsoft.Office.Interop.Excel.Worksheet workSheet =
               excelApp.Workbooks.Add().Worksheets[1];
            //在Excel中建立一个工作簿
           // workSheet = excelApp.Workbooks.Add().Worksheets[1];

            //设置标题的样式（从第二行,第2列开始）
            workSheet.Cells[2,2] = "学员成绩表"; //设置标题的内容
            workSheet.Cells[2, 2].RowHeight = 25;//设置表的行高            
            Microsoft.Office.Interop.Excel.Range range = workSheet.get_Range("B2", "H2");
            range.Merge(0);//合并标题的单元格   
            range.Borders.Value = 1;//设置标题的边框
            range.HorizontalAlignment =
                Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//设置单元格文本居中对齐
            range.Font.Size = 15; //设置字体大小

            //获得总列数和总行数
            int columnCount = dgv.ColumnCount;
            int rowCount = dgv.RowCount;
            //显示列标题
            for (int i = 0; i < columnCount; i++)
            {
                //从第三行开始设置
                workSheet.Cells[3, i + 2] = dgv.Columns[i].HeaderText;
                workSheet.Cells[3, i + 2].Borders.Value = 1;//设置单元格的边框为1个像素
                workSheet.Cells[3, i + 2].RowHeight = 23;
                //workSheet.Cells[3, i + 2].ColumnWidth = 10;
            }
            //从第4行、第2列  开始显示数据
            for (int i = 0; i < rowCount - 1; i++)
            {
                for (int n = 0; n < columnCount; n++)
                {
                    workSheet.Cells[i + 4, n + 2] = dgv.Rows[i + 1].Cells[n].Value;
                    workSheet.Cells[i + 4, n + 2].Borders.Value = 1;
                    workSheet.Cells[i + 4, n + 2].RowHeight = 23;
                    workSheet.Cells[i + 4, n + 2].HorizontalAlignment =
                        Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
            }
            //使列宽与数据一致（也可以单独设置每一列的宽度）
            workSheet.Columns.AutoFit();
            //【6】打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);
            //【7】释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);//释放
            excelApp = null;

            return true;
        }
    }
}
