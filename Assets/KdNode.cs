namespace DefaultNamespace
{
    public class KdNode
    {
        internal IPositionComponent Key;
        internal KdNode LeftNode;
        internal KdNode RightNode;
        internal KdNode ParentNode;

        public int Level;
        
        public KdNode(IPositionComponent positionComponent, int lvl, KdNode parent = null)
        {
            Level = lvl;
            Key = positionComponent;
            ParentNode = parent;
        }
    }
}