using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlockGen))]
public class BlockGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BlockGen generator = (BlockGen)target;

        if (DrawDefaultInspector())
        {
            if (generator.autoUpdate) {

                if (GameObject.FindGameObjectWithTag("Block") != null)
                {
                    generator.DestroyBlocks();
                }
                generator.GenerateBlocks();
            }
        }

        if (GUILayout.Button("Generate")) {
            if (GameObject.FindGameObjectWithTag("Block") != null)
            {
                generator.DestroyBlocks();
            }
            generator.GenerateBlocks();
        }

        if (GUILayout.Button("Destroy")) {
            if (GameObject.FindGameObjectWithTag("Block") != null)
            {
                generator.DestroyBlocks();
            }
        }
    }
}
