using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenceLoaderGo : MonoBehaviour
{
    public string nextScence;
    public void LoadScence()
    {
        SceneManager.LoadScene(nextScence);
    }
}
