using UnityEngine;

public class levelC : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            FadeToLevel(0);
        }
    }
    public void FadeToLevel (int index){
        animator.SetTrigger("FadeOut");
    }
    
}
