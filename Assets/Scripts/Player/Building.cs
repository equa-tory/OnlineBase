using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Building : MonoBehaviourPunCallbacks
{
    // [Header("Variables")]
    
    
    [Header("References")]
    [SerializeField] private PlayerController pc;
    [SerializeField] private GameObject debug;
    [SerializeField] private PhotonView PV;

    
    //-------------------------------------------------------------------------------------------------------------------
    
    private void Awake() {
    
    }   
    
    private void Start() {
    
    } 

    public override void OnEnable() {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable() {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void Update() {
    
        if(!PV.IsMine) return;
        if(Input.GetKeyDown(KeyCode.Space)) photonView.RPC("RPC_Build", RpcTarget.All);

    }
    
    //-------------------------------------------------------------------------------------------------------------------
    
    [PunRPC]
    public void RPC_Build()
    {
        Instantiate(debug, transform.position, Quaternion.identity);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex >= 1)
        {
            this.enabled = false;
        }
    }
    
}
