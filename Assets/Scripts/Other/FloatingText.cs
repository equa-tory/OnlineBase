using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class FloatingText : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float dieSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;

    [Header("References")]
    [SerializeField] private TMP_Text text;



    private void Start() {
        Destroy(gameObject, dieSpeed);
    }

    private void Update() {
        transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
    }

    //-------------------------------------------------------------------------------------------------------------------

    public void Init(string _text, Color _color)
    {
        text.text = _text;
        text.color = _color;
    }
}
