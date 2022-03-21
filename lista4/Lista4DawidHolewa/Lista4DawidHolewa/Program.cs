using System;

namespace Lista4DawidHolewa
{
    class Program
    {
        static void Main(string[] args)
        {
            TagBuilder tag = new TagBuilder(true,0);
            var script =
             tag.StartTag("parent")
                 .AddAttribute("parentproperty1", "true")
                 .AddAttribute("parentproperty2", "5")
                     .StartTag("child1")
                     .AddAttribute("childproperty1", "c")
                     .AddContent("childbody")
                     .EndTag()
                     .StartTag("child2")
                     .AddAttribute("childproperty2", "c")
                     .AddContent("childbody")
                     .EndTag()
                 .EndTag()
                 .StartTag("script")
                 .AddContent("$.scriptbody();")
                 .EndTag()
                 .ToString();
            Console.WriteLine(tag);
        }
    }
}
