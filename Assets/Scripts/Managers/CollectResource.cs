using UnityEngine;

namespace Managers {
    public class CollectResource : MonoBehaviour {

        public int value = 2;
        public string type;
        public PlayerResources playerResources;
        public Rigidbody2D resourceRb2D;
        private GameObject _resource;
        private Transform _playerPosition;
        public float moveSpeed = 5;
        private float _distance;
        void Awake() {
            _resource = GameObject.FindWithTag("Collector");
            _playerPosition = GameObject.FindWithTag("Player").transform;
        }
        private void FixedUpdate() {
            _playerPosition = GameObject.FindWithTag("Player").transform;
            _resource = GameObject.FindWithTag("Collector");
            AbsorbResources();
        }
        void AbsorbResources() {
            _distance = Vector3.Distance(_resource.transform.position, _playerPosition.position);
            if (_distance <= playerResources.collectionRange) {
                Vector3 temp = Vector3.MoveTowards(_resource.transform.position, _playerPosition.position, moveSpeed * Time.deltaTime);
                resourceRb2D = _resource.GetComponent<Rigidbody2D>();
                resourceRb2D.MovePosition(temp);
            }
        }
        void OnTriggerEnter2D(Collider2D other) {
            SoundManager.sm.resourcePickup.Play();
            if (other.CompareTag("Collector") && type == "BioGoo") {
                playerResources.bioGoo += value;
                gameObject.SetActive(false);
            } else if (other.CompareTag("Collector") && type == "Metal") {
                playerResources.metal += value;
                gameObject.SetActive(false);
            } else if (other.CompareTag("Collector") && type == "Silicate") {
                playerResources.silicate += value;
                gameObject.SetActive(false);
            }
        }

    }
}
