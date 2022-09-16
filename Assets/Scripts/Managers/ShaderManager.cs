using UnityEngine;

public class ShaderManager : MonoBehaviour {
	public static ShaderManager shm;

	private void Start() {
		shm = this;
	}

	public Material spriteLit;
	public Material glow;
}
