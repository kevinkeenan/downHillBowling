using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneScript : MonoBehaviour
{
    public void changeScene(string s)
    {
        Application.LoadLevel(s);
    }
}
