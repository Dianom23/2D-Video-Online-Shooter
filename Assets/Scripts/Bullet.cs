using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
            playerHealth.TakeDamage(_damage, PhotonNetwork.LocalPlayer.UserId);

        if (collision.tag != "Bullet")
            Destroy(gameObject);
    }
}
