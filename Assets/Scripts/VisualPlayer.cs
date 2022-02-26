using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class VisualPlayer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    private Player _player;
    private float _targetValue;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _targetValue = _player.HP;
    }

    private void OnEnable()
    {
        _player.SetedHP += OnSetedHP;
    }

    private void OnDisable()
    {
        _player.SetedHP -= OnSetedHP;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
    }

    private void OnSetedHP(float hp)
    {
        _targetValue = hp;
    }
}
