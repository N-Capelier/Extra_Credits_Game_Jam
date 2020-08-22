using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenuButtons : MonoBehaviour
    {
        public void OnPressPlay()
        {
            SceneManager.LoadSceneAsync("Game");
        }

        public void OnPressSettings()
        {
            SceneManager.LoadSceneAsync("Settings Menu");
        }

        public void OnPressCredits()
        {
            SceneManager.LoadSceneAsync("Credits Menu");
        }

        public void OnPressQuit()
        {
            Application.Quit();
        }
    }
}