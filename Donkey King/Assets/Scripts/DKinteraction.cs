using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKinteraction : MonoBehaviour 
{
    GameObject haybails;
    public Animator animator;
    public int speed;
    void OnTriggerEnter2D(Collider2D dropdown) {
        if (dropdown.gameObject.tag == "haybails")
        {
            dropdown.GetComponent<push>().isbeingpushed = true;
            animator.SetBool("iShit", true);
        }
        else {
            animator.SetBool("iShit", false);
        }
    }
    void OnTriggerExit2D(Collider2D dropdown)
    {
        if (dropdown.gameObject.tag == "haybails")
        {
            dropdown.GetComponent<push>().isbeingpushed = false;
         
        }
        
    }
}

