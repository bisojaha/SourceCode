using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    int index;
    int score;

    List<string> quizList = new List<string>();
    List<string> descriptionList = new List<string>();
    List<bool> answerList = new List<bool>();
    List<Dictionary<string, object>> quizData;

    public TextMeshProUGUI display_TMP;
    public TextMeshProUGUI quizPopup_TMP;
    public TextMeshProUGUI quizPopupNumber_TMP;
    public TextMeshProUGUI DisplayQuizNumber_TMP;
    public TextMeshProUGUI CertificateScore_TMP;
    public TextMeshProUGUI Certificate_TMP;
    public Image display_Image;

    private void Awake()
    {
        quizData = CSVReader.Read("QuizData");
        for (int i = 0; i < quizData.Count; i++)
        {
            quizList.Add(quizData[i]["Quiz"].ToString());
            descriptionList.Add(quizData[i]["Description"].ToString());
            if (quizData[i]["Answer"].ToString() == "0")
            {
                answerList.Add(false);
            }
            else answerList.Add(true);
        }
    }

    private void Start()
    {
        index = 0;
        quizPopup_TMP.text = display_TMP.text = ("퀴즈를 <br>시작 해 주세요");
        DisplayQuizNumber_TMP.text = " ";
    }

    public void OnStartQuiz()
    {
        quizPopup_TMP.text = display_TMP.text = quizList[index];

        // 진행상황 시작
        DisplayQuizNumber_TMP.text = ("<color=#C54646>" + (index + 1)
        + "</color><color=#CFAA2E> / </color><color=#87DE53>" + quizList.Count + "</color>");
        quizPopupNumber_TMP.text = DisplayQuizNumber_TMP.text;
    }

    public void OnChioce()
    {
        if (answerList[index] == EventManager.instance.chioce)
        {
            display_Image.color = Color.blue;
            display_TMP.text = ("정답입니다.");
            EventManager.instance.chioceAnswer = true;
            score += 10;
        }
        else
        {
            display_Image.color = Color.red;
            display_TMP.text = ("오우. 틀렸습니다");
            EventManager.instance.chioceAnswer = false;
        }
        EventManager.instance.QuizAnswer();
    }

    public void OnQuizAnswer()
    {
        quizPopup_TMP.text = descriptionList[index];
    }

    public void OnNextQuiz_Quiz()
    {
        display_Image.color = Color.white;

        if (quizList.Count - 1 > index)
        {
            Debug.Log("quizList.Length > index");
            index++;
            display_TMP.text = quizList[index];

            // 진행상황 1 / 10
            DisplayQuizNumber_TMP.text =
            ("<color=#C54646>" + (index + 1)
            + "</color><color=#CFAA2E> / </color><color=#87DE53>"
            + quizList.Count + "</color>");
        }
        else
        {
            Debug.Log("quizList.Length <= index");
            EventManager.instance.EndQuiz();
        }
        quizPopup_TMP.text = display_TMP.text;
        quizPopupNumber_TMP.text = DisplayQuizNumber_TMP.text;

    }

    public void OnEndtQuiz_Quiz()
    {
        quizPopup_TMP.text = display_TMP.text = ("Sorry. The quiz has ended.");
        CertificateScore_TMP.text = quizPopupNumber_TMP.text = DisplayQuizNumber_TMP.text = ("결과 : " + score + ("점"));
        Certificate_TMP.text = "축하드립니다 !!! <br> 수고 하셨습니다 !!!";
    }

}
