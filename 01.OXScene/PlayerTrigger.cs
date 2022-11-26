using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    bool ended;

    private void Awake()
    {
        ended = false;
    }


    public void EndQuiz_Trigger()
    {
        ended = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("STARTBUTTON"))
        {
            Debug.Log("StartQuiz");
            EventManager.instance.StartQuiz();
        }
        else if (other.CompareTag("QUIZ"))
        {
            SceneManager.LoadScene(1);
            this.GetComponent<PlayerMove>().SceneLoad();
        }
        else if (other.CompareTag("QUIT"))
        {
            SceneManager.LoadScene(0);
            this.GetComponent<PlayerMove>().SceneLoad();
        }


        if (!ended)
        {
            if (other.CompareTag("O"))
            {
                Debug.Log("O");
                EventManager.instance.chioce = true;
                EventManager.instance.Chioce();
            }
            else if (other.CompareTag("X"))
            {
                Debug.Log("X");
                EventManager.instance.chioce = false;
                EventManager.instance.Chioce();
            }
        }
    }
}
