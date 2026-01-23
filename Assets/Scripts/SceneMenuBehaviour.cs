using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuBehaviour : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
