using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    // Public reference to the player movement class from anywhere
    public static PlayerMovement Instance;
    
    // Reference to the player object
    public Rigidbody2D playerRb2D;
    private Vector2 _moveInput;
    private bool _isMoving;
    [SerializeField, Range(1f, 20f)] private float moveSpeed = 5;

    private void Start() {
        Instance = this;
    }
    
    // This update only runs 50 x per minute, sort of like delta time.
    private void FixedUpdate() {
        playerRb2D.velocity = _moveInput * moveSpeed;
    }
    
    // returns xy values as either 0 or 1 as a vector3
    void OnMove(InputValue value) {
        _moveInput = value.Get<Vector2>();
    }
    
    
}
