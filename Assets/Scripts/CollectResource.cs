using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour {

    public int value = 2;
    public string type;
    public PlayerResources playerResources;
    public Rigidbody2D resourceRb2D;
    private Transform _resourcePosition;
    private Transform _playerPosition;
    private readonly int moveSpeed = 3;
    void Awake() {
        _resourcePosition = GameObject.FindWithTag("Item").transform;
        _playerPosition = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate() {
        AbsorbResources();
        _playerPosition = GameObject.FindWithTag("Player").transform;
        _resourcePosition = GameObject.FindWithTag("Item").transform;

    }
    void AbsorbResources() {
        float distance = Vector3.Distance(_resourcePosition.position, _playerPosition.position);
        if (distance <= playerResources.collectionRange) {
            Vector3 temp = Vector3.MoveTowards(_resourcePosition.position, _playerPosition.position, moveSpeed * Time.deltaTime);
            resourceRb2D.MovePosition(temp);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Collector") && this.type == "BioGoo") {
            playerResources.bioGoo += value;
            Destroy(this.gameObject);
        } else if (other.CompareTag("Player") && this.type == "Metal") {
            playerResources.metal += value;
            Destroy(this.gameObject);
        } else if (other.CompareTag("Player") && this.type == "Silicate") {
            playerResources.silicate += value;
            Destroy(this.gameObject);
        }
    }
}
