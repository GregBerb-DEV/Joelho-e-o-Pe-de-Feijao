using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool IsDead;

    [SerializeField]
    private int _playerHealth = 10;
    private PlayerAnimation _playerAnimation;
    private const string ENEMY_TAG = "inimigo";
    private const string PLAYER_TAG = "Player";

    void Start()
    {
        IsDead = false;
        _playerAnimation = gameObject.GetComponent<PlayerAnimation>();
    }

    public void TakeDamage(int x)
    {
        _playerHealth -= x;
        if (_playerHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        _playerHealth = 0;
        IsDead = true;

        if (gameObject.tag == PLAYER_TAG)
        {
            StartCoroutine(PlayerDeath());
        }
    }
    IEnumerator PlayerDeath()
    {
        if (gameObject.tag == ENEMY_TAG)
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
