using Vector3U = UnityEngine.Vector3;
using Vector3SN = System.Numerics.Vector3;


    public static class CustomMathcs
    {
        public static Vector3U ConvertToUnityVector3(this Vector3SN vector3Sn)
        {
            return new Vector3U(vector3Sn.X, vector3Sn.Y, vector3Sn.Z);
        }
        public static Vector3U ConvertToUnityVector3(this Vector3SN vector3Sn, float zLayer)
        {
            return new Vector3U(vector3Sn.X, vector3Sn.Y, zLayer);
        }
        public static Vector3SN ConvertToSystemNumericsVector3(this Vector3U vector3U)
        {
            return new Vector3SN(vector3U.x, vector3U.y, vector3U.z);
        }
    }
