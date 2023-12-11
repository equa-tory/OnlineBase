using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelHouse : MonoBehaviour
{
    [SerializeField] private GameObject serversListPanel;


    private void OnTriggerEnter2D(Collider2D other) {
        
        serversListPanel.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D other) {
        serversListPanel.SetActive(false);
    }

}
