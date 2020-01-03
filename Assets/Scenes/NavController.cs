using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NavController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    private bool selected;

    [SerializeField]
    private LayerMask playerLayer;
    private void Start()
    {
        cam = Camera.main;
        agent.updateRotation = false;
        selected = false;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (selected)
                {
                    agent.SetDestination(hit.point);
                    selected = false;
                    Debug.Log("MOVE " + gameObject.name);
                }
            }
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerLayer) && hit.collider.gameObject.name == gameObject.name)
            { //if the ray is hitting an object on player layer and if the collider is this game object
                selected = true;
                Debug.Log("SELECTED " + gameObject.name);
            }
            //Debug.Log(hit.point);
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
