using Photon.Pun;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    void Start()
    {
        _weapon.enabled = false;
    }

    [PunRPC]
    public void EnableWeapon()
    {
        _weapon.enabled = true;
    }
}
