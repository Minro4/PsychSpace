using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Darkness : MonoBehaviour
{
    public float playerHeadStart;
    public float darknessSpeed;
    public Rigidbody player;
    public Slider slider;
    public GameObject deathScreen;

    private float startTime;
    private bool isDead = false;

    private void Start()
    {
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        var shadowPos = (Time.time - startTime) * darknessSpeed - playerHeadStart;
        if (!isDead && player.position.z < shadowPos)
        {
            isDead = true;
            deathScreen.SetActive(true);
            StartCoroutine(OnDeath());
        }

        slider.value = 1 - (player.position.z - shadowPos) / 1500;
    }


    private IEnumerator OnDeath()
    {
        Debug.Log("on death");
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
