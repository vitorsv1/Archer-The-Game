using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firepoint;
    public Animator animator;

    public float arrowForce = 20f;
    Vector2 movement;
    Vector2 currDirection;


    private void Start()
    {
        animator.SetFloat("LookX", 0);
        animator.SetFloat("LookY", 1);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("LookX", currDirection.x);
        animator.SetFloat("LookY", currDirection.y);

        setArrowPoint();

        if (Input.GetButtonDown("Fire1")){
            SetShoot();
        }
    }

    public void SetShoot()
    {
        animator.SetTrigger("Attack");
    }

    public void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(currDirection * arrowForce, ForceMode2D.Impulse);
    }
    private void setArrowPoint()
    {
        if (movement.x > 0)
        {
            firepoint.transform.eulerAngles = new Vector3(0, 0, -90);
            currDirection = Vector2.right;
        }
        else if (movement.x < 0)
        {
            firepoint.transform.eulerAngles = new Vector3(0, 0, 90);
            currDirection = Vector2.left;
        }

        else if (movement.y > 0)
        {
            firepoint.transform.eulerAngles = new Vector3(0, 0, 0);
            currDirection = Vector2.up;

        }
        else if (movement.y < 0)
        {
            firepoint.transform.eulerAngles = new Vector3(0, 0, 180);
            currDirection = Vector2.down;

        }
    }



}
