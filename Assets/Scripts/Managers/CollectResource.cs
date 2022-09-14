using UnityEngine;

namespace Managers {
    public class CollectResource : MonoBehaviour {

        public int value = 2;
        public string type;
        public PlayerResources playerResources;
        public Rigidbody2D resourceRb2D;
        private Transform _resourcePosition;
        private Transform _playerPosition;
        public float moveSpeed = 5;
        private float _distance;
        void Awake() {
            _resourcePosition = GameObject.FindWithTag("Loot").transform;
            _playerPosition = GameObject.FindWithTag("Player").transform;
        }
        private void FixedUpdate() {
            _playerPosition = GameObject.FindWithTag("Player").transform;
            _resourcePosition = GameObject.FindWithTag("Loot").transform;
            AbsorbResources();
        }
        void AbsorbResources() {
            Debug.Log($"absorb: {_playerPosition}");
            _distance = Vector3.Distance(_resourcePosition.position, _playerPosition.position);
            Debug.Log($"dist: {_distance}");
            if (_distance <= playerResources.collectionRange) {
                Debug.Log($"test: test");
                Vector3 temp = Vector3.MoveTowards(_resourcePosition.position, _playerPosition.position, moveSpeed * Time.deltaTime);
                resourceRb2D.MovePosition(temp);
            }
        }
        void OnTriggerEnter2D(Collider2D other) {
            SoundManager.sm.resourcePickup.Play();
            if (other.CompareTag("Player") && type == "BioGoo") {
                playerResources.bioGoo += value;
                gameObject.SetActive(false);
            } else if (other.CompareTag("Player") && type == "Metal") {
                playerResources.metal += value;
                gameObject.SetActive(false);
            } else if (other.CompareTag("Player") && type == "Silicate") {
                playerResources.silicate += value;
                gameObject.SetActive(false);
            }
        }

    }
}
