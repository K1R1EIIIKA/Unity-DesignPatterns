using System;
using EventBusLogic;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerStats
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        [SerializeField] private float _speed;
        
        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
        public float Speed => _speed;
        
        public PlayerStats(int maxHealth, int currentHealth, float speed)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth;
            _speed = speed;
        }
        
        public int TakeDamage(int damage)
        {
            if (_currentHealth - damage <= 0)
                _currentHealth = 0;
            else
                _currentHealth -= damage;
            
            EventBus.Instance.TriggerEvent(GameEvent.OnHealthChanged);
            
            if (_currentHealth == 0)
                EventBus.Instance.TriggerEvent(GameEvent.OnPlayerDied);
            
            return _currentHealth;
        }
        
        public int Heal(int heal)
        {
            if (_currentHealth + heal >= _maxHealth)
                _currentHealth = _maxHealth;
            else
                _currentHealth += heal;
            
            EventBus.Instance.TriggerEvent(GameEvent.OnHealthChanged);
            
            return _currentHealth;
        }
    }
}