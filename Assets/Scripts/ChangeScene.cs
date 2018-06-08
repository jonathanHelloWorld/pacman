using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Control;

public class ChangeScene : MonoBehaviour {

    public void ChangeSecene(int level)
    {
        if (level != SceneManager.sceneCount)
        {
            ControlPadCats.Instance.OnWin += NextLevel;
        }

        ControlPadCats.Instance.level = level;
        SceneManager.LoadScene(level);       
    }
	
   public void NextLevel(int levelAtual)
    {
        SceneManager.LoadScene(levelAtual + 1);
    }

}
