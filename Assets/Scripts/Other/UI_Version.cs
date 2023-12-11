using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Version : MonoBehaviour
{

    private TMP_Text versionText;

    private void Awake()
    {
        versionText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        versionText.text = "v" + Application.version;
    }
}
