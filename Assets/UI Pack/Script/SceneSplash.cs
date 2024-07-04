using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSplash : MonoBehaviour
{
    public string targetScene = "HOME";

    public float splashDuration = 2.0f;

    void Start()
    {
        StartCoroutine(LOadHomeSceneAfterDelay(splashDuration));
    }

    IEnumerator LOadHomeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(targetScene);
    }
}
