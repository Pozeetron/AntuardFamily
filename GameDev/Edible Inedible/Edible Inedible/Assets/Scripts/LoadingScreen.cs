using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;

    public Image loading;

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
            loading.rectTransform.position =
                new Vector3(Mathf.Clamp(loading.rectTransform.position.x + operation.progress * 10f * Time.deltaTime, -1800, 0), -100, 0);

            if (operation.progress >= .9f && !operation.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                operation.allowSceneActivation = true;
            }
            
            yield return null;
        }
    }
}
