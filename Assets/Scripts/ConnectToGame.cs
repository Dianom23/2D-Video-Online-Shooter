using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ConnectToGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _joinInput;
    [SerializeField] private TMP_InputField _createInput;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInput.text);
    }

    public void CreateRoom()
    {
        if(_createInput.text.Length > 0)
            PhotonNetwork.CreateRoom(_createInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
