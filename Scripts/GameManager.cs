using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool ismacguffinGet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && ismacguffinGet == true)
        {
            Debug.Log("You Win!!!");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Credit()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Credits");
    }

    public void Instruction()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Instruction");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

   
}
