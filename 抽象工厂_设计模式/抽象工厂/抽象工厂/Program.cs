using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("请选择CPU、主板配置组合:");
            Console.WriteLine("A:IntelCPU+华硕主板\tB:AMDCPU+技嘉主板\tC:惠普CPU+Intel主板");
            Console.WriteLine("---------------------------------------------------------------------");
            while (true)
            {
                //这是处理非静态对象、方法的方案之一，实例化类去调用该内部函数
                Program program = new Program();
                program.selectType(Console.ReadLine());
            }
        }
        public void selectType(string type)
        {
            if (type == "A")
            {
                //这个new ImplementFactory1();是用这个类的对象的 构造函数 来实例化抽象工厂接口对象
                abstractfactory af = new ImplementFactory1();
                //此处如果写成af.cpu()就出问题。因为该af接口对象是由构造函数实例化，
                //那么它只会去调用实现该接口的类IntelCPU的构造函数，然后运行完构造函数则退出。
                //所以必须是af.cpu().PrintCPUPins();
                af.cpu().PrintCPUPins();
                af.mainBorder().PrintMBHoles();
            }
            else if (type == "B")
            {
                abstractfactory af = new ImplementFactory2();
                af.cpu().PrintCPUPins();
                af.mainBorder().PrintMBHoles();
            }
            else if (type == "C")
            {
                abstractfactory af = new ImplementFactory3();
                af.cpu().PrintCPUPins();
                af.mainBorder().PrintMBHoles();
            }
            else
            {
                Console.WriteLine("查找类型不存在");
            }
        }
    }

    /// <summary>
    /// 声明一系列产品的操作接口
    /// </summary>
    public interface abstractfactory
    {
        /// <summary>
        /// 创建CPU的方法对象
        /// </summary>
        /// <returns></returns>
        CPUAPI cpu();
        /// <summary>
        /// 创建主板的方法对象
        /// </summary>
        /// <returns></returns>
        MainBorderAPI mainBorder();
    }

    #region==系列产品接口==
    /// <summary>
    /// 声明一个产品接口：CPU
    /// </summary>
    public interface CPUAPI
    {
        //CPU的针脚数
        int CPUPins { get; set; }
        //输出CPU的针脚数
        void PrintCPUPins();
    }
    /// <summary>
    /// 声明一个产品接口：主板
    /// </summary>
    public interface MainBorderAPI
    {
        //主板的针脚插槽数
        int MBHoles { get; set; }
        //输出主板的插槽数
        void PrintMBHoles();
    }
    #endregion

    #region==CPU产品类==
    /// <summary>
    /// 实现CPU接口的具体产品类：Intel
    /// </summary>
    public class IntelCPU : CPUAPI
    {
        //因特尔的CPU针脚数1000
        private int cpuPins = 1000;
        //给接口的属性赋值
        public int CPUPins
        {
            get { return cpuPins; }
            set { cpuPins = value; }
        }
        public IntelCPU()
        {

        }
        public void PrintCPUPins()
        {
            Console.WriteLine("IntelCPU Pins:" + this.CPUPins);
        }
    }
    /// <summary>
    /// 实现CPU接口的具体产品类：AMD
    /// </summary>
    public class AMDCPU : CPUAPI
    {
        //AMD的CPU针脚数2000
        private int cpuPins = 2000;
        //给接口的属性赋值
        public int CPUPins
        {
            get { return cpuPins; }
            set { cpuPins = value; }
        }
        public void PrintCPUPins()
        {
            Console.WriteLine("AMDCPU Pins:" + this.CPUPins);
        }
    }
    /// <summary>
    /// 实现CPU接口的具体产品类：惠普
    /// </summary>
    public class HPCPU : CPUAPI
    {
        //惠普的CPU针脚数3000
        private int cpuPins = 3000;
        //给接口的属性赋值
        public int CPUPins
        {
            get { return cpuPins; }
            set { cpuPins = value; }
        }
        public void PrintCPUPins()
        {
            Console.WriteLine("HPCPU Pins:" + this.CPUPins);
        }
    }
    #endregion

    #region==主板产品类==
    /// <summary>
    /// 实现主板接口的具体产品类：华硕ATX
    /// </summary>
    public class HS_ATXMB : MainBorderAPI
    {
        //华硕的插槽数1000
        private int mbHoles = 1000;
        //给接口的属性赋值
        public int MBHoles
        {
            get { return mbHoles; }
            set { mbHoles = value; }
        }
        public void PrintMBHoles()
        {
            Console.WriteLine("MBHoles:" + this.MBHoles);
        }
    }
    /// <summary>
    /// 实现主板接口的具体产品类：技嘉ATX
    /// </summary>
    public class JJ_ATXMB : MainBorderAPI
    {
        //技嘉的插槽数2000
        private int mbHoles = 2000;
        //给接口的属性赋值
        public int MBHoles
        {
            get { return mbHoles; }
            set { mbHoles = value; }
        }
        public void PrintMBHoles()
        {
            Console.WriteLine("MBHoles:" + this.MBHoles);
        }
    }
    /// <summary>
    /// 实现主板接口的具体产品类：因特尔ATX
    /// </summary>
    public class Intel_ATXMB : MainBorderAPI
    {
        //因特尔的插槽数3000
        private int mbHoles = 3000;
        //给接口的属性赋值
        public int MBHoles
        {
            get { return mbHoles; }
            set { mbHoles = value; }
        }
        public void PrintMBHoles()
        {
            Console.WriteLine("MBHoles:" + this.MBHoles);
        }
    }
    #endregion

    #region==实现抽象工厂==
    /// <summary>
    /// 抽象工厂实现1：IntelCPU+华硕MB
    /// </summary>
    public class ImplementFactory1:abstractfactory
    {
        public CPUAPI cpu()
        {
            return new IntelCPU();
        }
        public MainBorderAPI mainBorder()
        {
            return new HS_ATXMB();
        }
    }
    /// <summary>
    /// 抽象工厂实现2：AMDCPU+技嘉MB
    /// </summary>
    public class ImplementFactory2 : abstractfactory
    {
        public CPUAPI cpu()
        {
            return new AMDCPU();
        }
        public MainBorderAPI mainBorder()
        {
            return new JJ_ATXMB();
        }
    }
    /// <summary>
    /// 抽象工厂实现3：惠普CPU+IntelMB
    /// </summary>
    public class ImplementFactory3 : abstractfactory
    {
        public CPUAPI cpu()
        {
            return new HPCPU();
        }
        public MainBorderAPI mainBorder()
        {
            return new Intel_ATXMB();
        }
    }
    #endregion
}
