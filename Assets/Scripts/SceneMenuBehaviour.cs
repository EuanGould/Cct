using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuBehaviour : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
