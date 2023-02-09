using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
