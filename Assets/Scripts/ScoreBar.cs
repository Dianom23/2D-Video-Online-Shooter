using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private GameObject _playerScorePrefab;
    private PhotonView _view;

    void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    [PunRPC]
    private void InitializeScoreBarRPC()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            GameObject newPlayerScore = PhotonNetwork.Instantiate(_playerScorePrefab.name, Vector3.zero, Quaternion.identity);
            newPlayerScore.transform.SetParent(transform);
            newPlayerScore.transform.localScale = Vector3.one;
            newPlayerScore.GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[i].NickName;
        }
    }

    public void InitializeScoreBar()
    {
        _view.RPC("InitializeScoreBarRPC", RpcTarget.All);
    }
}
