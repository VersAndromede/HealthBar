using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(HealthBar), typeof(Slider))]
public class HealthBarView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private float _durationChange;

    private HealthBar _healthBar;
    private Slider _slider;

    private void Awake()
    {
        _healthBar = GetComponent<HealthBar>();
        _slider = GetComponent<Slider>();
        _textHealth.text = $"{_healthBar.Health} / {_healthBar.MaxHealth}";
    }

    private void OnEnable()
    {
        _healthBar.Changed += DisplayHealthChanges;
    }

    private void OnDisable()
    {
        _healthBar.Changed -= DisplayHealthChanges;
    }

    private void DisplayHealthChanges()
    {
        float HealthInUnitRange = _healthBar.Health / _healthBar.MaxHealth;
        _slider.DOValue(HealthInUnitRange, _durationChange).SetEase(Ease.OutExpo);
        _textHealth.text = $"{_healthBar.Health} / {_healthBar.MaxHealth}";
    }
}
