using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public GameObject[] number;
    int index;

    void Start()
    {
        index = 0;
    }
    void Update()
    {

    }

    public void QuizAnswer_Number()
    {
        bool chioceAnswer = EventManager.instance.chioceAnswer;
        Image blue =  number[index].GetComponent<Image>();
        blue.color = Color.yellow; 
        if (chioceAnswer)
        {
            number[index].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            number[index].transform.GetChild(2).gameObject.SetActive(true);
        }
        index++;
    }
}
