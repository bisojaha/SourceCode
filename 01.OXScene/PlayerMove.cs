using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform startPoint;
    public float speed;

    CharacterController cc;

    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(-h, 0, -v);
        dir.Normalize();
        cc.Move(dir * speed * Time.deltaTime);
    }

    public void OnQuizAnswer_Move()
    {
        cc.enabled = false;
        transform.position = startPoint.position;
        transform.forward = startPoint.forward;
    }
    public void OnNextQuiz_Move()
    {
        cc.enabled = true;
    }

    public void SceneLoad()
    {
        cc = GetComponent<CharacterController>();
        cc.enabled = false;
        transform.position = startPoint.position;
        cc.enabled = true;
    }
}