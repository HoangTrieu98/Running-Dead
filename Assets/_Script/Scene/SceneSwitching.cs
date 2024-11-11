using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SceneSwitching : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject loadingBar;
    [SerializeField] private float timeLoading;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private Button okButton;
    


    private void Start()
    {
        
        startButton.gameObject.SetActive(true);
        loadingBar.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(true);
        tutorialPanel.SetActive(false);
    }

      
    public void StartButton()
    {
        startButton.gameObject.SetActive(false);
        loadingBar.gameObject.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(timeLoading);
        SceneManager.LoadScene("GamePlay");
    }

    public void TutorialButton()
    {
        startButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void OKButton()
    {
        tutorialPanel.SetActive(false);
        startButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);
    }
}
