using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Fps : MonoBehaviour
{

    private TMP_Text fps_counter;
    private int fps;

    private void Awake()
    {
        fps_counter = GetComponent<TMP_Text>();
    }

    void Update()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        fps = (int)current;
        fps_counter.text = fps.ToString() + "fps";
    }
}
