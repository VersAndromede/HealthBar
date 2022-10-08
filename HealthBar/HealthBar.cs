using UnityEngine;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public UnityAction Changed;

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

        if (Health - damage >= 0)
            Health -= damage;
        else
            Health = 0;

        Changed?.Invoke();
    }

    public void AddHealth(float health)
    {
        if (health > 0 && Health + health <= MaxHealth)
        {
            Health += health;
            Changed?.Invoke();
        }
    }
}
