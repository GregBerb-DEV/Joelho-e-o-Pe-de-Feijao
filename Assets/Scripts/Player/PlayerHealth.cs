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

    public bool IsDead = false;

    private int _currentHealth;
    private PlayerAnimation _playerAnimation;

    void Start()
    {
        _playerAnimation = gameObject.GetComponent<PlayerAnimation>();

        _currentHealth = _maxHealth;

        //Setando o texto na UI
        _healthDisplay.SetText($"HP: {_currentHealth}");
    }

    public void TakeDamage(int damageTaken)
    {
        if (IsDead)
            return;
        SoundManager.PlaySound("damage");
        _playerAnimation.SetDamageTrigger();
        _currentHealth -= damageTaken;
        _healthDisplay.SetText($"HP: {_currentHealth}");
        if (_currentHealth <= 0)
            Kill();
    }

    public void Kill()
    {
        _currentHealth = 0;
        StartCoroutine(PlayerDeath());
        IsDead = true;
    }

    IEnumerator PlayerDeath()
    {
        _playerAnimation.SetDeathTrigger();
        yield return new WaitForSeconds(0.8f);
        _gameOverCanvasGroup.SetActive(true);
        SoundManager.PlaySound("die");
    }

    public void IncreaseHealth(int healthAmount)
    {
        _currentHealth += healthAmount;
        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
        _healthDisplay.SetText($"HP: {_currentHealth}");
    }
}
