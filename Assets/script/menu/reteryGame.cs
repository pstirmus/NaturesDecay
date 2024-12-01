using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reteryGame : MonoBehaviour
{
    public void RestarButton()
    {
        SceneManager.LoadScene(1);
    }
}
