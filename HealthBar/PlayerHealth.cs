using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public event UnityAction Changed;

    public float Health { get; private set; }

    private void Start()
    {
        Health = MaxHealth;
        Changed?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        Health -= damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Changed?.Invoke();
    }

    public void Heal(float health)
    {
        Health += health;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Changed?.Invoke();
    }
}