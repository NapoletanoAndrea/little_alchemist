using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {
    [SerializeField] private Image fadeImage;
    [SerializeField] private Text fadeText;
    [SerializeField] private bool fadeOnAwake;
    [SerializeField] private float startFadeSeconds;
    [SerializeField] private float fadeSeconds;
    [SerializeField] private float waitSeconds;

    private void Awake() {
        if (fadeOnAwake) {
            Invoke("FadeOut", startFadeSeconds);
        }
    }

    public void FadeIn() {
        StartCoroutine(FadeTo(fadeImage, 1, fadeSeconds));
        StartCoroutine(FadeTo(fadeText, 1, fadeSeconds));
    }

    public void FadeOut() {
        StartCoroutine(FadeTo(fadeImage, 0, fadeSeconds));
        StartCoroutine(FadeTo(fadeText, 0, fadeSeconds));
    }

    private IEnumerator FadeTo(Image image, float targetAlpha, float seconds)
    {
        if (!fadeImage) {
            yield break;
        }

        yield return new WaitForSeconds(waitSeconds);
        
        image.gameObject.SetActive(true);
        Color startColor = image.color;
        Color color = startColor;

        float count = 0;
        float t = 0;
        
        while (count <= seconds)
        {
            count += Time.deltaTime;
            t += Time.deltaTime / seconds;
            color.a = Mathf.Lerp(startColor.a, targetAlpha, t);
            image.color = color;
            yield return null;
        } 
    }
    
    private IEnumerator FadeTo(Text text, float targetAlpha, float seconds)
    {
        if (!fadeText) {
            yield break;
        }
        
        yield return new WaitForSeconds(waitSeconds);
        
        text.gameObject.SetActive(true);
        Color startColor = text.color;
        Color color = startColor;

        float count = 0;
        float t = 0;
        
        while (count <= seconds)
        {
            count += Time.deltaTime;
            t += Time.deltaTime / seconds;
            color.a = Mathf.Lerp(startColor.a, targetAlpha, t);
            text.color = color;
            yield return null;
        } 
    }
}
