using System;
using UnityEngine;

public abstract class AIBase : MonoBehaviour {

	public BaseEnemy enemy;
	public SpriteRenderer spriteRenderer;
	public float distance;
	public bool hasEngaged;

	private void Start() {
		hasEngaged = false;
	}
}
