using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEF : MonoBehaviour
{
    void Start()
    {
        this.transform.localScale = Vector3.one * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x < 0.9f)
        {
            this.transform.localScale += Vector3.one * 0.01f;
        }
    }
}
