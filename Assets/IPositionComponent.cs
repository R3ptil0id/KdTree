using System;
using System.Numerics;

namespace DefaultNamespace
{
    public interface IPositionComponent
    {
        Vector3 Position { get;}
        Guid Guid { get; }
    }
}