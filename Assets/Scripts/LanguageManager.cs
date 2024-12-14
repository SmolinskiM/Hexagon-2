using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private Button polishButton;
    [SerializeField] private Button japanButton;
    [SerializeField] private Button englishButton;

    [SerializeField] private string textStartP;
    [SerializeField] private string textExitP;
    [SerializeField] private string textStartJ;
    [SerializeField] private string textExitJ;
    [SerializeField] private string textStartE;
    [SerializeField] private string textExitE;

    [SerializeField] private TextMeshProUGUI textStart;
    [SerializeField] private TextMeshProUGUI textExit;

    private void Awake()
    {
        polishButton.onClick.AddListener(SetLanguageP);
        japanButton.onClick.AddListener(SetLanguageJ);
        englishButton.onClick.AddListener(SetLanguageE);
    }

    private void SetLanguageE()
    {
        textStart.text = textStartE; 
        textExit.text = textExitE;
    }

    private void SetLanguageJ()
    {
        textStart.text = textStartJ;
        textExit.text = textExitJ;
    }

    private void SetLanguageP()
    {
        textStart.text = textStartP;
        textExit.text = textExitP;
    }
}
