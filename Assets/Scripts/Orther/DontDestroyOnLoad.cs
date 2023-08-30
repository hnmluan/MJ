using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //DontDestroyOnLoad(gameObject);
        }
    }

}


