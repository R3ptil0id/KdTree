using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class KdTreeRenderer : MonoBehaviour
{
    private KdTree _tree;
    
    public List<Vector3 > points = new List<Vector3>
    {
        new Vector3(-20, 4,1),
        new Vector3(1,0,1),
        new Vector3(50,1,1),
        new Vector3(-15,15,1),
        new Vector3(52,9,1),
        new Vector3(32,23,1),
        new Vector3(13,11,1),
        new Vector3(29,12,1)
    };
    
    Vector3 playerPos = new Vector3(0,1,1);
    
    void Awake()
    {
        _tree = new KdTree();
        _tree.AddNode(playerPos);
//        _tree.Insert(playerPos);
        
        foreach (var point in points)
        {
            _tree.AddNode(point);
//            _tree.Insert(point);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _tree?.UpdateTree();   
    }
}
