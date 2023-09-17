using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerCombat : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Transform attackPoint;
    public float attackRange = 0.2f;
    public LayerMask enemyLayer;
    public LayerMask barrelLayer;
    public int attackDamage = 40;
    public float attackRate = 2f;
    private float _nextAttackTime = 0f;
    private bool _attacking = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time >= _nextAttackTime)
        {
            if (_attacking)
            {
                Attack();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        Collider2D[] hitBarrels = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, barrelLayer);

        foreach (Collider2D barrel in hitBarrels)
        {
            barrel.GetComponent<Barrel>().TakeDamage(attackDamage);
        }
        
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage);
        }
    }

    private void IsDead()
    {
        this.enabled = false;
    }

    public void AttackPressed()
    {
        _attacking = true;
    }

    public void AttackUnpressed()
    {
        _attacking = false;
    }
}
