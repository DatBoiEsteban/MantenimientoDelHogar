using UnityEngine;
using UnityEngine.SceneManagement;
//using static BDConnection;
using NetModels;

public class levelC : MonoBehaviour
{
    // Start is called before the first frame update
    private int levelToLoad;
    public Animator animator;
    
    
    // Update is called once per frame
 //función para agarrar los datos de los dos textbox y llamar a la conexión 
    //BDConnection.Instance
    public void FadeToLevel (int index){
        levelToLoad = index;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
