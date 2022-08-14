using System;
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

    private void FixedUpdate() {
        playerRb2D.velocity = _moveInput * moveSpeed;
    }

    void OnMove(InputValue value) {
        _moveInput = value.Get<Vector2>();
    }
    
    
}
