using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private bool audioLocked = false;
    public AudioSource source;
    public GameObject lights;
    public AudioClip[] thunderAudios;
    public GameObject[] enemyBehaviours;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("playLighting", UnityEngine.Random.Range(3f, 10f));
    }

    public void Death()
    {
        SceneManager.LoadScene("Death");
    }


    public void playLighting()
    {
        int lightningCount = 5;
        foreach (var i in System.Linq.Enumerable.Range(1, lightningCount))
        {
            StartCoroutine(waitForAction(flashLight, i * .1f + UnityEngine.Random.Range(0f, 0.4f)));
        }
        var thunderDelay = UnityEngine.Random.Range(2f, 3f);
        StartCoroutine(waitForAction(playThunderClip, thunderDelay));
        var lightingBurstInterval = UnityEngine.Random.Range(15f, 20f);
        StartCoroutine(waitForAction(playLighting, lightingBurstInterval));
    }

    public void playThunderClip()
    {
        int index = UnityEngine.Random.Range(0, thunderAudios.Length);
        source.clip = thunderAudios[index];
        source.Play();
    }

    IEnumerator waitForAction(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public void flashLight()
    {
        StartCoroutine(fadeLight());
    }
    IEnumerator fadeLight()
    {
        lights.SetActive(true);
        foreach (var enemy in enemyBehaviours)
        {
            enemy.GetComponent<EnemyBehaviour>().CrazyMove();
        }
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, .3f));
        lights.SetActive(false);
        foreach (var enemy in enemyBehaviours)
        {
            enemy.GetComponent<EnemyBehaviour>().StopCrazyMovement();
        }
    }

    /*
        void QueueLightning()
        {
            StartCoroutine(WaitAndAlgo(QueueLightning, RandomLightningInteval));
            if(thunderChance)
                StartCoroutine(WaitAndAlgo(QueueThunder, lightSoundInterval));

            lucecitas();
        }

        void QueueThunder()
        {
            trueno();
        }

        IEnumerator WaitAndAlgo(Action algo, float time)
        {
            yield return new WaitForSeconds(time);
            algo();
        }
     */

}
