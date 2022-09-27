using UnityEngine;

namespace Managers {
	public class SoundManager : MonoBehaviour
	{
		public static SoundManager sm;
		public AudioSource sceneMusic;

		private void Start() {
			sm = this;
			sceneMusic.Play();
		}

		[Header("Enemy Weapon Sounds")] 
		public AudioSource machineGun1;

		[Header("Damage Sounds")] 
		public AudioSource burning1;

		[Header("Death Sounds")]
		public AudioSource[] humanDying;
		public AudioSource[] cubeLoseHealthChunk;
		public AudioSource[] explosionSounds;
		[Header("Projectile Sounds")]
		public AudioSource mineSlayerMine;

		[Header("UI Sounds")] 
		public AudioSource resourcePickup;
		public AudioSource pauseMenu;
		public AudioSource buttonPress;
		public AudioSource levelUp;
		public AudioSource powerDown;
		public AudioSource buttonHover1;
	}
}
