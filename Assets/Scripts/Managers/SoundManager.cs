using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager sm;

	private void Start() {
		sm = this;
	}

	[Header("Death Sounds")]
	public AudioSource[] humanDying;

	[Header("Weapon Sounds")] 
	public AudioSource meatSaw;
	public AudioSource deathRay;

	[Header("Projectile Sounds")]
	public AudioSource mineSlayerMine;
}
