using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
   public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
