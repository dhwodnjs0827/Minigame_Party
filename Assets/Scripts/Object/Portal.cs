using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScene
{
    Main,
    Mini
}

public class Portal : MonoBehaviour
{
    public EScene scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene((int)scene);
        }
    }
}
