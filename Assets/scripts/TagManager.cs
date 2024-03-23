using UnityEngine;
using UnityEditor;

public class AddMultipleTags : EditorWindow
{
    string newTags = "";

    [MenuItem("Tools/Add Multiple Tags")]
    static void Init()
    {
        AddMultipleTags window = (AddMultipleTags)EditorWindow.GetWindow(typeof(AddMultipleTags));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Add Multiple Tags", EditorStyles.boldLabel);
        newTags = EditorGUILayout.TextField("New Tags (comma-separated)", newTags);

        if (GUILayout.Button("Add Tags"))
        {
            AddTags();
        }
    }

    void AddTags()
    {
        if (Selection.gameObjects.Length > 0 && !string.IsNullOrEmpty(newTags))
        {
            string[] tagsToAdd = newTags.Split(',');

            foreach (GameObject obj in Selection.gameObjects)
            {
                foreach (string tag in tagsToAdd)
                {
                    if (!obj.CompareTag(tag.Trim()))
                    {
                        obj.tag += " " + tag.Trim();
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("No objects selected or no tags provided.");
        }
    }
}
