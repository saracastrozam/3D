using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfazManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void ChangeScene(int nivel)
    {
        SceneManager.LoadScene(nivel);
    }
}
