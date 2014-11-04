using UnityEngine;
using System.Collections;

public class EnemyPaused : MonoBehaviour {
    Animator anim;
    NavMeshAgent nav;
    EnemyAttack enemyAttack;
    EnemyHealth enemyHealth;

	void Start () {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyHealth = GetComponent<EnemyHealth>();
	}

    void Update()
    {
        anim.enabled = !PauseManager.IsPaused;
        nav.enabled = !PauseManager.IsPaused && !enemyHealth.isDead;
        enemyAttack.enabled = !PauseManager.IsPaused;
    }
}
