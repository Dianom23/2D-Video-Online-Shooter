using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent<string> DeathEvent = new UnityEvent<string>();

    [SerializeField] private int _maxHp;
    [SerializeField] private int _hp;

    void Start()
    {
        _hp = _maxHp;
    }

    public void TakeDamage(int damage, string userId)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            DeathEvent?.Invoke(userId);
            Destroy(gameObject);
        }
    }

    public void RestoreHp(int restoredHp)
    {
        _hp += restoredHp;

        if(_hp > _maxHp)
            _hp = _maxHp;
    }
}
