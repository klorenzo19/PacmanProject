using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    
    public void LoadLevel1(string GameScene) { 
        SceneManager.LoadScene("GameScene"); 
    }

    public void LoadLevel2(string DesignIterationScene) { 
        SceneManager.LoadScene("DesignIterationScene"); 
    }
}
