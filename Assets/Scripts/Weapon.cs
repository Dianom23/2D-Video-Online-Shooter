using Photon.Pun;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;
    private PhotonView _view;

    void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (_view.IsMine == false)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _view.RPC("Fire", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Fire()
    {
        Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
    }

}
