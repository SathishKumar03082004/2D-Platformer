using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartScene(string name){
        SceneManager.LoadScene(name);
    }

    public void Exit(){
        Debug.Log("Application is Quiting........");
        Application.Quit();
    }
}
