using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PerlinTerrain))]
public class PerlinTerrainEditor : Editor {
	
	public override void OnInspectorGUI () 
	{
		DrawDefaultInspector ();
		
		PerlinTerrain terrain = (PerlinTerrain)target;
		if (GUILayout.Button("Regenerate")) {
			terrain.Regenerate();
		}
	}
	
}
