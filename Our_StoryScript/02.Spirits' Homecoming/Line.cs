using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int lr_01_maxPoint;
    public int lr_02_maxPoint;
    public Transform[] wayPoint_01;
    public Transform[] wayPoint_02;
    LineRenderer lr;

    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (this.gameObject.name == "LineRender_01")
        {
            lr.positionCount = lr_01_maxPoint;
            for (int i = 0; i < lr_01_maxPoint; i++)
            {
                Vector3 pos = wayPoint_01[i].position;
                lr.SetPosition(i, pos);
            }
        }
        else
        {
            lr.positionCount = lr_02_maxPoint;
            for (int i = 0; i < lr_02_maxPoint; i++)
            {
                Vector3 pos = wayPoint_02[i].position;
                lr.SetPosition(i, pos);
            }
        }
    }
}
