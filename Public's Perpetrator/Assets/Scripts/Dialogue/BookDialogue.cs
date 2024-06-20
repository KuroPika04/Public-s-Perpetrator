using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDialogue : MonoBehaviour
{
    private DialogueTrigger dialogue_trigger;
    private bool CanTriggerDialogue = false;
    private DialogueManager dialogue_manager;
    private Phone nokia;
    private void Start()
    {
        dialogue_trigger = GetComponent<DialogueTrigger>();
        dialogue_manager = GetComponent<DialogueManager>();
    }

    private void Awake()
    {
        nokia = GetComponent<Phone>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanTriggerDialogue && dialogue_manager.dialoguebox_on == false && !nokia.phoneout)
        {
            dialogue_trigger.TriggerDialogue();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanTriggerDialogue = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanTriggerDialogue = false;
        }
    }
}
