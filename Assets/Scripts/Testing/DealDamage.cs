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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(DamageCo(2));
        }
    }
    private IEnumerator DamageCo(int damage)
    {
        _currentHealth = _currentHealth - damage;
        yield return null;
        yield return new WaitForSeconds(3f);
        Debug.Log(_currentHealth);
    }
}
