using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdminOptions : MonoBehaviour
{
    [SerializeField] private GameObject _adminPanel;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private ScoreBar _scoreBar;

    private List<GameObject> _playerList = new List<GameObject>();
    private PhotonView _view;

    void Start()
    {
        _view = GetComponent<PhotonView>();

        if(PhotonNetwork.LocalPlayer.IsMasterClient == false)
            _adminPanel.SetActive(false);
    }

    public void StartGame()
    {
        _view.RPC("StartGameRPC", RpcTarget.All);
        _adminPanel.SetActive(false);

        _scoreBar.InitializeScoreBar();
    }

    [PunRPC]
    private void StartGameRPC()
    {
        _playerList = GameObject.FindGameObjectsWithTag("Player").ToList();

        for (int i = 0; i < _playerList.Count; i++)
        {
            _playerList[i].GetComponent<PhotonView>().RPC("EnableWeapon", RpcTarget.All);
            _playerList[i].transform.position = _spawnPoints[i].position;
        }
    }

}
