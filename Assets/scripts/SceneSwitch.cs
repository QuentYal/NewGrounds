using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("ResetGame");
     }
}
