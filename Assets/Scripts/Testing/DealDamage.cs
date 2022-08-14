using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int _healthMax;
    private int _currentHealth;
    [SerializeField] private Rigidbody2D _testBody;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _healthMax;
    }

    void FixedUpdate()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int damage = collision.gameObject.GetComponent<BaseEnemy>()._damage;
        // int damage = GameObject("Test Enemy")._damage;
        Debug.Log("this is how much damage is being pased: " + damage);
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(DamageCo(damage));
        }
    }
    private IEnumerator DamageCo(int damage)
    {
        _currentHealth = _currentHealth - damage;
        yield return null;
        yield return new WaitForSeconds(1f);
        Debug.Log(_currentHealth);
    }
}
