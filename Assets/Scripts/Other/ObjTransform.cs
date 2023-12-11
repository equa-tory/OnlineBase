//by TheSuspect

using UnityEngine;

public class ObjTransform : MonoBehaviour
{

    public Transform target;
    public Vector3 posOffset;

    public bool useRot;
    public bool useLerp;
    public float speed;

    private void Awake() {
        enabled = false;
        Invoke("Enable",.1f);
    }

    private void Enable(){enabled=true;}

    private void Update()
    {
        if(!useLerp){
            transform.position = target.position+posOffset;
            if(useRot) transform.rotation = target.rotation;
        }
    }

    private void FixedUpdate() {
        if(useLerp){
            //transform.position = Vector3.Lerp(transform.position, target.position + posOffset, speed);
            if(useRot) transform.rotation = target.rotation;
        }

    }
    private void LateUpdate() {
        if(useLerp){
            transform.position = Vector3.Lerp(transform.position, target.position + posOffset, speed);
            //if(useRot) transform.rotation = target.rotation;
        }
    }
}
