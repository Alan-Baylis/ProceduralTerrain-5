using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class NaiveTerrain : MonoBehaviour {

	public int size = 4;
	public float cellSize = 1.0f;

	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.vertices = GenerateVertices();
		mesh.triangles = GenerateTriangles();
		mesh.uv = GenerateUVs();
		mesh.RecalculateNormals();

	}

	Vector3[] GenerateVertices () {
		int sideVertices = size + 1;
		Vector3[] vertices = new Vector3[sideVertices * sideVertices];

		for (int gx = 0; gx < sideVertices; gx++) {
			for (int gz = 0; gz < sideVertices; gz++) {
				vertices[gx * sideVertices + gz] = new Vector3(gx * cellSize, 0.0f, gz * cellSize);
			}
		}

		return vertices;
	}

	int[] GenerateTriangles () {
		return null;
	}

	Vector2[] GenerateUVs () {
		return null;
	}
}
