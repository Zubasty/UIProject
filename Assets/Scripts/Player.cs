using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public event Action<float> ChangedHealth;

    public float Health
    {
        get => _health;
        private set
        {
            _health = Mathf.Clamp(value, 0, 100);
            ChangedHealth?.Invoke(_health);
        }
    }

    public void TakeDamage(float count)
    {
        if (count <= 0)
        {
            Debug.LogError("Damage не может быть отрицательным");
        }
        Health -= count;
    }

    public void Heal(float count)
    {
        if(count <= 0)
        {
            Debug.LogError("Heal не может быть отрицательным");
        }
        Health += count;
    }
}
