using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpKnol : MonoBehaviour
{
    [SerializeField] GameObject wortelHands;
    [SerializeField] GameObject radijsHands;
    [SerializeField] GameObject bosuiHands;
    [SerializeField] GameObject emptyHands;

    private PlayerController playerController;

    GameObject currentActiveHands;

    List<Collider> currentlyCollidedObjects = new List<Collider>();

    private bool isHoldingKnol = false;
    KNOLTYPE currentKnolType = default;

    private void Awake()
    {
        playerController = new PlayerController();
        playerController.Player.Enable();

        playerController.Player.Interact.performed += PickUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!currentlyCollidedObjects.Contains(other))
        {
            currentlyCollidedObjects.Add(other);
        }
        //switch (other.tag)
        //{
        //    case "Radijsje":
        //        ActivateHands(radijsHands);
        //        break;
        //    case "Wortel":
        //        ActivateHands(wortelHands);
        //        break;
        //    case "Bosui":
        //        ActivateHands(bosuiHands);
        //        break;
        //    default:
        //        break;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentlyCollidedObjects.Contains(other))
        {
            currentlyCollidedObjects.Remove(other);
        }
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        //if(context.phase == InputActionPhase.Performed)
        //{
        //Debug.Log("PICKUP() CALLED");
        if (isHoldingKnol)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1.2f;
            KnolSpawner.Instance.SpawnKnol(currentKnolType, spawnPos);
            isHoldingKnol = false;
            ActivateHands(emptyHands);
        }
        else
        {
            if (currentlyCollidedObjects == null || currentlyCollidedObjects.Count <= 0) return;
            else
            {
                Collider pickupCol = currentlyCollidedObjects[0];
                currentlyCollidedObjects.RemoveAt(0);
                switch (pickupCol.tag)
                {
                    case "Radijsje":
                        ActivateHands(radijsHands);
                        currentKnolType = KNOLTYPE.radijsje;
                        Destroy(pickupCol.gameObject);
                        break;
                    case "Wortel":
                        ActivateHands(wortelHands);
                        currentKnolType = KNOLTYPE.wortel;
                        Destroy(pickupCol.gameObject);
                        break;
                    case "Bosui":
                        ActivateHands(bosuiHands);
                        currentKnolType = KNOLTYPE.bosui;
                        Destroy(pickupCol.gameObject);
                        break;
                    default:
                        break;
                }

            }
        }
        //}
    }

    private void ActivateHands(GameObject newHands)
    {
        currentActiveHands?.SetActive(false);
        newHands.SetActive(true);
        currentActiveHands = newHands;
        isHoldingKnol = true;
    }
}
