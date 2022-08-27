using UnityEngine;

public class Dissolve : MonoBehaviour {

	[SerializeField, Range(0, 1)] private float disAmountPerFrame = .04f;
	[SerializeField] private Renderer _renderer;
	[SerializeField] private ParticleSystem ashes;
	private float dissolveTimer;
	private bool reducedToAshes;

	public bool isDissolving;
	private void Start() {
		dissolveTimer = _renderer.material.GetFloat("_Fade");
		reducedToAshes = true;
	}

	private void FixedUpdate() {
		if (isDissolving) {
			DissolveTrigger();
			if (reducedToAshes) {
				Debug.Log("fireflies");
				reducedToAshes = false;
				ashes = Instantiate(ashes, transform.position, Quaternion.identity);
			}
		}
	}

	private void DissolveTrigger() {
		dissolveTimer -= disAmountPerFrame;
		_renderer.material.SetFloat("_Fade", dissolveTimer);
	}
}
