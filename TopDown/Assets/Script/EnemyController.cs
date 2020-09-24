using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    GameManager gm;
    Vector2 movement;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        movement.x = 1f;
        animator.SetFloat("Horizontal", 0f);
        //animator.SetFloat("Speed", 1f);

        StartCoroutine(ChangeSideWalk());
    }

    private void Update()
    {

    }


    private IEnumerator ChangeSideWalk()
    {
        while (true)
        {
            animator.SetFloat("Horizontal", movement.x);
            yield return new WaitForSeconds(2f);
            movement.x = - movement.x;
        }
        
    }
    public void Die()
    {
        animator.SetTrigger("EnemyDie");
        StopCoroutine("ChangeSideWalk");
        movement.x = 0;
        gm.GoToMenu();
        Destroy(gameObject, 0.8f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
