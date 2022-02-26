using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    private Health _player;
    private float _targetValue;

    private void Awake()
    {
        _player = GetComponent<Health>();
        _targetValue = _player.HP;
    }

    private void Update()
    {
        if(_slider.value != _player.HP)
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
    }
}
