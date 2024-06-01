using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace cherrydev
{
    public class SentencePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogNameText;
        [SerializeField] private TextMeshProUGUI dialogText;
        [SerializeField] private Image dialogCharacterImage;
        [SerializeField] private Image dialogCharacterImage1;
        [SerializeField] private Color speakColor;
        [SerializeField] private Color silentColor;

        /// <summary>
        /// Setting dialogText max visible characters to zero
        /// </summary>
        public void ResetDialogText()
        {
            dialogText.maxVisibleCharacters = 0;
        }

        /// <summary>
        /// Set dialog text max visible characters to dialog text length
        /// </summary>
        /// <param name="text"></param>
        public void ShowFullDialogText(string text)
        {
            dialogText.maxVisibleCharacters = text.Length;
        }

        /// <summary>
        /// Assigning dialog name text, character image sprite and dialog text
        /// </summary>
        /// <param name="name"></param>
        public void Setup(string name, string text, Sprite sprite, Sprite sprite1)
        {
            dialogNameText.text = name;
            dialogText.text = text;

            if (sprite == null)
            {
                dialogCharacterImage.color = new Color(dialogCharacterImage.color.r,
                    dialogCharacterImage.color.g, dialogCharacterImage.color.b, 0);
                return;
            }
            
            if (sprite1 == null)
            {
                dialogCharacterImage1.color = new Color(dialogCharacterImage.color.r,
                    dialogCharacterImage1.color.g, dialogCharacterImage.color.b, 0);
                return;
            }

            // dialogCharacterImage.color = new Color(dialogCharacterImage.color.r,
            //         dialogCharacterImage.color.g, dialogCharacterImage.color.b, 255);

            dialogCharacterImage.color = speakColor;
            dialogCharacterImage.sprite = sprite;

            dialogCharacterImage1.color = silentColor;
            dialogCharacterImage1.sprite = sprite1;
        }

        /// <summary>
        /// Increasing max visible characters
        /// </summary>
        public void IncreaseMaxVisibleCharacters()
        {
            dialogText.maxVisibleCharacters++;
        }

        public void SwapImageSpeaker()
        {
            if (dialogCharacterImage.color == speakColor)
            {
                dialogCharacterImage.color = silentColor;
            }
            else
            {
                dialogCharacterImage.color = speakColor;
            }
            
            if (dialogCharacterImage1.color == speakColor)
            {
                dialogCharacterImage1.color = silentColor;
            }
            else
            {
                dialogCharacterImage1.color = speakColor;
            }
        }
    }
}