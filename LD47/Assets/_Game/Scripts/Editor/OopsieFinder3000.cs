
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class OopsieFinder3000 : EditorWindow
{
    [SerializeField] private bool resetScale = true;
    [SerializeField] private Mesh meshToReplace;
    [SerializeField] private GameObject replacementPrefab;
    [SerializeField] private Vector3 rotationOffset = Vector3.zero;

    private int replacementCounter;
    private int skippedPrefabCounter;

    [MenuItem("Tools/Oopsie Finder 3000 !")]
    public static void Create()
    {
        EditorWindow.GetWindow<OopsieFinder3000>();
    }

    private void OnGUI()
    {
        resetScale = EditorGUILayout.Toggle("Reset scale", resetScale);
        meshToReplace = (Mesh)EditorGUILayout.ObjectField("Mesh to replace", meshToReplace, typeof(Mesh), false);
        replacementPrefab = (GameObject)EditorGUILayout.ObjectField("Replacement prefab", replacementPrefab, typeof(GameObject), false);
        rotationOffset = EditorGUILayout.Vector3Field("Rotation offset", rotationOffset);

        if (GUILayout.Button("Replace"))
        {
            EditorSceneManager.MarkAllScenesDirty();

            replacementCounter = 0;
            skippedPrefabCounter = 0;

            var prefabType = PrefabUtility.GetPrefabAssetType(replacementPrefab);
            var meshFilters = FindObjectsOfType<MeshFilter>();

            for (var i = 0; i < meshFilters.Length; i++)
            {
                var meshFilter = meshFilters[i];

                if (meshFilter.sharedMesh != meshToReplace)
                {
                    continue;
                }

                if (!CheckIsDestructible(meshFilter.gameObject))
                {
                    skippedPrefabCounter++;

                    continue;
                }

                GameObject newObject;
                if (prefabType == PrefabAssetType.Regular)
                {
                    newObject = (GameObject)PrefabUtility.InstantiatePrefab(replacementPrefab);
                }
                else
                {
                    newObject = Instantiate(replacementPrefab);
                    newObject.name = replacementPrefab.name;
                }

                if (newObject == null)
                {
                    Debug.LogError("Error instantiating prefab");
                    return;
                }

                Undo.RegisterCreatedObjectUndo(newObject, "Replace With Prefabs");

                newObject.transform.SetSiblingIndex(meshFilter.transform.GetSiblingIndex());

                if (meshFilter.transform.parent != null)
                {
                    newObject.transform.parent = meshFilter.transform.parent;
                }

                newObject.transform.localPosition = meshFilter.transform.localPosition;
                newObject.transform.localRotation = meshFilter.transform.localRotation * Quaternion.Euler(rotationOffset);

                if (resetScale)
                {
                    newObject.transform.localScale = Vector3.one;
                }
                else
                {
                    newObject.transform.localScale = meshFilter.transform.localScale;
                }

                //EditorGUIUtility.PingObject(meshFilter.gameObject);

                Undo.DestroyObjectImmediate(meshFilter.gameObject);
                //DestroyImmediate(meshFilter.gameObject);

                replacementCounter++;
            }
        }

        GUI.enabled = false;
        EditorGUILayout.LabelField("Objects replaced : " + replacementCounter);
        EditorGUILayout.LabelField("Objects skipped because inside prefabs : " + skippedPrefabCounter);
    }

    private bool CheckIsDestructible(GameObject go)
    {
        if (go.transform.parent == null)
            return true;

        return PrefabUtility.GetNearestPrefabInstanceRoot(go.transform.parent) == null;
    }
}
