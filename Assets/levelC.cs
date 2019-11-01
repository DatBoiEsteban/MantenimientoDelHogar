using UnityEngine;
using UnityEngine.SceneManagement;
using static BDConnection;

public class levelC : MonoBehaviour
{
    // Start is called before the first frame update
    //private int levelToLoad;
    public Animator animator;
    private bool isConnected;
    
    // Update is called once per frame
    void Update()
    {
        
        if (!isConnected && BDConnection.Instance.session != null) {
            isConnected = true;

            FadeToLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //función para agarrar los datos de los dos textbox y llamar a la conexión 
    //BDConnection.Instance
    public void FadeToLevel (int index){
        
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
