using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour {
    
    public static PlayerMovement Instance;
    
    public Rigidbody2D playerRb2D;
    public Vector2 moveInput;
    private bool _isMoving;
    [SerializeField, Range(1f, 20f)] private float moveSpeed = 5f;

    private void Start() {
        Instance = this;
    }
    private void FixedUpdate() {
        playerRb2D.velocity = moveInput * moveSpeed;
    }
    
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }
    
    
}
