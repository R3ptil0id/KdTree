using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DefaultNamespace
{
    public class KdTree
    {
        private KdNode _root;

        private void Insert(IPositionComponent pos, KdNode node = null)
        {
            if (_root == null)
            {
                _root = new KdNode(pos, 0);
                return;
            }

            var parent = node ?? _root;
            var splitParent = parent.Level % 2 == 0 ? parent.Key.Position.X : parent.Key.Position.Y;
            var splitCurrent = parent.Level % 2 == 0 ? pos.Position.X : pos.Position.Y;

            if (splitCurrent < splitParent)
            {
                if (parent.LeftNode != null)
                {
                    Insert(pos, parent.LeftNode);
                }
                else
                {
                    var newNode = new KdNode(pos,parent.Level+1, parent);
                    parent.LeftNode = newNode;
                }
            }
            else 
            {
                if (parent.RightNode != null)
                {
                    Insert(pos, parent.RightNode);
                }
                else
                {
                    var newNode = new KdNode(pos,parent.Level+1, parent);
                    parent.RightNode = newNode;
                }
            }
        }

        public void GenerateTree(List<IPositionComponent> list)
        {
            var sorted = list.OrderBy(c => c.Position.X).ToList();
            var index = sorted.Count/2;
            var median = sorted[index];
            sorted.RemoveAt(index);
            sorted.Insert(0, median);
            
            foreach (var positionComponent in sorted)
            {
                AddNode(positionComponent);
            }
        }

        private void AddNode(IPositionComponent posComponent)
        {
            if (_root == null)
            {
                _root = new KdNode(posComponent, 0);
                return;
            }

            var current = _root;
            var parent = _root;
            var isRightBranch = false;

            while (current != null)
            {
                var splittedCurrent = GetSplited(current.Level, current.Key.Position);
                var splittedNew = GetSplited(current.Level, posComponent.Position);

                isRightBranch = splittedCurrent < splittedNew;

                parent = current;
                current = isRightBranch ? current.RightNode : current.LeftNode;
            }

            var newNode = new KdNode( posComponent, parent.Level + 1, parent);

            if (isRightBranch)
                parent.RightNode = newNode;
            else
                parent.LeftNode = newNode;
        }

        private float GetSplited(int lvl, Vector3 pos)
        {
            return lvl % 2 == 0 ? pos.X : pos.Y;
        }

        public void UpdateTree()
        {
           
        }
    }
}
