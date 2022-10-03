using System;
using UnityEngine;

namespace Managers {
	public class TitleSoundManager : MonoBehaviour {
		public static TitleSoundManager tsm;
		[Header("UI Sounds")] 
		public AudioSource titleMusic;
		public AudioSource buttonPress;
		public AudioSource buttonHover1;

		private void Start() {
			tsm = this;
		}
	}
}
