using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;

    public Image loading;
    public Sprite[] progress;

    public void LoadScene()
    {
        loadingScreen.SetActive(true);
        
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while (!operation.isDone)
        {
            loading.sprite = operation.progress == 0.25f ? progress[0] : operation.progress == 0.5f ? progress[1] : progress[2];

            if (operation.progress >= .9f && !operation.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                operation.allowSceneActivation = true;
            }
            
            yield return null;
        }
    }
}
