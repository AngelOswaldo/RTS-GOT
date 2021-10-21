using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public static class PropertyDrawersHelper
{
#if UNITY_EDITOR
    /// <summary>
    /// Obtiene los nombres de las escenas del proyecto que estén en la lista de Build (File > Build Settings).
    /// </summary>
    /// <returns></returns>
    public static string[] AllSceneNames()
    {
        var temp = new List<string>();
        foreach (EditorBuildSettingsScene S in EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {
                string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                name = name.Substring(0, name.Length - 6);
                temp.Add(name);
            }
        }
        return temp.ToArray();
    }
    /// <summary>
    /// Obtiene los ejes definidos para la clase Input (Edit > Project Settings > Input).
    /// </summary>
    /// <returns></returns>
    public static string[] AllAxes()
    {
        var temp = new List<string>();
        var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];
        SerializedObject obj = new SerializedObject(inputManager);
        SerializedProperty axisArray = obj.FindProperty("m_Axes");
        if (axisArray.arraySize == 0)
            Debug.Log("No Axes");
        for (int i = 0; i < axisArray.arraySize; ++i)
        {
            var axis = axisArray.GetArrayElementAtIndex(i);
            var name = axis.FindPropertyRelative("m_Name").stringValue;
            temp.Add(name);
        }
        return temp.ToArray();
    }
#endif
}