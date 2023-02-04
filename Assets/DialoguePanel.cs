using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialoguePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text text;

    public void ShowPanel(bool value)
    {
        panel.SetActive(value);
    }
    public void SetText(string value)
    {
        text.text = value;
    }
}
