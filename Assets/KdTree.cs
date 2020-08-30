using UnityEngine;

namespace DefaultNamespace
{
    public class KdTree
    {
        private KdNode _root;

        public void Insert(Vector3 pos, KdNode node = null)
        {
            if (_root == null)
            {
                _root = new KdNode(0, pos);
                return;
            }

            var parent = node ?? _root;
            var splitParent = parent.Level % 2 == 0 ? parent.Key.x : parent.Key.y;
            var splitCurrent = parent.Level % 2 == 0 ? pos.x : pos.y;

            if (splitCurrent < splitParent)
            {
                if (parent.LeftNode != null)
                {
                    Insert(pos, parent.LeftNode);
                }
                else
                {
                    var newNode = new KdNode(parent.Level+1, pos, parent);
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
                    var newNode = new KdNode(parent.Level+1, pos, parent);
                    parent.RightNode = newNode;
                }
            }
        }

        public void AddNode(Vector3 pos)
        {
            if (_root == null)
            {
                _root = new KdNode(0, pos);
                return;
            }

            var current = _root;
            var parent = _root;
            var splittedCurrent = 0f;
            var splittedNew = 0f;

            while (current != null)
            {
                splittedCurrent = GetSplited(current.Level, current.Key);
                splittedNew = GetSplited(current.Level, pos);

                parent = current;
                current = splittedCurrent < splittedNew ? current.RightNode : current.LeftNode;
            }

            var newNode = new KdNode(parent.Level + 1, pos, parent);

            if (splittedCurrent < splittedNew)
                parent.RightNode = newNode;
            else
                parent.LeftNode = newNode;
        }

        private float GetSplited(int lvl, Vector3 pos)
        {
            return lvl % 2 == 0 ? pos.x : pos.y;
        }

        public void UpdateTree()
        {
           
        }
    }
}
