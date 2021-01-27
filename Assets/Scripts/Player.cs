using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Gun gun;

    private NavMeshAgent _myAgent;
    public float speedRotation = 180f;

    public bool tower;
    public bool ground;

    public PlayerMain playerMain; // Scriptableobject

      private void Start()
      {
        _myAgent = GetComponent<NavMeshAgent>();
        anim.SetBool("idle", true);
      }

    private void Update()
    {
      float mx = Input.GetAxis("Mouse X");

      if (Input.GetMouseButtonDown(0) && ground == true) 
      {
         Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(myRay, out hit, Mathf.Infinity))
         {
            _myAgent.isStopped = false;

            anim.SetBool("Walk", true);

            _myAgent.SetDestination(hit.point);
            _myAgent.speed = playerMain.speedAgentSobj;
         }  
      }

      if (Input.GetMouseButtonDown(0) && tower == true)
      {
         gun.Shoot();
            _myAgent.isStopped = true;
      }

      if(mx != 0)
      {
         transform.Rotate(transform.up * mx * speedRotation * Time.deltaTime);
      }
       
      if (_myAgent.destination == transform.position)
      {
         _myAgent.isStopped = true;
         anim.SetBool("Walk", false);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            tower = true;
            anim.SetBool("Shoot", true);
            anim.SetBool("Walk", false);
        }

        if (other.tag == "Ground") 
        {
            ground = true;
        }
    }
}
