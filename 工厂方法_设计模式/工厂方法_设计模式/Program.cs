using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法_设计模式
{
    //实现一个框架，让客户选择数据的导出方式，并真正执行数据的导出
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t请输入数据导出方式(A/B)：");
            Console.Write("\tA:.txt \t  B:.sql \n");
            string result = Console.ReadLine();
            if (result == "A")
            {
                ExportOperate operate = new TxtExportOperate();
                operate.export(".txt");
            }
            else
            {
                ExportOperate operate = new SqlServerExportOperate();
                operate.export(".sql");
            }
        }
    }
    //导出文件的接口（product）
    public interface ExportFileInterface
    {
        Boolean ExportResult(string data);
    }
    //实现该接口的.txt文件导出
    public class TxtExport : ExportFileInterface
    {
        public Boolean ExportResult(string data)
        {
            Console.WriteLine("data type：" + data + "  ----  ExportResult:success");
            Console.ReadKey();
            return true;
        }
    }
    //实现该接口的.sql数据库文件导出
    public class SqlServerExport : ExportFileInterface
    {
        public Boolean ExportResult(string data)
        {
            Console.WriteLine("data type：" + data + "  ----  ExportResult:success");
            Console.ReadKey();
            return true;
        }
    }
    //声明一个抽象类，导出操作（creator）
    /// <summary>
    /// 抽象类abstract
    /// </summary>
    public abstract class ExportOperate
    {
        //
        public abstract ExportFileInterface factorymethod();
        //
        public Boolean export(string data)
        {
            ExportFileInterface exportFile = factorymethod();
            return exportFile.ExportResult(data);
        }
    }
    //.txt文件导出操作来实现该抽象类
    public class TxtExportOperate : ExportOperate
    {
        public override ExportFileInterface factorymethod()
        {
            //创建导出.txt文本对象，在此不写具体代码

            return new TxtExport();
        }
    }
    //.sql文件导出操作来实现该抽象类
    public class SqlServerExportOperate : ExportOperate
    {
        public override ExportFileInterface factorymethod()
        {
            //创建导出.sql数据库文件对象，在此不写具体代码

            return new SqlServerExport();
        }
    }
}
