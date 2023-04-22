using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupScenePrompt : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {

        SceneManager.LoadScene("SampleScene");
    }
}
