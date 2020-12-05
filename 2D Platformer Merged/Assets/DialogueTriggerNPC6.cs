using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC6 : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC6>().StartDialogue(dialogue);
	}
}
