using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class XTree
    {
        private XNode _root;
        private int _count;

        public void GenerateTree(List<IPositionComponent> list)
        {
            foreach (var positionComponent in list)
            {
//                AddNode(positionComponent);
                Insert(positionComponent);
            }
            
            Debug.Log(GetBalanceFactor(_root));
        }


        private void Insert(IPositionComponent posComponent, XNode node = null)
        {
            if (_root == null)
            {
                _root = new XNode(posComponent);
                return;
            }

            if (node == null)
            {
                node = _root;
            }

            if (node.Key.Position.X > posComponent.Position.X)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new XNode(posComponent);
                }
                else
                {
                    Insert(posComponent, node.LeftNode);
                }
            }
            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new XNode(posComponent);
                }
                else
                {
                    Insert(posComponent, node.RightNode);
                }
            }

            BalanceParent(node);
            _count++;
        }

//        private void AddNode(IPositionComponent posComponent)
//                 {
//                     if (_root == null)
//                     {
//                         _root = new XNode(posComponent);
//                         return;
//                     }
//         
//                     var current = _root;
//                     var parent = _root;
//                     var isRightBranch = false;
//         
//                     while (current != null)
//                     {
//                         isRightBranch = parent.Key.Position.X < posComponent.Position.X;
//         
//                         parent = current;
//                         current = isRightBranch ? current.RightNode : current.LeftNode;
//                     }
//         
//                     var newNode = new XNode(posComponent, parent);
//                     
//                     if (isRightBranch)
//                         parent.RightNode = newNode;
//                     else
//                         parent.LeftNode = newNode;
//         
//         //            parent = newNode;
//                     while (parent != null)
//                     {
//                         var key = parent.Key.Position;
//                         var parentKey = parent.ParentNode?.Key.Position;
//                         
//                         BalanceParent(parent);
//                         parent = parent.ParentNode;
//                     }
//                 }

        private static void BalanceParent(XNode parent)
        {
            UpdateLevel(parent);
            
            if (GetBalanceFactor(parent) == 2)
            {
                if (GetBalanceFactor(parent.RightNode) < 0)
                    RotateRight(parent.RightNode);
                else
                    RotateLeft(parent);
            }

            if (GetBalanceFactor(parent) == -2)
            {   
                if (GetBalanceFactor(parent.RightNode) > 0)
                    RotateLeft(parent.RightNode);
                else
                    RotateRight(parent);
            }
        }

        private static int GetBalanceFactor(XNode parent)
        {
            return GetHeightLevel(parent.RightNode) - GetHeightLevel(parent.LeftNode) ;
        }

        private static void UpdateLevel(XNode parent)
        {
            var leftLevel = GetHeightLevel(parent.LeftNode);
            var rightLevel = GetHeightLevel(parent.RightNode);

            parent.HeightLevel = (leftLevel > rightLevel ? leftLevel : rightLevel) + 1;
        }

        private static int GetHeightLevel(XNode parentNode)
        {
            return parentNode?.HeightLevel ?? 0;
        }

        private static void RotateLeft(XNode node)
        {
            var current = node;
            current.ParentNode.RightNode = current.RightNode;
            
            current.RightNode
        }

        private static void RotateRight(XNode node)
        {
            Debug.Log("to right " + node.Key.Position);
        }
    }
}