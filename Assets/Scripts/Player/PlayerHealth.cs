using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour, IHaveHealth
{
    [SerializeField]
    private int _maxHealth = 10;
    [SerializeField]
    private TextMeshProUGUI _healthDisplay = default;
    [SerializeField]
    private GameObject _gameOverCanvasGroup = default;

    private int _currentHealth;
    private PlayerAnimation _playerAnimation;
    private bool _isDead = false;

    void Start()
    {
        _playerAnimation = gameObject.GetComponent<PlayerAnimation>();
        _currentHealth = _maxHealth;
        _healthDisplay.SetText($"HP: {_currentHealth}");
    }

    public void TakeDamage(int damageTaken)
    {
        SoundManager.PlaySound("damage");
        _playerAnimation.SetDamageTrigger();
        _currentHealth -= damageTaken;
        _healthDisplay.SetText($"HP: {_currentHealth}");
        if (_currentHealth <= 0)
            Kill();
    }

    public void Kill()
    {
        _playerAnimation.SetDeathTrigger();
        _currentHealth = 0;
        _healthDisplay.SetText($"HP: {_currentHealth}");
        SoundManager.PlaySound("die");
        SoundManager.audioSrc.volume /= 2;
        SoundManager.audioSrc.pitch /= 2;
        _gameOverCanvasGroup.SetActive(true);
        Destroy(gameObject);
    }

    public void IncreaseHealth(int healthAmount)
    {
        _currentHealth += healthAmount;
        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
        _healthDisplay.SetText($"HP: {_currentHealth}");
    }
}
