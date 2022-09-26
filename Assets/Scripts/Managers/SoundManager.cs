using UnityEngine;

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
	public AudioSource explosion1;

	[Header("Death Sounds")]
	public AudioSource[] humanDying;

	[Header("Projectile Sounds")]
	public AudioSource mineSlayerMine;

	[Header("UI Sounds")] 
	public AudioSource resourcePickup;
	public AudioSource pauseMenu;
	public AudioSource buttonPress;
	public AudioSource levelUp;
	public AudioSource powerDown;
	public AudioSource healthChunkLost;
	public AudioSource buttonHover1;
	public AudioSource buttonHover2;
}
