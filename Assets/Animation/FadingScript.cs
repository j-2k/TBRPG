using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadingScript : MonoBehaviour
{
    public Animator animator;
    private int SceneLevel_Load;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy1")
        {
            FadeNextScene();
        }
        if (other.gameObject.tag == "Enemy2")
        {
            FadeNextScene();
        }
        if (other.gameObject.tag == "Enemy3")
        {
            FadeNextScene();
        }
    }
    
    public void FadeNextScene()
    {
        FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToScene (int levelIndex)
    {
        SceneLevel_Load = levelIndex;
        animator.SetTrigger("FadeOutTrigger");
    }

    public void FadeComplete ()
    {
        SceneManager.LoadScene(SceneLevel_Load);
    }
}
