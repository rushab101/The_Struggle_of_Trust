using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC3_A : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC3_A>().StartDialogue(dialogue);
	}
}
