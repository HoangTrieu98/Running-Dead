using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private float timeLoading;
    [SerializeField] private GameObject loadingBar;
    [SerializeField] private Button playAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        loadingBar.SetActive(false);
        playAgainButton.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState =CursorLockMode.None;
    }

    public void PlayAgain()
    {
        playAgainButton.gameObject.SetActive(false);
        loadingBar.SetActive(true);
        StartCoroutine(ReadyToPlayAgain());
    }

    IEnumerator ReadyToPlayAgain()
    {
        yield return new WaitForSeconds(timeLoading);
        SceneManager.LoadScene("GamePlay");
    }
}
