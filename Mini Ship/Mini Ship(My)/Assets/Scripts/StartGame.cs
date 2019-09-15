using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = true; //звук нажатия
        Invoke("Load", .5f); //заупуск с задержкой
    }

    void Load()
    {
        SceneManager.LoadScene("Game"); //переход на сцену
    }
}
