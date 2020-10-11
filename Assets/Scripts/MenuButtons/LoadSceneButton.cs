using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoad;
    public void OnClick()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
