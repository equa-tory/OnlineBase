using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    public static PhotonManager Instance;


    [Header("Variables")]
    public bool loading = true;
    public bool onlineMode = false;
    
    [Header("References")]
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private FloatingText floatingText;
    [SerializeField] private ServerItem roomListPrefab;
    [SerializeField] private Transform roomListContent;
    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject startButton;
    [SerializeField] private TMP_InputField nicknameText;


    //-------------------------------------------------------------------------------------------------------------------

    private void Awake() {
        Instance = this;
        loadingPanel.SetActive(true);
    }

    private void Start() {

        //Nickname
        if(PlayerPrefs.HasKey("nickname"))
        {
            string nickname = PlayerPrefs.GetString("nickname");
            PhotonNetwork.NickName = nickname;
        } 
        else
        {
            string nickname = "Player#" + Random.Range(1000,9999);
            PlayerPrefs.SetString("nickname", nickname);
            PhotonNetwork.NickName = nickname;
        }
        
        nicknameText.text = PhotonNetwork.NickName;

        PhotonNetwork.ConnectUsingSettings();
    }

    //-------------------------------------------------------------------------------------------------------------------

    public override void OnConnectedToMaster()
    {
        Debug.Log("<color=cyan>Connected to Master</color>");
     
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("<color=cyan>Joined Lobby</color>");
     
        loading = false;
        onlineMode = true;
        loadingPanel.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("<color=cyan>Joined Room</color>");

        loadingPanel.SetActive(false);
        createButton.SetActive(false);
        startButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("<color=cyan>Failed to Join Room</color>");

        Instantiate(floatingText,new Vector2(-11,-7),Quaternion.identity).Init(message,Color.red);
        loadingPanel.SetActive(false);
        createButton.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("<color=cyan>Left Room</color>");

        loadingPanel.SetActive(false);
        createButton.SetActive(true);
        startButton.SetActive(false);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform t in roomListContent) Destroy(t.gameObject);

        for(int i=0;i<roomList.Count;i++)
        {
            if(roomList[i].RemovedFromList) continue;
            
            Instantiate(roomListPrefab, roomListContent).Init(roomList[i]);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startButton.SetActive(PhotonNetwork.IsMasterClient);

        // foreach(PlayerController p in FindObjectsOfType<PlayerController>())
        // {
        //     if(p.PV.Owner.IsMasterClient){
        //         p.masterCursor.SetActive(true);
        //         break;
        //     }

        // }
    }


    //-------------------------------------------------------------------------------------------------------------------

    public void CreateRoom()
    {
        Debug.Log( "<color=cyan>Room " + PhotonNetwork.NickName + " created</color>" );

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(PhotonNetwork.NickName, roomOptions);
        loadingPanel.SetActive(true);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        loadingPanel.SetActive(true);

    }

    public void JoinRoom(RoomInfo info)
    {
        Debug.Log( "<color=cyan>Joining " + info.Name + "</color>" );

        PhotonNetwork.JoinRoom(info.Name);
        loadingPanel.SetActive(true);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void UpdateNickname(string _text)
    {
        PhotonNetwork.NickName = _text;
        PlayerPrefs.SetString("nickname",_text);
        foreach(PlayerController p in FindObjectsOfType<PlayerController>())
        {
            if(p.PV.IsMine){
                p.nicknameText.text = _text;
                break;
            }
        }
    }
}
