using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC3 : MonoBehaviour
{
    
   public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC3>().StartDialogue(dialogue);
	}
}
