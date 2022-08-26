using UnityEngine;

public class Weapon : MonoBehaviour {

	public Sprite weaponSprite;
	private AudioClip _weaponSound;
	public AudioSource audioSource;
	
	[Header("Main Weapon Vars")]
	public string weaponName;
	public string weaponDescription;
	public float weaponDamage = 1f;
	public float knockBackPower = 1f;


	private void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	
	public void enemyKnockBack(Vector3 direction, Rigidbody2D enemy) {
		enemy.AddForce(direction * knockBackPower, ForceMode2D.Impulse);
		Debug.Log("we hit them with the knockback");
		Debug.Log(direction.normalized);

	}
}
