using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers {
    public class PlayerMovement : MonoBehaviour {
    
        public static PlayerMovement Instance;
    
        public Rigidbody2D playerRb2D;
        public Vector2 moveInput;
        [SerializeField, Range(1f, 20f)] private float moveSpeed = 5f;

        private void Start() {
            Instance = this;
        }
        private void FixedUpdate() {
            playerRb2D.velocity = moveInput * moveSpeed;
            FlipSprite();
        }
        void OnMove(InputValue value) {
            moveInput = value.Get<Vector2>();
        }
        void FlipSprite() {
            bool playerHasHorizontalSpeed = Mathf.Abs(playerRb2D.velocity.x) > Mathf.Epsilon;

            if(playerHasHorizontalSpeed) {
                transform.localScale = new Vector2(Mathf.Sign(playerRb2D.velocity.x), 1.0f);
            }
        }
    }
}
