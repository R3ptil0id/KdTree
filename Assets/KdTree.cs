using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class KdTree
    {
        private readonly List<KdNode> _tree;
        private KdNode _root;

        public KdTree(int maxNodes)
        {
            _tree = new List<KdNode>(maxNodes);
        }


        public void AddNode(Vector3 pos)
        {
            if (_root == null)
            {
                _root = new KdNode(0, pos);
                _tree.Add(_root);
                return;
            }

            var current = _root;
            var parent = _root;

            float splittedCurrent;
            float splittedNew;
            while (current != null)
            {
                splittedCurrent = GetSplited(current.Level, current.PositionComponent);
                splittedNew = GetSplited(current.Level, pos);
                
                parent = current;
                current = splittedCurrent < splittedNew ? current.RightNode : current.LeftNode;
            }
            
            splittedCurrent = GetSplited(parent.Level, parent.PositionComponent);
            splittedNew = GetSplited(parent.Level, pos);
            
           var newNode = new KdNode(parent.Level + 1, pos, parent);

            if (splittedCurrent < splittedNew)
                parent.RightNode = newNode;
            else
                parent.LeftNode = newNode;
            
            _tree.Add(newNode);
        }

        private float GetSplited(int lvl, Vector3 pos)
        {
            var l = lvl % 2; 
            return lvl % 2 == 0 ? pos.x : pos.y;
        }

        public void UpdateTree()
        {
//            var l = List
        }

        public List<Vector3> AllNodes()
        {
            var l = new List<Vector3>();

            foreach (var n in _tree)
            {
                l.Add(n.PositionComponent);
            }

            return l;
        }

        public List<Vector3> GetCopyPositions()
        {
            var l = new List<Vector3>(_tree.Count);

            foreach (var node in _tree)
            {
                l.Add(node.PositionComponent);     
            }
            
            return l;
        }
    }
}