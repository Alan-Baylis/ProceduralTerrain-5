using UnityEngine;
using System.Collections;

public class Perlin {

	private int poolSize = 500;
	private Vector2[] pool;

	public Perlin () {
		pool = new Vector2[poolSize];
		for (int i = 0; i < pool.Length; i++) {
			pool[i] = new Vector2(Random.value, Random.value).normalized;
		}
	}

	private Vector2 GradientAt(int x, int y) {
		int index = Mathf.RoundToInt (0.5f * (x + y) * (x + y + 1) + y) % poolSize;
		return pool[index];
	}

	private float Lerp (float a, float b, float w) {
		return (a * (1.0f - w)) + (b * w);
	}

	public float Get (float x, float y) {
		return 0.0f;
	}
}
