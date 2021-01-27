using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator anim;
    public GameController gameController;

    public static bool againWalkAfterKill;

    private NavMeshAgent _agent;
   
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FindPath());
    }

    IEnumerator FindPath()
    {
        while(true)
        {
            if (player != null)
            {
                anim.SetBool("isWalking", true);
                _agent.SetDestination(player.position);
                yield return new WaitForSeconds(2f);
            }
           
            else break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            anim.SetBool("isFall", true);
            StopAllCoroutines();
            _agent.enabled = false;
            Destroy(gameObject, 3f);
            againWalkAfterKill = true;
            gameController.winTable.SetActive(true);
            gameController.restartInGameButton.SetActive(false);
        }
    }
}
