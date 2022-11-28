using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            mainMenu.SetActive(!mainMenu.active);
        }
    }
}