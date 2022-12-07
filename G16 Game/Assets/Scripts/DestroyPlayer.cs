using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOver;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}