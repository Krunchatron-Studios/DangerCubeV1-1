using Managers;
using UnityEngine;

namespace Effects {
	[RequireComponent(typeof(Renderer))]
	public class Dissolve : MonoBehaviour {

		[SerializeField, Range(0, 1)] private float disAmountPerFrame = .04f;
		[SerializeField] private Renderer renderer;
		[SerializeField] private GameObject ashes;
		private float _dissolveTimer;
		private bool _reducedToAshes;

		public bool isDissolving;
		private static readonly int fade = Shader.PropertyToID("_Dissolve_Amount");

		private void Start() {
			renderer = GetComponent<SpriteRenderer>();
			_reducedToAshes = true;
		}

		private void FixedUpdate() {
			if (isDissolving) {
				_dissolveTimer = renderer.material.GetFloat(fade);
				DissolveTrigger();
				if (_reducedToAshes) {
					_reducedToAshes = false;
					ashes = PoolManager.pm.ashesPool.GetPooledGameObject();
				}
			}
		}

		private void DissolveTrigger() {
			_dissolveTimer -= disAmountPerFrame;
			renderer.material.SetFloat(fade, _dissolveTimer);
		}
	}
}
