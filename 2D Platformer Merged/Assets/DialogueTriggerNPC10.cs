using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC10 : MonoBehaviour
{
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC10>().StartDialogue(dialogue);
	}
}
