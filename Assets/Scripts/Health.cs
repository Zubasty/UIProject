using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _hp;

    public float HP
    {
        get => _hp;
        private set => _hp = Mathf.Clamp(value, 0, 100);
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
