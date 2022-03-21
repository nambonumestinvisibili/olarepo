using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lista4DawidHolewa
{
    public class TagBuilder
    {
        public TagBuilder(bool isIdentation, int identationDepth) {
            if (isIdentation && identationDepth < 0) throw new ArgumentException();
            IsIdentation = isIdentation;
            createIdentationString(identationDepth);
            recursiveDepth = -1;
        }

        private void createIdentationString(int identationDepth)
        {
            string str = "";
            for (int i = 0; i < identationDepth; i++)
            {
                str += " ";
            }
            _identation = str;
        }

        private TagBuilder(string TagName, TagBuilder Parent, int recursiveDepth)
        {
            this.tagName = TagName;
            this.parent = Parent;
            this.recursiveDepth = recursiveDepth;
        }

        private string tagName;
        private TagBuilder parent;
        private StringBuilder body = new StringBuilder();
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();
        private static bool IsIdentation = false;
        private static string _identation;
        private int recursiveDepth;
        public TagBuilder AddContent(string Content)
        {
            body.Append(Content);
            return this;
        }

        public TagBuilder AddContentFormat(string Format, params object[] args)
        {
            body.AppendFormat(Format, args);
            return this;
        }

        public TagBuilder StartTag(string TagName)
        {
            TagBuilder tag = new TagBuilder(TagName, this, recursiveDepth+1);

            return tag;
        }

        public TagBuilder EndTag()
        {
            parent.AddContent(this.ToString());
            return parent;
        }

        public TagBuilder AddAttribute(string Name, string Value)
        {
            _attributes.Add(Name, Value);
            return this;
        }

        private void identTag(StringBuilder tag)
        {
            if (IsIdentation)
            {
                tag.Append("\n");
                for (int i = 0; i < recursiveDepth; i++)
                {
                    tag.Append(_identation);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder tag = new StringBuilder();

            // preamble
            if (!string.IsNullOrEmpty(this.tagName))
            {
                identTag(tag);
                tag.AppendFormat("<{0}", tagName);
            }

            if (_attributes.Count > 0)
            {
                tag.Append(" ");
                tag.Append(
                    string.Join(" ",
                        _attributes
                            .Select(
                                kvp => string.Format("{0}='{1}'", kvp.Key, kvp.Value))
                            .ToArray()));
            }

            // body/ending
            if (body.Length > 0)
            {
                if (!string.IsNullOrEmpty(this.tagName) || this._attributes.Count > 0)
                    tag.Append(">");
                identTag(tag);
                tag.Append(_identation + body.ToString());
                if (!string.IsNullOrEmpty(this.tagName))
                {
                    identTag(tag);
                    tag.AppendFormat("</{0}>\n", this.tagName, this.recursiveDepth);
                }
            }
            else
                if (!string.IsNullOrEmpty(this.tagName))
                tag.Append("/>\n");

            return tag.ToString();
        }
    }
}
