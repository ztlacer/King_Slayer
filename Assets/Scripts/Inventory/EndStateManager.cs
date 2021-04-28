using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class EndStateManager : MonoBehaviour
{
    public GameObject endUI;
    //public TextMeshProUGUI ttext;
    public static EndStateManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void initiateEndScreen(string text)
    {
        InputManager.Controls.Player.Disable();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(endUI.transform.GetChild(1).gameObject);
        endUI.SetActive(true);
        endUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(text);
    }
}
