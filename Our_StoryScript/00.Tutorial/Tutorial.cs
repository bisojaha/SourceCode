using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;
    void Awake()
    {
        instance = this;
    }

    public Transform target;
    public GameObject controller;
    public GameObject x_Button;
    public GameObject cooluk;
    public GameObject tutorial;
    public GameObject ticket;

    void Update()
    {
        this.transform.position = target.transform.position;
        this.transform.forward = target.transform.forward;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void GuideButton()
    {
        controller.SetActive(true);
        x_Button.SetActive(true);
    }
    public void ProducerButton()
    {
        cooluk.SetActive(true);
    }
    public void TicketButton()
    {
        ticket.SetActive(false);
        tutorial.SetActive(true);
    }
    public void X_Button()
    {
        controller.SetActive(false);
        cooluk.SetActive(false);
        x_Button.SetActive(false);
    }
}
