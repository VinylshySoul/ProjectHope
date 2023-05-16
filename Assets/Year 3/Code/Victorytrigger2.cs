using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victorytrigger2 : MonoBehaviour
{
    private Scene VictoryScreen;

    

    public void Start()
    {
        VictoryScreen = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("VictoryScreen");
        }
        
    }

}
