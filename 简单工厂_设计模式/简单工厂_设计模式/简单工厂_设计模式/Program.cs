using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂_设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //用简单工厂类去实例化接口Api，而不是去用实现类去实例化接口Api了
            //注意这里的参数，这样导致的缺陷就是会向客户暴露一部分内部的实现细节
            Api_Print api = new SimpleFactory().Api(1);
            api.Print();
            BImplementApi.ExtraPrint();
            Console.ReadLine();
        }
    }
    //声明一个具有输出内容的接口
    public interface Api_Print
    {
        //接口的输出功能
        void Print();
    }
    
    //声明一个实现接口的A类
    public class AImplementApi:Api_Print
    {
        //实现接口功能
        public void Print()
        {
            Console.WriteLine("通过A实现类来实现接口的Print()功能");
        }
        //实现类里额外需要的功能声明
        public void ExtraPrint()
        {
            Console.WriteLine("这是A实现类额外需要的功能，并不影响接口内部");
        }
    }

    //声明一个实现接口的B类
    public class BImplementApi : Api_Print
    {
        //实现接口功能
        public void Print()
        {
            Console.WriteLine("通过B实现类来实现接口的Print()功能");
        }
        //静态实现类里额外需要的功能声明
        public static void ExtraPrint()
        {
            Console.WriteLine("这是B实现类额外需要的功能，并不影响接口内部");
        }
    }

    public class SimpleFactory
    {
        //定义一个接口变量
        Api_Print api = null;
        //声明一个创建接口Api对象的方法
        public Api_Print Api(int Judge)
        {
            if (Judge == 0)
            {
                //将对象的实例化交给工厂类里面去实现，实现了隔离思想
                api = new AImplementApi();
            }
            else
            {
                api = new BImplementApi();
            }
            return api;
        }
    }
}
