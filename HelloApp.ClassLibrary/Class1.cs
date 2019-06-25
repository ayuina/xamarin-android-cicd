using System;

namespace HelloApp.ClassLibrary
{
    public class Class1
    {
        public static string Hello(string name)
        {
            if (string.IsNullOrEmpty(name))
                return $"Hello Anonymous ?";
            return $"Hello {name} !!!";
        }
    }
}
