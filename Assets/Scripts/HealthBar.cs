using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private Player _player;
    private float _targetValue;
    private Coroutine _nowCoroutine;

    public float TargetValue
    {
        get => _targetValue;
        set
        {
            _targetValue = value;
            if (_nowCoroutine != null)
                StopCoroutine(_nowCoroutine);
            _nowCoroutine = StartCoroutine(SettingValue());
        }
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
        TargetValue = _player.HP;
    }

    private void OnEnable() => _player.SetedHP += OnSetedHP;
  
    private void OnDisable() => _player.SetedHP -= OnSetedHP;

    private void OnSetedHP(float hp) => TargetValue = hp;       
    
    private IEnumerator SettingValue()
    {
        while (_targetValue != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
