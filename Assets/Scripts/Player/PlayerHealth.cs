using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IHaveHealth
{
    public bool IsDead = false;

    [SerializeField]
    private int _playerHealth = 10;
    private PlayerAnimation _playerAnimation;

    void Start()
    {
        _playerAnimation = gameObject.GetComponent<PlayerAnimation>();
    }

    public void TakeDamage(int damageTaken)
    {
        _playerAnimation.SetDamageTrigger();
        _playerHealth -= damageTaken;
        if (_playerHealth <= 0)
            Kill();
    }

    public void Kill()
    {
        _playerHealth = 0;
        IsDead = true;
        StartCoroutine(PlayerDeath());
        
    }

    IEnumerator PlayerDeath()
    {
        _playerAnimation.PlayDeathAnimation();
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
