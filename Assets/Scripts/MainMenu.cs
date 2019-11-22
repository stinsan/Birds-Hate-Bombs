using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update() {

        if (Input.GetKeyDown(KeyCode.P)) {
            SceneManager.LoadScene("Main");
        } 
        else if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }

    }
}
