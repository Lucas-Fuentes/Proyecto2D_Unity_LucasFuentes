using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    public void GoBack(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
