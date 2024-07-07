using System;

namespace InventoryTest.Gameplay
{
    public class Health
    {
        private int _maxHealth;
        private int _health;
        private int _defense;

        public event Action<float> HealthChanged;
        public event Action Died;

        public int CurrentHealth
        {
            get => _health;
            set
            {
                _health = value; 
                if (_health > _maxHealth)
                {
                    _health = _maxHealth;
                }
                if (_health <= 0)
                {
                    _health = 0;
                    Died?.Invoke();
                }
                HealthChanged?.Invoke((float)_health/_maxHealth);
            }
        }

        public int MaxHealth {get => _maxHealth; }

        public int Defence
        {
            get => _defense;
            set
            {
                _defense = value;
                if (_defense < 0)
                {
                    _defense = 0;
                }
            }
        }

        public Health(int health ,int maxHealth)
        {
            _maxHealth = health;
            _health = health;
            _defense = 0;
        }

        public void GetDamage(int damage)
        {
            int totalDamage = damage - _defense;
            if (totalDamage < 0) totalDamage = 0;
            CurrentHealth -= totalDamage;
        }

        public void GetHealth(int healPoints)
        {
            CurrentHealth += healPoints;
        }
    }
}