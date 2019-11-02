using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Models.Ext;
using System.Drawing;
using System.IO;

namespace StudentManager.ExcelPrint
{
    /// <summary>
    /// 基于Excel模板打印学员信息
    /// </summary>
    public class PrintStudent
    {
        public void ExecPrint(StudentExt student)
        {
            //【1】定义一个Excel工作薄对象
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //【2】获取已创建好的工作薄路径
            string execlBookPath = Environment.CurrentDirectory + "\\StudentInfo.xls";
            //【3】将现有工作薄加入已经定义的工作薄集合
            excelApp.Workbooks.Add(execlBookPath);
            //【4】获取第一个工作表
            Microsoft.Office.Interop.Excel.Worksheet sheet = excelApp.Worksheets[1];
            //【5】在当前Excel工作表中写入数据
            if (student.StuImage.Length != 0)//判断是否有图片，如果有则添加到Excel工作表指定的位置中
            {
                //将图片保存到指定的位置
                Image image = (Image)new Common.SerializeObjectToString().DeserializeObject(student.StuImage);
                string imagePath = Environment.CurrentDirectory + "\\Student.jpg";
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
                else
                {
                    //保存图片到系统目录中
                    image.Save(imagePath);
                    //将图片插入到Excel中
                    sheet.Shapes.AddPicture(imagePath, Microsoft.Office.Core.MsoTriState.msoFalse,
                       Microsoft.Office.Core.MsoTriState.msoTrue, 10, 50, 90, 100);
                    //使用完毕后删除保存的图片
                    File.Delete(imagePath);
                }
            }
            //写入其他相关数据
            sheet.Cells[4, 4] = student.StudentId;
            sheet.Cells[4, 6] = student.StudentName;
            sheet.Cells[4, 8] = student.Gender;
            sheet.Cells[6, 4] = student.ClassName;
            sheet.Cells[6, 8] = student.PhoneNumber;
            sheet.Cells[8, 4] = student.StudentAddress;
            //备注信息...

            //【6】打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);

            //【7】释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;
        }
    }
}
