using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC9 : MonoBehaviour
{
       public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC9>().StartDialogue(dialogue);
	}
}
