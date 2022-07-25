using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketRota : MonoBehaviour
{
    public Transform target;
    float rotaSpeed;
    void Start()
    {
        rotaSpeed = 500;
    }
    void Update()
    {
        if (rotaSpeed > 15) StartCoroutine("Rota");
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.forward = target.forward;
        }
    }
    IEnumerator Rota()
    {
        this.transform.Rotate(Vector3.up * rotaSpeed * Time.deltaTime);
        yield return new WaitForSeconds(3);
        rotaSpeed -= 1.0f;
    }
}
