using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    private int fps;
    public TMP_Text fpsText;
    private float deltaTime;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
    }

    public void SetMaxFPS(int targetFps) {
        fps = targetFps;
        Application.targetFrameRate = targetFps;
        PlayerPrefs.SetInt("fps", targetFps);
    }

    private void Awake() {
        fps = PlayerPrefs.GetInt("fps", 60);
        Application.targetFrameRate = fps;
    }
}
