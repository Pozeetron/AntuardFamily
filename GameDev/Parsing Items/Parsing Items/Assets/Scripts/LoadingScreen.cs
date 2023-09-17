using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject loadingObject;
    public float rotationSpeed = 4f;

    private void Update()
    {
        if(loadingScreen.activeSelf)
            loadingObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public void LoadScene(int id)
    {
        loadingScreen.SetActive(true);
        
        StartCoroutine(LoadAsync(id));
    }

    private IEnumerator LoadAsync(int id)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(id);

        while (!operation.isDone)
        {

            if (operation.progress >= .9f && !operation.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                operation.allowSceneActivation = true;
            }
            
            yield return null;
        }
    }
}
