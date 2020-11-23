namespace DefaultNamespace
{
    public class XNode
    {
        public IPositionComponent Key;
        internal XNode LeftNode;
        internal XNode RightNode;

        public int HeightLevel;
        
        internal XNode(IPositionComponent positionComponent)
        {
            Key = positionComponent;
            HeightLevel = 1;
        }
    }
}