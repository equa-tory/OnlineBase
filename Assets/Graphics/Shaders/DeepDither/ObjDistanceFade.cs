using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDistanceFade : MonoBehaviour
{
    public Transform target;

    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().materials[0];
    }

    void Update()
    {
        // if(GameManager.Instance.pc && !target) target = GameManager.Instance.pc.transform;
        mat.SetVector("_ObjPos", target.position);
    }
}
