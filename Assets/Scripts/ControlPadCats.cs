using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Control
{
    public class ControlPadCats : Singleton<ControlPadCats>
    {
        public int contador;
        public bool EatGhost = false;
        public int level;
        public int level1, level2;
        public delegate void SimpleEvent(int i);
        public event SimpleEvent OnWin, GameOver;

     
        protected override void OnAwake()
        {
            level1 = 336;
            level2 = 290;
            contador = 1;
        }

        public void ToCall(int levelAtual)
        {
            if(OnWin != null)
            {
                level = levelAtual + 1;
                OnWin(levelAtual);
            }
           
        }

    }
}
