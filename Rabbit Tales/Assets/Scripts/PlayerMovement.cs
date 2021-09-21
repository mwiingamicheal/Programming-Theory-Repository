using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;
    public bool run;
    public int runSpeed;
    public int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        if(PlayerHealth.Instance.playerHealth <= 0)
        {
            Die();
            PlayerHealth.Instance.playerHealth = 0;


        }
    }

    void Run()
    {


        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        playerAnimator.SetFloat("Run", 0.2f);
        run = true;
        transform.Translate(0, 0, 1 * vertical * runSpeed * Time.deltaTime);
        transform.Translate(1 * horizontal * runSpeed * Time.deltaTime, 0, 0);

        transform.Rotate(0, 1 * horizontal * rotateSpeed * Time.deltaTime, 0);



        if (vertical == 0 && horizontal == 0)
        {
            Idle();
        }

        if (run == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnimator.speed = 2;

        }

        if (run == true && Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnimator.speed = 1.5f;
        }

        void Idle()
        {
            playerAnimator.SetFloat("Run", 0f);
            run = false;
        }

        
           
        
    }
    void Die()
    {
        playerAnimator.SetBool("Dead", true);
    }
}
