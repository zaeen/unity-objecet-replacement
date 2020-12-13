using UnityEditor;
using UnityEngine;


public class replaceobject : EditorWindow
{
    public Object source;

    [MenuItem("Ojectediting/Objectreplacment")]
    static void Init()
    {
        var window = GetWindowWithRect<replaceobject>(new Rect(0, 0, 165, 100));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        source = EditorGUILayout.ObjectField(source, typeof(Object), true);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Replace!"))
        {
            if (source != null)
            {
                foreach (Transform transform in Selection.transforms)
                {
                    GameObject g1 = Instantiate(source) as GameObject;
                    g1.transform.localPosition = transform.localPosition;
                    g1.transform.localRotation = transform.localRotation;

                    Undo.DestroyObjectImmediate(transform.gameObject);
                }
            }
            else
                ShowNotification(new GUIContent("No object selected for replacing"));
        }
    }
}
