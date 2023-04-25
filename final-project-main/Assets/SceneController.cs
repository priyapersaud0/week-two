using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string nextSceneToLoad;
    public float timeLength = 10f; //seconds
    private float elapsedTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(nextSceneToLoad);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > timeLength)
            SceneManager.LoadScene(nextSceneToLoad);
    }
}
