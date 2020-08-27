using UnityEngine;

namespace DefaultNamespace
{
    internal class KdNode
    {
//        internal IPositionComponent PositionComponent;
        internal Vector3 PositionComponent;
        internal KdNode LeftNode;
        internal KdNode RightNode;
        internal KdNode ParentNode;

        internal int Level;

        public KdNode(int lvl, Vector3 v, KdNode parent = null)
        {
            Level = lvl;
            PositionComponent = v;
            ParentNode = parent;
        }
    }
}