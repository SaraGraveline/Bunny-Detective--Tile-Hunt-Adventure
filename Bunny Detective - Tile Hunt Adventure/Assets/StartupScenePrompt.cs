using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupScenePrompt : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // Load the main game scene
        SceneManager.LoadScene("SampleScene");
    }
}
