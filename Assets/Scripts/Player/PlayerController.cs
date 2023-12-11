using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    
    [Header("Variables")]
    [SerializeField] private float speed;
    private bool facingRight;

    [Header("References")]
    public InputManager input;
    private Rigidbody2D rb;

    [Header("Photon")]
    [SerializeField] private PhotonManager photonManager;
    [SerializeField] private List<GameObject> onlineDestroy;
    public GameObject masterCursor;
    public PhotonView PV;
    public TMP_Text nicknameText;


    //-------------------------------------------------------------------------------------------------------------------

    private void Awake() {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start() {

        if(PhotonManager.Instance) photonManager = PhotonManager.Instance;

        if(photonManager && photonManager.loading) nicknameText.text = PlayerPrefs.GetString("nickname");
        else if(PV) nicknameText.text = PV.Owner.NickName;
        

        if(photonManager && !photonManager.loading) masterCursor.SetActive(PV.Owner.IsMasterClient);

        if(PV && !PV.IsMine){
            Destroy(rb);
            foreach(GameObject g in onlineDestroy) Destroy(g);
        }

    }

    private void Update() {

    }

    private void FixedUpdate() {
        if(photonManager && photonManager.loading) return;
        if(!PV.IsMine) return;
        Movement();
    }

    //-------------------------------------------------------------------------------------------------------------------

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
    }

    public override void OnJoinedRoom()
    {
        Destroy(transform.parent.gameObject);
        RoomManager.Instance.CreatePlayerManager();
    }

    //-------------------------------------------------------------------------------------------------------------------


    private void Movement() {
        rb.MovePosition(rb.position + input.movementInput * speed * Time.fixedDeltaTime);

        if(!facingRight && input.movementInput.x < 0 || facingRight && input.movementInput.x > 0) Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
