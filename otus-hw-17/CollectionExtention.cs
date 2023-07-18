using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Класс и Метод расширения поиска Максимального
public static class CollectionExtention
{
    public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : class
    {
        T? MaxT = default(T);
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
