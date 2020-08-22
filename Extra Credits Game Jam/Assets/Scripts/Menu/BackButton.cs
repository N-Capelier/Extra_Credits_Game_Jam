using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnGoBack(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnGoBackAsync(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
