using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnType : MonoBehaviour
{
    public BTNType currentType;

    public void Quit ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void OnBtnClick(){
        {
            switch(currentType)
            {
                case BTNType.New:
                    SceneManager.LoadScene("GameScene");
                    break;
                case BTNType.Quit:
                    Quit ();
                    break;

            }
        }
    }
}
