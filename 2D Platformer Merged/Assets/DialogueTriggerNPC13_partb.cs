using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC13_partb : MonoBehaviour
{
    
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManagerNPC13_partb>().StartDialogue(dialogue);
	}
}
