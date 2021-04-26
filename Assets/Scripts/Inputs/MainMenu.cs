using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetManager networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;

    [SerializeField] private GameObject eventSystem = null;

    public void HostLobby()
    {
        networkManager.StartHost();

        landingPagePanel.SetActive(false);

        //eventSystem.GetComponent<Menu>().goToLobby();
    }

    public void StartSingle(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
