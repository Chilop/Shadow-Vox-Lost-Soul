using System.Threading;
using GameShadow;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject G_MainMenu, G_SettingsMenu;
    public bool G_ChangeMenuAnimTrigger;
    public float G_Timer, G_distance;
    public int G_Inversor=-1;

    public void Start()
    {
        G_Inversor = -1;
    }
    public void StartGame(string SceneName)
    {
        SceneTransitionManager.Source.TransitionToScene(SceneName);
    }
    
    
    public void QuitButton()
    {
        Application.Quit();
    }

    public void settingsToogle() {
        if (!G_ChangeMenuAnimTrigger) { 
            G_ChangeMenuAnimTrigger = true;
            G_Inversor *= -1;
        }
    }
    private void FixedUpdate()
    {
        if (G_ChangeMenuAnimTrigger) {
            G_Timer += 1 * Time.fixedDeltaTime;
            G_MainMenu.transform.position += new Vector3((G_Inversor*G_distance) * Time.fixedDeltaTime, 0, 0);
            G_SettingsMenu.transform.position += new Vector3((G_Inversor*G_distance) * Time.fixedDeltaTime, 0, 0);
            if (G_Timer >= 0.5f) {
                G_Timer = 0;
                G_ChangeMenuAnimTrigger= false;
            }
        }
    }
}
