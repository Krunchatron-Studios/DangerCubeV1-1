using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    public static PlayerMovement Instance;
    
    public Rigidbody2D playerRb2D;
    private Vector2 _moveInput;
    private bool _isMoving;
    [SerializeField, Range(1f, 20f)] private float moveSpeed = 5;

    private void Start() {
        Instance = this;
    }
    private void FixedUpdate() {
        playerRb2D.velocity = _moveInput * moveSpeed;
    }
    
    void OnMove(InputValue value) {
        _moveInput = value.Get<Vector2>();
    }
    
    
}
