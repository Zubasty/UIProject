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
            _hp = Mathf.Clamp(value, 0, 100);
            SetedHP?.Invoke(_hp);
        }
    }

    public void TakeDamage(float count)
    {
        if (count <= 0)
        {
            Debug.LogError("Damage не может быть отрицательным");
        }
        HP -= count;
    }

    public void Heal(float count)
    {
        if(count <= 0)
        {
            Debug.LogError("Heal не может быть отрицательным");
        }
        HP += count;
    }
}
