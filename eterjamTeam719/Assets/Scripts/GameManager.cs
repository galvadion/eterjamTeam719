using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int life;
    private GameObject player;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        life = 1;
    }

    private void Update()
    {
        if (life == 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    public void Death()
    {
        life = life - 1;
    }
}
