using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lista4DawidHolewa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Lista4DawidHolewa.Tests
{
    [TestClass()]
    public class TagBuilderTests
    {

        private string helper(TagBuilder tag)
        {
            return tag.StartTag("parent")
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
        }

        [TestMethod()]
        public void NoIdentation()
        {
            TagBuilder tag = new TagBuilder(false, -1);
            var result = helper(tag);
            Assert.IsTrue(result.Contains("\n"));
        }

        [TestMethod()]
        public void WithNewlinesNoIdentation()
        {
            TagBuilder tag = new TagBuilder(true, 0);
            var result = helper(tag);
            bool flag = true;
            for (int i = 0; i < result.Length; i++)
            {
                if (i != result.Length-1 && result[i].Equals("\n"))
                {
                    if (result[i + 1].Equals(" "))
                        flag = false;
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void IdentationWithDepth1()
        {
            TagBuilder tag = new TagBuilder(true, 1);
            var result = helper(tag);
            var lines = result.Split("\n");

            bool flag = !lines[2].StartsWith(" ") &&
                lines[4].StartsWith(" ") &&
                lines[5].StartsWith("  ") &&
                lines[6].StartsWith(" ");
            
            Assert.IsTrue(
                flag
                );

        }
    }
}