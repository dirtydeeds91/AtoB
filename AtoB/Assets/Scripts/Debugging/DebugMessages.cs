using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AtoB.Debugging
{
    public class DebugMessages : MonoBehaviour
    {
        [SerializeField]
        private Text debugMessagesText;

        public static DebugMessages Instance { get; private set; }

        private List<string> allMessages;
        private List<float> messageTimes;
        private int counter;

        private void Awake()
        {
            //Just destroy yourself if the game is not in debug mode!
            if (!Debug.isDebugBuild)
            {
                Destroy(this.gameObject);
            }

            //Make sure there is a Logger Singleton that is the active one
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            this.allMessages = new List<string>();
            this.messageTimes = new List<float>();
        }

        private void Update()
        {
            if (this.messageTimes.Count > 0)
            {
                bool hasRemoved = false;
                while (this.messageTimes[0] + 3f < Time.time)
                {
                    this.messageTimes.RemoveAt(0);
                    this.allMessages.RemoveAt(0);
                    hasRemoved = true;
                }

                if (hasRemoved)
                {
                    RebuildMessages();
                }
            }
       }

        public void PrintMessage(string message)
        {
            this.allMessages.Add(message);
            this.messageTimes.Add(Time.time);
            RebuildMessages();
        }

        private void RebuildMessages()
        {
            counter = 0;
            for (int i = this.allMessages.Count - 1; i >= 0; i--)
            {
                this.debugMessagesText.text += this.allMessages[i];
                counter++;
                if (counter >= 5)
                {
                    break;
                }   
            }
        }
    }
}