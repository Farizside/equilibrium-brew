using UnityEngine;

namespace cherrydev
{
    [System.Serializable]
    public struct Sentence
    {
        public string characterName;
        public string text;
        public Sprite characterSprite;
        public Sprite characterSprite1;

        public Sentence(string characterName, string text)
        {
            characterSprite = null;
            characterSprite1 = null;
            this.characterName = characterName;
            this.text = text;
        }
    }
}