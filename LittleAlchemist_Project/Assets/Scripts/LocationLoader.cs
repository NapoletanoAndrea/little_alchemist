using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationLoader : MonoBehaviour
{
    public void RestartApplication() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNightScene(int waitSeconds) {
        StartCoroutine(LoadNightSceneCoroutine(waitSeconds));
    }
    
    public void LoadCraftingScene(int waitSeconds) {
        StartCoroutine(LoadCraftingSceneCoroutine(waitSeconds));
    }

    public void ExitFromApplication() {
        Application.Quit();
    }

    private IEnumerator LoadNightSceneCoroutine(int waitSeconds) {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(1);
    }
    
    private IEnumerator LoadCraftingSceneCoroutine(int waitSeconds) {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(2);
    }
}
