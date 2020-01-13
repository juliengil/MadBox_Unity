using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method allowing to change scenes based on their id
    public void changeScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}
