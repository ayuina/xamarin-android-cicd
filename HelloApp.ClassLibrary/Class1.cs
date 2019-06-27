using System;

namespace HelloApp.ClassLibrary
{
    public class Class1
    {
        public static string Hello(string name)
        {
            if(name.Length == 0)
            {
                return $"Hello Anonymous ???";
            }
            return $"Hello {name}-san Sony !!!";
        }
    }
}
