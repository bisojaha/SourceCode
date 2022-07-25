using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    public GameObject image;
    public float objectTime = 2.0f;
    LineRenderer lr;

    void Start()
    {
        image.SetActive(false);
        lr = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        lr.SetPosition(0, ray.origin);
        if (Physics.Raycast(ray, out hitInfo))
        {
            lr.SetPosition(1, hitInfo.point);
            if (Input.GetMouseButtonDown(0) && hitInfo.collider.tag == "OBJECT")
            {
                StartCoroutine("ImageOn");
            }
        }
        else
        {
            lr.SetPosition(1, ray.origin + ray.direction * 50);
        }
    }

    IEnumerator ImageOn()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(objectTime);
        image.SetActive(false);
        image.transform.localScale = Vector3.one * 0.01f;
    }
}
