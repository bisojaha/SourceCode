using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    // -------- Singleton --------------
    public static EventManager instance;
    void Awake()
    {
        instance = this;
    }
    // ---------------------------------

    [HideInInspector]
    public bool chioce, chioceAnswer;

    public GameObject startButton;
    public GameObject popup;
    public GameObject scorePopup;
    public GameObject Player;
    GameObject answerNext;
    GameObject popupClose;

    public UnityEvent OnStartQuiz;
    public UnityEvent OnChioce;
    public UnityEvent OnQuizAnswer;
    public UnityEvent OnNextQuiz;
    public UnityEvent OnEndQuiz;

    private void Start()
    {
        Transform image_BG = popup.transform.Find("Image_BG");
        answerNext = image_BG.transform.Find("Button_AnswerClose").gameObject;
        popupClose = image_BG.transform.Find("Button_PopupClose").gameObject;
    }

    //--------- Event ----------------
    public void StartQuiz()
    {
        OnStartQuiz.Invoke();
        startButton.SetActive(false);
    }
    public void Chioce()
    {
        OnChioce.Invoke();
    }
    public void QuizAnswer()
    {
        AnswerPopup();
        OnQuizAnswer.Invoke();
        //Player.GetComponent<PlayerMove>().OnQuizAnswer_Move();
    }
    public void EndQuiz()
    {
        OnEndQuiz.Invoke();
        CertificatePopup();
    }

    //--------- Button----------------
    public void QuizPopup()
    {
        popup.SetActive(true);
        popupClose.SetActive(true);
    }
    public void QuizPopupClose()
    {
        popup.SetActive(false);
        popupClose.SetActive(false);
    }

    public void AnswerPopup()
    {
        if (popupClose.activeSelf == true) QuizPopupClose();
        popup.SetActive(true);
        answerNext.SetActive(true);
    }
    public void AnswerPopupClose()
    {
        popup.SetActive(false);
        answerNext.SetActive(false);

        OnNextQuiz.Invoke();
        //Player.GetComponent<PlayerMove>().OnNextQuiz_Move();
    }
    public void CertificatePopup()
    {
        scorePopup.SetActive(true);
    }
    public void CertificatePopupClose()
    {
        scorePopup.SetActive(false);
        //Player.GetComponent<PlayerMove>().OnNextQuiz_Move();
    }
}
