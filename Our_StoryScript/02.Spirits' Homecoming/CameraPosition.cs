using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
public Transform player;

    void Update()
    {
        this.transform.position = player.transform.position;
    }
}
