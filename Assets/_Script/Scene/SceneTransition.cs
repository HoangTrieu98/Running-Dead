using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] private Animator transitionAnim;
    [SerializeField] private float timeLoad;
  

    public void SceneTransi()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(timeLoad);
        SceneManager.LoadScene("DeathScreen");
    }
}
