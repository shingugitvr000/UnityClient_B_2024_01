using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NPCActor))]
public class NPCEditor : Editor
{
    void OnSceneGUI()
    {
        NPCActor npcActor = (NPCActor)target;
        if (npcActor == null)
            return;

        Handles.color = Color.blue;
        Handles.Label(npcActor.transform.position + Vector3.up * 2,
            npcActor.npcName + "\n" + npcActor.transform.position.ToString());
    }
}
