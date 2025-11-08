using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int totalItems;
    private int collectedItems;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        CountItemsInScene();
    }

    void CountItemsInScene()
    {
        totalItems = GameObject.FindObjectsOfType<CollectibleItem>().Length;
        collectedItems = 0;
    }

    public void CollectItem()
    {
        collectedItems++;
        if (collectedItems >= totalItems)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("🎉 No more levels! Game complete!");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
