using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class KdTreeRenderer : MonoBehaviour
{
    private KdTree _tree; 
    
    List<Vector3 > points = new List<Vector3>
    {
        new Vector3(-20, 1,1),
        new Vector3(1,1,1),
        new Vector3(50,1,1),
        new Vector3(-15,1,1),
        new Vector3(52,1,1),
        new Vector3(32,1,1),
        new Vector3(13,1,1),
        new Vector3(29,1,1),
    };
    
    Vector3 playerPos = new Vector3(0,1,1);
    
    void Awake()
    {
        _tree = new KdTree(1 + points.Count);
        _tree.AddNode(playerPos);
        
        foreach (var point in points)
        {
            _tree.AddNode(point);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _tree?.UpdateTree();   
    }

    
    private void OnDrawGizmos()
    {
        if (_tree == null)
        {
            return;
        }

        var l = _tree.AllNodes();
        
        for (int i = 0, length = l.Count; i < length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(l[i], 0.5f);
            if (i !=0 && i % 2 == 0)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(new Vector3(l[i].x, -100, 0 ), new Vector3(l[i].x, 100, 0 ));
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(new Vector3(l[i].x, -100, 0 ), new Vector3(l[i].x, 100, 0 ));
                 
            }
        }
    }
}
