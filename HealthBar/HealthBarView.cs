using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(PlayerHealth), typeof(Slider))]
public class HealthBarView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private float _durationChange;

    private PlayerHealth _playerHealth;
    private Slider _slider;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _slider = GetComponent<Slider>();
        _textHealth.text = $"{_playerHealth.Health} / {_playerHealth.MaxHealth}";
    }

    private void OnEnable()
    {
        _playerHealth.Changed += DisplayHealthChanges;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= DisplayHealthChanges;
    }

    private void DisplayHealthChanges()
    {
        float HealthInUnitRange = _playerHealth.Health / _playerHealth.MaxHealth;
        _slider.DOValue(HealthInUnitRange, _durationChange).SetEase(Ease.OutExpo);
        _textHealth.text = $"{_playerHealth.Health} / {_playerHealth.MaxHealth}";
    }
}
