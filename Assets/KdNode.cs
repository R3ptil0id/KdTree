using UnityEngine;

namespace DefaultNamespace
{
    public class KdNode
    {
        internal Vector3 Key;
        internal KdNode LeftNode;
        internal KdNode RightNode;
        internal KdNode ParentNode;

        public int  heightLevel;
        public int Level;
        
        public KdNode(int lvl, Vector3 v, KdNode parent = null)
        {
            Level = lvl;
            Key = v;
            ParentNode = parent;
            heightLevel = 0;
        }
    }
}