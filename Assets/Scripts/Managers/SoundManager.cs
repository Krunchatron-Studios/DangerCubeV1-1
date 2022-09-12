using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager sm;

	private void Start() {
		sm = this;
	}

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
}
