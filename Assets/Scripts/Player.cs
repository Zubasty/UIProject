using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _hp;
    public event Action<float> SetedHP;

    public float HP
    {
        get => _hp;
        private set
        {
            if (value > 100)
            {
                _hp = 100;
            }
            else if (value < 0)
            {
                _hp = 0;
            }
            else
            {
                _hp = value;
            }
            SetedHP?.Invoke(_hp);
        }
    }

    public void TakeDamage(float count)
    {
        HP -= count;
    }

    public void Heal(float count)
    {
        HP += count;
    }
}
