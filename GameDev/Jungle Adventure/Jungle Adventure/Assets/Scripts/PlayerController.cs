using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float groundJumpForce = 4f;
    public float vineJumpForce = 4f;
    
    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    public int currentHealth;
    
    [Header("Distance")]
    public float distanceToVine;
    public float groundCheckDistance = 0.5f;
    public float vineCheckDistance = 0.5f;
    public float searchRadius = 2f;
    public float screamRadius = 2f;

    [Header("Bool")]
    public bool isGrounded; 
    public bool isSwinging;
    public bool canSwing;
    public bool canInput;

    [Header("Variables")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask vineLayer;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private Animator animator;
    
    [SerializeField] private GameObject leaderBordScreen;

    [SerializeField] private Transform vineCheck;

    private Rigidbody2D _rb;
    private DistanceJoint2D _joint;
    

    private void Start()
    {
        Time.timeScale = 1;
        canInput = true;
        currentHealth = maxHealth;
        canSwing = true;
        _rb = GetComponent<Rigidbody2D>();
        _joint = GetComponent<DistanceJoint2D>();
        _joint.enabled = false;
    }

    private void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position,Vector2.down , groundCheckDistance, groundLayer);

        animator.SetBool("IsGrounded", isGrounded);

        if(canInput)
            MyInput();
        
        TryToSwing();
        animator.SetBool("IsSwinging", isSwinging);
    }

    private void MyInput()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded) //GroundJump
        {
            _rb.AddForce(Vector2.one * groundJumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetMouseButtonDown(0) && isSwinging) // Vine Jump
        {
            _joint.enabled = false;
            isSwinging = false;
            canSwing = false;
            _rb.velocity = new Vector2(_rb.velocity.x * vineJumpForce, vineJumpForce);
        }
    }

    private void TryToSwing()
    {
        RaycastHit2D hit = Physics2D.Raycast(vineCheck.position, Vector2.right, vineCheckDistance, vineLayer);
        
        if (canSwing && !isGrounded && hit)
        {
            isSwinging = true;
            
            _joint.enabled = true;
            _joint.connectedBody = hit.collider.attachedRigidbody;
            _joint.autoConfigureDistance = false;
            _joint.distance = distanceToVine;
        }
        else
        {
            _joint.enabled = false;
            isSwinging = false;
            if (!Physics2D.OverlapCircle(transform.position, 0.75f, vineLayer))
                canSwing = true;
        }
    }

    private Collider2D FindNearestCollider()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius, vineLayer);
        
        Collider2D nearestCollider = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            float distance = Vector2.Distance(transform.position, collider.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestCollider = collider;
            }
        }

        return nearestCollider;
    }

    public void FellOut()
    {
        TakeDamage();
        
        Collider2D nearestCollider = FindNearestCollider();
        
        if (nearestCollider != null)
        {
            Debug.Log("Fell");
            transform.position = nearestCollider.attachedRigidbody.position;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, screamRadius);
    }
    
    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log("Take Damage");

        if (currentHealth <= 0)
            Death();
    }

    private void Death()
    {
        Debug.Log("Player is Dead!");
        Time.timeScale = 0;
        leaderBordScreen.SetActive(true);
    }

    public void Scream()
    {
        Debug.Log("Scream");
        animator.SetTrigger("Scream");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, screamRadius, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Enemy>().Death();
            Debug.Log(enemy.name + " Destroyed");
            Destroy(enemy.gameObject, 5f);
        }
    }

    public void CanInput()
    {
        canInput = true;
    }

    public void CantInput()
    {
        canInput = false;
    }
}
