using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public int damage;
    public Animator playerAnim;
    public Rigidbody2D player2rb;
    public Transform player2;

    void Start()
    {
        // script = GameObject.Find("Player2").GetComponent<Player2Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //then you can attack
            if (Input.GetKey(KeyCode.J))
            {
                playerAnim.SetTrigger("Attack");
                // Array stores all enemies found inside the circle hit
                Collider2D[] enemiesFound = Physics2D.OverlapCircleAll(attackPos.position, attackRange);

                for (int i = 0; i < enemiesFound.Length; i++) {
                    if (enemiesFound[i].CompareTag("Enemy"))
                    {
                        enemiesFound[i].GetComponent<EnemyScript>().Die();
                    }
                    // change this to .TakeDamage(damage); in the future if i have time to give underenemy health
                    //enemiesFound[i].GetComponent<EnemyScript>().Die();

                    /*
                    if (transform.position.x > player2.position.x) {
                        // if player hits player 2 who is to the left
                        player2rb.velocity = new Vector3(-(script.damageTaken), player2rb.velocity.y);
                    } else {
                        // if player hits player 2 who is to the right
                        player2rb.velocity = new Vector3(script.damageTaken, player2rb.velocity.y);
                    }
                    */
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    // Allows Unity to visualize the attack radius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
