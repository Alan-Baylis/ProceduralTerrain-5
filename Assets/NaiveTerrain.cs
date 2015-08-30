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
		int verticesPerTriangle = 3;
		int trianglesPerCell = 2;
		int numberOfCells = size * size;
		int[] triangles = new int[numberOfCells * trianglesPerCell * verticesPerTriangle];
		int triangleIndex = 0;
		for (int cx = 0; cx < size; cx++) {
			for (int cz = 0; cz < size; cz++) {
				int n = cx * (size + 1) + cz;

				// First triangle of the pair
				triangles[triangleIndex] = n;
				triangles[triangleIndex + 1] = n + 1;
				triangles[triangleIndex + 2] = n + size + 2;
				triangleIndex += 3;

				// Second triangle of the pair
				triangles[triangleIndex] = n;
				triangles[triangleIndex + 1] = n + size + 2;
				triangles[triangleIndex + 2] = n + size + 1;
				triangleIndex += 3;

			}
		}

		return triangles;
	}

	Vector2[] GenerateUVs () {
		int sideVertices = size + 1;
		Vector2[] uvs = new Vector2[sideVertices * sideVertices];

		for (int ux = 0; ux < sideVertices; ux++) {
			for (int uz = 0; uz < sideVertices; uz++) {
				uvs[ux * sideVertices + uz] = new Vector2((float)ux / size, (float)uz / size);
			}
		}

		return uvs;
	}
}
