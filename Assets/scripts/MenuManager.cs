using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private int i;
    public GameObject text;
    public void LoadScene(){

        i = SceneManager.GetActiveScene().buildIndex;
        if(i == 0){
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
        }
        else{
            SceneManager.LoadScene(0);
            SceneManager.UnloadSceneAsync(1);
        }
    }
    public void Exit(){
        Application.Quit();
    }
    public void Settings(){
        text.SetActive(true);
    }
}
