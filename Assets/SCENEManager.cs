using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SCENEManager : MonoBehaviour
{
    //static bool restarting = false;
    public static void ChangeScene(int id)
    {
        changeScene__(null, id);
    }

    public static void ChangeScene(string name)
    {
        changeScene__(name, -1);
    }

    public static void Restart()
    {
        //if (!restarting)
        //for (int i = 0; i < 3; i++) // HACK: Make sure it does
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            //restarting = true;
        }
    }

    public static void ExitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    static bool verifyScene__(string name)
    {
        if (name == null) return true;

        for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            //Debug.Log(SceneUtility.GetScenePathByBuildIndex(i));
            if (SceneUtility.GetScenePathByBuildIndex(i) == "Assets/" + name + ".unity")
            {
                return true;
            }
        }
        return false;
    }

    static void changeScene__(string name, int id)
    {
        if (id == -1 && name == null)
        {
            Debug.LogError($"scene arg is missing. please supply them");
            Debug.Break();
        }

        if (!verifyScene__(name))
        {
            Debug.LogError($"scene is not found.");
            Debug.Break();
        }
        else
        {
            if (id != -1)
            {
                SceneManager.LoadScene(id, LoadSceneMode.Single);
            }
            else if (name != null)
            {
                SceneManager.LoadScene(name, LoadSceneMode.Single);
            }
            else
            {
                Debug.LogError($"arg parse err: choose EITHER id or name");
                Debug.Break();
            }
        }
    }
}
