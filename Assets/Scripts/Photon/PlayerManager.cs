using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [Header("Variables")]
    
    
    [Header("References")]
    [SerializeField] private PhotonView PV;
    
    
    //-------------------------------------------------------------------------------------------------------------------
    
    private void Awake() {
        PV = GetComponent<PhotonView>();
    }   
    
    private void Start() {
        if(PV.IsMine) CreateController();
    } 
    
    private void Update() {
    
    }
    
    //-------------------------------------------------------------------------------------------------------------------
    
    private void CreateController()
    {
        Debug.Log("<color=cyan>Instantiated Player Controller</color>");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerObj"), Vector2.zero, Quaternion.identity);
    }

}
