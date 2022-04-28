using UnityEditor;
using UnityEngine;

public class ObjectSpawner : EditorWindow               
{
    //menu vars
    private string obj_ParentName = "ParentObject";
    private GameObject ParentObject = null;
    private string obj_BaseName = "Object";
    private int obj_ID = 0;
    private float obj_Scale = 1f;
    private float obj_SpawnRadius = 5f;
    private GameObject obj_ToSpawn;
    public static int obj_SpawnType;
    private int ObjectsToSpawnAtOnce = 1;

    //other vars
    string[] SpawnTypes_Popup =
    {
        "Quad",
        "Circle",
        "Cube",
        "Sphere"
    };
    private Vector3 obj_SpawnPos = new Vector3(0.0f, 0.0f, 0.0f); //default object spawn position

    //         menu     submenu name
    [MenuItem("My Tools/Object Spawner")]
    public static void ShowWindow() { GetWindow(typeof(ObjectSpawner)); } //show window

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        GUILayout.Label("Spawn Objects", EditorStyles.boldLabel); //label for tool
        obj_ParentName =   EditorGUILayout.TextField("Parent Name", obj_ParentName);
        ParentObject =   EditorGUILayout.ObjectField("Parent Object", ParentObject, typeof(GameObject), true) as GameObject;
        obj_BaseName =     EditorGUILayout.TextField("Base Name", obj_BaseName);
        obj_ID =            EditorGUILayout.IntField("Object ID", obj_ID);
        obj_Scale =           EditorGUILayout.Slider("ObjectScale", obj_Scale, 0.5f, 3f);
        obj_SpawnRadius = EditorGUILayout.FloatField("Spawn Radius", obj_SpawnRadius);
        obj_ToSpawn =    EditorGUILayout.ObjectField("Object to Spawn", obj_ToSpawn, typeof(GameObject), true) as GameObject;
        obj_SpawnType =        EditorGUILayout.Popup("Type of spawn", obj_SpawnType, SpawnTypes_Popup);

        if (GUILayout.Button("Create Parrent")) { CreateParrent(); } //spawn parrent button
        ObjectsToSpawnAtOnce = EditorGUILayout.IntField("Objects to Spawn", ObjectsToSpawnAtOnce); //objects to spawn at once

        EditorGUI.BeginDisabledGroup(ParentObject == null); //if has no parrent object -> disable button
        if (GUILayout.Button("Spawn Objects")) { SpawnObjects(); } // spawn objects button
        EditorGUI.EndDisabledGroup(); 

        if (EditorGUI.EndChangeCheck()) { UpdateRenderFigure(); } //after buttons 
    }
    private void UpdateRenderFigure() //update values in object manager(parent object) 
    {
        ObjectManager.radius = obj_SpawnRadius;
        ObjectManager.Spawn_type = obj_SpawnType;
    }
    private int SpawnObjects()
    {
        for (int i = 0; i < ObjectsToSpawnAtOnce; i++)
        {
            if (SpawnObject() == 0) { obj_ID++; }
            else { break; }
        }
        return 0;
    }
    private void CreateParrent()
    {
        obj_ID = 0;
        ParentObject = new GameObject(obj_ParentName);
        ParentObject.AddComponent<ObjectManager>();
        ObjectManager.radius = obj_SpawnRadius;
        ObjectManager.Spawn_type = obj_SpawnType;
    }
    private int SpawnObject() // TODO: Refactor all logic
    {
        if (HasErrors() == 1)
        {
            return 1;
        }
        if (obj_SpawnType == 0) //QUAD spawn type
        {
            obj_SpawnPos = new Vector3(Random.Range(0 - obj_SpawnRadius, 0 + obj_SpawnRadius), 0,
            Random.Range(0 - obj_SpawnRadius, 0 + obj_SpawnRadius));
            Handles.DrawWireDisc(ParentObject.transform.position, ParentObject.transform.up, obj_SpawnRadius);
            
        } 
        else if (obj_SpawnType == 1) //CIRCLE spawn type
        {
            Vector2 PosInsideCirce = Random.insideUnitCircle * obj_SpawnRadius;
            Vector3 PosInsideCirce2 = new Vector3(PosInsideCirce.x, 0.0f, PosInsideCirce.y);
            obj_SpawnPos = PosInsideCirce2;
            
        }
        else if (obj_SpawnType == 2) //CUBE spawn type
        {
            obj_SpawnPos = new Vector3(
                Random.Range(0 - obj_SpawnRadius, 0 + obj_SpawnRadius), 
                Random.Range(0 - obj_SpawnRadius, 0 + obj_SpawnRadius),
                Random.Range(0 - obj_SpawnRadius, 0 + obj_SpawnRadius));
        }
        else if (obj_SpawnType == 3) //SHPERE spawn type
        {
            obj_SpawnPos = Random.insideUnitSphere * obj_SpawnRadius;

        }

        //spawn object and set properties
        GameObject newObject = Instantiate(obj_ToSpawn, obj_SpawnPos, Quaternion.identity);
        newObject.transform.SetParent(ParentObject.transform);
        newObject.transform.localPosition = obj_SpawnPos; 
        newObject.name = obj_BaseName + obj_ID;
        newObject.transform.localScale = Vector3.one * obj_Scale;
        return 0;
    }

    private int HasErrors()
    {
        if (ParentObject.GetComponent<ObjectManager>() == false)
        {
            ParentObject.AddComponent<ObjectManager>();
        }
        if (ParentObject == null)
        {
            Debug.LogError("Parent object does not exist");
            obj_ID = 0;
            return 1;
        }
        if (obj_ToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
            return 1;
        }
        if (obj_ParentName == string.Empty)
        {
            Debug.LogError("Error: Please enter a parent name for objects");
            return 1;
        }
        if (obj_BaseName == string.Empty)
        {
            Debug.LogError("Error: Please enter a base name for the object");
            return 1;
        }
        return 0;
    }
}
