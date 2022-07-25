using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System;

public class TodayDate : MonoBehaviour
{
    public TextMeshProUGUI today;
    void Start()
    {
        today = this.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        today.text = DateTime.Now.ToString("yyyy - MM -dd");
    }
}
