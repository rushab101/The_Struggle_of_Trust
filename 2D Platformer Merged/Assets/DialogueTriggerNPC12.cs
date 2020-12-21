using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC12 : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC12>().StartDialogue(dialogue);
	}
}
