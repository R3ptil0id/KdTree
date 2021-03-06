﻿using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class KdTreeRenderer : MonoBehaviour
{
    private KdTree _tree;
    private XTree _xTree;
    
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
    
    private List<int > Xpoints = new List<int>
    {
        0, -20, 1, 50, 52
    };
    
    void Awake()
    {
        _xTree = new XTree();
        var list = new List<IPositionComponent>(Xpoints.Count);
        foreach (var point in Xpoints)
        {
            var posComponent = new ComponentTestImpimentation(new System.Numerics.Vector3(point, 0,0));
            list.Add(posComponent);
        }
        _xTree.GenerateTree(list);
        
//        _tree = new KdTree();
//        points.Add(playerPos);
//
//        var list = new List<IPositionComponent>(points.Count);
//        foreach (var point in points)
//        {
//            var posComponent = new ComponentTestImpimentation(point.ConvertToSystemNumericsVector3());
//            list.Add(posComponent);
//        }
//        
//        _tree.GenerateTree(list);
    }

    // Update is called once per frame
    void Update()
    {
        _tree?.UpdateTree();   
    }
}

class ComponentTestImpimentation : IPositionComponent
{
    public System.Numerics.Vector3 Position { get; }
    public Guid Guid { get; }

    public ComponentTestImpimentation(System.Numerics.Vector3 position)
    {
        Position = position;
        Guid = Guid.NewGuid();
    }
}
