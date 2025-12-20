using System.Collections.Generic;
using System.ComponentModel;

namespace POFF.Meet.Extensions;

public static class BindingListExtensions
{
    public static void AddRange<T>(this BindingList<T> bindingList, IEnumerable<T> values)
    {
        bindingList.Clear();
        foreach (var value in values)
        {
            bindingList.Add(value);
        }
    }

    public static void SetValues<T>(this BindingList<T> bindingList, IEnumerable<T> values)
    {
        bindingList.Clear();
        bindingList.AddRange(values);
    }
}
