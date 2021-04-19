using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPlayer : MonoBehaviour
{
    private AsyncOperation sceneAsync;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLISSION");
        StartCoroutine(OnFinishedLoadingAllScene(2, other.gameObject));
    }

    void enableScene(int sceneInt, GameObject obj)
    {
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;


        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(sceneInt);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(obj, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
        }
    }

    IEnumerator OnFinishedLoadingAllScene(int sceneInt, GameObject obj)
    {
        Debug.Log("LoadBB");
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneInt);
        scene.allowSceneActivation = false;
        sceneAsync = scene;
        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        Debug.Log("Done Loading Scene");
        enableScene(sceneInt, obj);
        Debug.Log("Scene Activated!");
    }
}
