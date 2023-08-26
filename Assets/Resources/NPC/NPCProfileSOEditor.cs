using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[CustomEditor(typeof(NPCProfileSO))]
public class NPCProfileSOEditor : Editor
{
    private static List<Type> dataCompTypes = new List<Type>();

    private NPCProfileSO dataSO;

    private bool showAddComponentButtons;

    private void OnEnable()
    {
        dataSO = target as NPCProfileSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");

        if (showAddComponentButtons)
        {
            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    var comp = Activator.CreateInstance(dataCompType) as NPCComponent;

                    if (comp == null)
                        return;

                    dataSO.AddData(comp);

                    EditorUtility.SetDirty(dataSO);
                }
            }
        }
    }

    [DidReloadScripts]
    private static void OnRecompile()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var types = assemblies.SelectMany(assembly => assembly.GetTypes());
        var filteredTypes = types.Where(
            type => type.IsSubclassOf(typeof(NPCComponent)) && !type.ContainsGenericParameters && type.IsClass
        );
        dataCompTypes = filteredTypes.ToList();
    }
}

