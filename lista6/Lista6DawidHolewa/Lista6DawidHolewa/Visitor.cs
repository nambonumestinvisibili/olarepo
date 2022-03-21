using System;
using System.Collections.Generic;
using System.Text;

namespace Lista6DawidHolewa
{
    public abstract class Tree
    {
        public void Accept(TreeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class TreeNode : Tree
    {
        public Tree Left { get; set; }
        public Tree Right { get; set; }
    }
    public class TreeLeaf : Tree
    {
    }

    public abstract class TreeVisitor
    {
        public void Visit(Tree tree)
        {
            if (tree is TreeNode)
                this.VisitNode((TreeNode)tree);
            if (tree is TreeLeaf)
                this.VisitLeaf((TreeLeaf)tree);
        }
        public virtual void VisitNode(TreeNode node)
        {
            // tu wiedza o odwiedzaniu struktury
            if (node != null)
            {
                this.Visit(node.Left);
                this.Visit(node.Right);
            }
        }
        public virtual void VisitLeaf(TreeLeaf leaf)
        {
        }
    }
    

    public class DepthTreeVisitor : TreeVisitor
    {
        private int _currentDepth = -1;

        public override void VisitNode(TreeNode node)
        {
            _currentDepth++;
            Visit(node.Left);
            Visit(node.Right);
            _currentDepth--;
        }

        public override void VisitLeaf(TreeLeaf leaf)
        {
            _currentDepth++;
            if (_currentDepth > Depth)
                Depth = _currentDepth;
            _currentDepth--;
        }

        public int Depth { get; private set; }
    }
}
