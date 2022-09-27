using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private Timer timer;
    public AudioSource audioSource;
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        TryGetComponent(out animator);
        timer = FindObjectOfType<Timer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.health < 1)
        {
            animator.SetBool("EndGame", true);
            timer.stop = true;
            audioSource.Stop();



        }
        

    }
}
