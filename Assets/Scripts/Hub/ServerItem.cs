using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ServerItem : MonoBehaviour
{
    [SerializeField] private TMP_Text serverNameText;
    [SerializeField] private TMP_Text playersCountText;

    RoomInfo info;

    public void Init(RoomInfo info) {
        this.info = info;
        serverNameText.text = info.Name;
        playersCountText.text = info.PlayerCount + "/" + info.MaxPlayers;
    }

    public void OnClick()
    {
        PhotonManager.Instance.JoinRoom(info);
    }
}
