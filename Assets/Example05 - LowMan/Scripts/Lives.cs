using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public Camera cam;
    public int lives = 3;
    private Vector3 spawnVector;

    void Start()
    {
        spawnVector = this.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            cam.GetComponent<AudioSource>().Play();
        }

        if(lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
