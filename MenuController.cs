using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string NextSceneName;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(LoadSceneAfterDelay(NextSceneName));
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName) {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }
}
