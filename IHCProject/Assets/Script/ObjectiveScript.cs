using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: Colocar esses secene managements em uma classe só ?
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Win !");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}