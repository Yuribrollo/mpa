using UnityEngine;

[System.Serializable]
public class DialogueStep
{
    [TextArea(3, 5)]
    public string falaPersonagem;

    public DialogueOption[] opcoes;
}