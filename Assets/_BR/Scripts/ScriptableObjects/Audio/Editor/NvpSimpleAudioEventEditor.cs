using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NvpSimpleAudioEvent))]
public class NvpSimpleAudioEventEditor : Editor
{
    [SerializeField] private AudioSource _previewer;

    void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.None, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        DestroyImmediate(_previewer.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            ((NvpSimpleAudioEvent)target).Play(_previewer);
        }
        EditorGUI.EndDisabledGroup();
    }
}
