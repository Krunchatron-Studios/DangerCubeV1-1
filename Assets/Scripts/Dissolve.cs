using UnityEngine;

public class Dissolve : MonoBehaviour {

	[SerializeField, Range(0, 1)] private float disAmountPerFrame = .04f;
	[SerializeField] private Renderer _renderer;
	private float dissolveTimer;

	public bool isDissolving;
	private void Start() {
		dissolveTimer = _renderer.material.GetFloat("_Fade");
	}

	private void FixedUpdate() {
		if (isDissolving) {
			DissolveTrigger();
		}
	}

	private void DissolveTrigger() {
		dissolveTimer -= disAmountPerFrame;
		_renderer.material.SetFloat("_Fade", dissolveTimer);
	}
}
