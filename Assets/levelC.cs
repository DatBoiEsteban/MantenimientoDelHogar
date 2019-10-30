using UnityEngine;
using UnityEngine.SceneManagement;

public class levelC : MonoBehaviour
{
    // Start is called before the first frame update
    private int levelToLoad;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            FadeToLevel(1);
        }
    }
    public void FadeToLevel (int index){
        levelToLoad = index;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
