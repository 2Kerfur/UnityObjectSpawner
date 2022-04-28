using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[ExecuteAlways]
public class ObjectManager : MonoBehaviour
{
    public static int Spawn_type = 1;
    public static float radius = 1;
    private void OnDrawGizmosSelected()
    {
        if (Spawn_type == 0) //QUAD draw
        {
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
            //create points
            Vector3 Point1 = new Vector3(this.transform.position.x + radius, this.transform.position.y, this.transform.position.z + radius);
            Vector3 Point2 = new Vector3(this.transform.position.x + radius, this.transform.position.y, this.transform.position.z - radius);
            Vector3 Point3 = new Vector3(this.transform.position.x - radius, this.transform.position.y, this.transform.position.z - radius);
            Vector3 Point4 = new Vector3(this.transform.position.x - radius, this.transform.position.y, this.transform.position.z + radius);
            //draw quad
            Handles.DrawAAPolyLine(Point1, Point2);
            Handles.DrawAAPolyLine(Point2, Point3);
            Handles.DrawAAPolyLine(Point3, Point4);
            Handles.DrawAAPolyLine(Point4, Point1);
        }
        else if (Spawn_type == 1) //CIRCLE draw
        {
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
            Vector3 diskPos = new Vector3(0f, 0f, 0f);
            Handles.DrawWireDisc(this.transform.position, this.transform.up, radius);
        }
        else if (Spawn_type == 2) //CUBE draw
        {
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
            Vector3 cubeRadius = new Vector3(radius, radius, radius);
            Handles.DrawWireCube(this.transform.position, cubeRadius + cubeRadius);
        }
        else if (Spawn_type == 3) //SPHERE draw
        {
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
            Gizmos.DrawWireSphere(this.transform.position, radius);
        }
    }
}
#endif
