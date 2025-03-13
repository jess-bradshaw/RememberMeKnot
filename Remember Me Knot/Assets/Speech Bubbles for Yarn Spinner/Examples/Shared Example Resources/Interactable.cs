using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Yarn.Unity;

#nullable enable

namespace Yarn.Unity.Addons.SpeechBubbles.Example
{
    public class Interactable : MonoBehaviour
    {
        public GameObject? interactableIndicator = null;

        public YarnProject? project;

        [YarnNode(nameof(project))]
        public string? nodeName;

        public float range = 1f;

        private bool isCurrentInteractable = false;

        [SerializeField] DialogueRunner? dialogueRunner;

        // How much time should we wait after dialogue ends before showing the
        // indicator again?
        [SerializeField] float delayAfterConversationEnds = 1f;

        float delayRemaining = 0f;

        public void Awake()
        {
            OnBecameInactive();
        }

        public void Update()
        {
            if (interactableIndicator != null)
            {
                bool dialogueRunning = dialogueRunner != null && dialogueRunner.IsDialogueRunning;
                bool hasDialogueRunner = dialogueRunner != null;

                bool shouldShowIndicator = isCurrentInteractable && hasDialogueRunner && delayRemaining <= 0f
                    && dialogueRunning == false;

                interactableIndicator.SetActive(shouldShowIndicator);

                if (dialogueRunning)
                {
                    delayRemaining = delayAfterConversationEnds;
                }
            }

            if (delayRemaining > 0)
            {
                delayRemaining -= Time.deltaTime;
            }
        }

        public void OnInteracted()
        {
            if (dialogueRunner == null)
            {
                Debug.LogWarning($"Tried to start interaction with {name}, but {nameof(dialogueRunner)} was not set!");
            }
            else if (string.IsNullOrWhiteSpace(nodeName))
            {
                Debug.LogWarning($"Tried to start interaction with {name}, but {nameof(nodeName)} was empty!");
            }
            else
            {
                dialogueRunner.StartDialogue(nodeName);
            }
        }

        public void OnBecameActive()
        {
            this.isCurrentInteractable = true;
            // We just became active (i.e. the player walked into range of us), so
            // show the indicator right away even if we were waiting for the
            // dialogue-ended delay to finish
            delayRemaining = 0f;
        }

        public void OnBecameInactive()
        {
            this.isCurrentInteractable = false;
        }
    }
}