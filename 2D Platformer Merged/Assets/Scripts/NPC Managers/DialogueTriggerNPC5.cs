using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC5 : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManagerNPC5>().StartDialogue(dialogue);
	}
}
