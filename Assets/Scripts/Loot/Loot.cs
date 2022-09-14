using Interfaces;
using UnityEngine;

public class Loot : MonoBehaviour, ILootThings {

	public PlayerResources playerResources;
	public Transform playerPosition;
	private Rigidbody2D resourceRb2D;
	public string type;
	public int value;

	
	private void Start() {
		resourceRb2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		playerPosition = GameObject.FindWithTag("Player").transform;
	}

	public void AbsorbResources(float moveSpeed) {
		float distance = Vector3.Distance(playerPosition.position, transform.position);
		if (distance <= playerResources.collectionRange) {
			Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
			resourceRb2D.MovePosition(temp);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		SoundManager.sm.resourcePickup.Play();
		if (other.CompareTag("Loot") && type == "BioGoo") {
			playerResources.bioGoo += value;
			gameObject.SetActive(false);
		} else if (other.CompareTag("Loot") && type == "Metal") {
			playerResources.metal += value;
			gameObject.SetActive(false);
		} else if (other.CompareTag("Loot") && type == "Silicate") {
			playerResources.silicate += value;
			gameObject.SetActive(false);
		}
	}
}
