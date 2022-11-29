using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactableMask;

    public Transform[] spawnPoint;
    public Transform myChild;
    public Transform parentObject;

    private readonly Collider[] colliders = new Collider[3]; //"How many things are we looking for, maybe?
    [SerializeField] private int numFound;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            Vector3 spawnPoint = interactionPoint.position;
            if (numFound != 0 && Input.GetKeyDown(KeyCode.E))
            {
                Transform newChild = Instantiate(myChild, spawnPoint, Quaternion.identity) as Transform;
                newChild.parent = parentObject;
            }
            if (numFound != 0 && Input.GetKeyDown(KeyCode.Q))
            {
                //remove closest mark
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
    //GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = interactionPoint.position;
}
