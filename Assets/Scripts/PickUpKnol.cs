using System.Collections.Generic;
using UnityEngine;

public class PickUpKnol : MonoBehaviour
{
    [SerializeField] GameObject wortelHands;
    [SerializeField] GameObject radijsHands;
    [SerializeField] GameObject bosuiHands;

    GameObject currentActiveHands;

    List<Collider> currentlyCollidedObjects = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        currentlyCollidedObjects.Add(other);
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
        currentlyCollidedObjects.Remove(other);
    }

    public void PickUp()
    {
        if (currentlyCollidedObjects == null || currentlyCollidedObjects.Count == 0) return;
        else
        {
                switch (currentlyCollidedObjects[0].tag)
                {
                    case "Radijsje":
                        ActivateHands(radijsHands);
                        break;
                    case "Wortel":
                        ActivateHands(wortelHands);
                        break;
                    case "Bosui":
                        ActivateHands(bosuiHands);
                        break;
                    default:
                        break;
                }
        }
    }

    private void ActivateHands(GameObject newHands)
    {
        currentActiveHands?.SetActive(false);
        newHands.SetActive(true);
        currentActiveHands = newHands;
    }
}
