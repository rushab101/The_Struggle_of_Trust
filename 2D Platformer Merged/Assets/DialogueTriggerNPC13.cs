using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC13 : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC13>().StartDialogue(dialogue);
	}
}
