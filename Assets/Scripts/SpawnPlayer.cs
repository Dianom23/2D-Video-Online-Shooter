using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<GameObject> _players;
    [SerializeField] private GameObject _choiseMenu;
    [SerializeField] private TMP_InputField _inputNickname;
    
    public void ChoisePlayer(int index)
    {
        if (_inputNickname.text.Length == 0)
            return;

        PhotonNetwork.Instantiate(_players[index].name, _spawnPoints[index].transform.position, Quaternion.identity);
        PhotonNetwork.LocalPlayer.NickName = _inputNickname.text;
        Destroy(_choiseMenu);
    }
}
