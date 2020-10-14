using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour, IHaveHealth
{
    [SerializeField]
    private int _maxHealth = 10;
    [SerializeField]
    private int _maxLives = 5;
    [SerializeField]
    private string _gameOverSceneName = "GameOverScreen";
    [SerializeField]
    private TextMeshProUGUI _healthDisplay = default;
    [SerializeField]
    private TextMeshProUGUI _livesDisplay = default;

    private int _currentHealth;
    private int _currentLives;
    private PlayerAnimation _playerAnimation;

    void Start()
    {
        _playerAnimation = gameObject.GetComponent<PlayerAnimation>();
        _currentHealth = _maxHealth;
        _currentLives = _maxLives;
        _healthDisplay.SetText($"HP: {_currentHealth}");
        _livesDisplay.SetText($"Vidas: {_currentLives}");
    }

    public void TakeDamage(int damageTaken)
    {
        _playerAnimation.SetDamageTrigger();
        _currentHealth -= damageTaken;
        _healthDisplay.SetText($"HP: {_currentHealth}");
        if (_currentHealth <= 0)
            Kill();
    }

    public void Kill()
    {
        _currentHealth = 0;
        _currentLives--;
        StartCoroutine(PlayerDeath());
    }

    IEnumerator PlayerDeath()
    {
        _playerAnimation.SetDeathTrigger();
        yield return new WaitForSeconds(0.8f);
        if (_currentLives > 0)
        {
            Respawn();
        }
        else
        {
            GameOver();
        }
    }

    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(_gameOverSceneName);
    }
}
