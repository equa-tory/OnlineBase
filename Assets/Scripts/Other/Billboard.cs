using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target;

    private void Start() {
        // if(!target) target = GameManager.Instance.pc.cam.transform;
    }

    void Update()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,180,0));
    }
}
