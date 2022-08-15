using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // can be deleted later
    [SerializeField] private int _healthMax;
    private int _currentHealth;
    [SerializeField] private Rigidbody2D _testBody;

    private bool _canDamage = true;
    // end of future deletions
    void Start()
    {
        _currentHealth = _healthMax;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        int damage = collision.gameObject.GetComponent<BaseEnemy>()._damage;
        if (collision.CompareTag("Enemy") && _canDamage)
        {
            Debug.Log("This is the current health of the test object in if block: " + _currentHealth);
            _canDamage = false;
            StartCoroutine(DamageCo(damage));
        }
    }
    private IEnumerator DamageCo(int damage)
    {
        _currentHealth = _currentHealth - damage;
        yield return null;
        yield return new WaitForSeconds(5f);
        _canDamage = true;
        Debug.Log("This is the current health of the test object: " + _currentHealth);
    }
}
