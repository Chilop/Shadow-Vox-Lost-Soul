using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(BlocksScriptable))]
public class FillButton : Editor
{
   /* public override void OnInspectorGUI()
    {
        BlocksScriptable blocksScriptable = (BlocksScriptable)target;
        blocksScriptable.DevBlocks = EditorGUILayout.ObjectField("DevBlocks", blocksScriptable.DevBlocks);
        if (GUILayout.Button("generateBlock"))
        {
            blocksScriptable.FillPlayableArea();
        }
        
        //base.OnInspectorGUI();
    }*/
}
