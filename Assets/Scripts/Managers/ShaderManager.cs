using UnityEngine;

namespace Managers {
	public class ShaderManager : MonoBehaviour {
		public static ShaderManager shm;
		private void Start() {
			shm = this;
		}

		public Material dissolve;
		public Material spriteLit;
		public Material glow;
	}
}
