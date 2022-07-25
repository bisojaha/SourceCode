using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public GameObject theater;
    public GameObject player;
    public Transform start;

void Start() 
{
player.transform.position = start.position;
}
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            theater.SetActive(false);
            gameObject.SetActive(false);
        }   
    }

}
