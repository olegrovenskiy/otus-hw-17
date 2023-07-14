using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");



var x1 = new TestClass(2);
var x2 = new TestClass(15);
var x3 = new TestClass(9);
var x4 = new TestClass(3);
var x5 = new TestClass(29);
var x6 = new TestClass(4);


List<TestClass> TestCollection = new List<TestClass>() { x1, x2, x3, x4, x5, x6};

//var test = TestCollection.GetMax<TestClass>(x => (float)Convert.ToDecimal(x));

var test = TestCollection.GetMax<TestClass>(ToNumber);

Console.WriteLine(test.Number);




Console.ReadKey();

// преобразующий входной тип в число
float ToNumber <T> (T t) where T : class
{

    Type myType = typeof(T);
    float num = 0; 

    foreach (var l in myType.GetProperties())
    {

        var ff = myType.GetProperty(l.Name);
        var ff1 = ff?.GetValue(t);
        num = num + (float) Convert.ToDecimal(ff1);
    }
    return num;

}




public static class CollectionExtention
{

    public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : class
    {
            
        T MaxT = null;
        float f = float.MinValue;

        foreach (T i in e)
        {
            var d = getParameter(i);
            if (d > f)
            {
                MaxT = i;
                f = d;
            }
        }

        return MaxT;
    }
}



public class TestClass
{
    public int Number { get; set; }
    public TestClass(int number)
    { this.Number = number; }
}












