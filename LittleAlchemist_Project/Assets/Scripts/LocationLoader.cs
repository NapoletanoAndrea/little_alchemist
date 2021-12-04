using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationLoader : MonoBehaviour
{
    public void RestartApplication() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitFromApplication() {
        Application.Quit();
    }
}
