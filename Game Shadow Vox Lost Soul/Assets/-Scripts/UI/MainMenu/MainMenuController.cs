using GameShadow;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public void StartGame(string SceneName)
    {
        SceneTransitionManager.Source.TransitionToScene(SceneName);
    }
    
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
