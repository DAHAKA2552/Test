using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Start"); //смена сцены(новая игра)
    }
}
