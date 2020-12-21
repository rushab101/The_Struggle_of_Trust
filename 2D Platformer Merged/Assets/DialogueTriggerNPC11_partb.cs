using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC11_partb : MonoBehaviour
{
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC11_partb>().StartDialogue(dialogue);
	}
}

