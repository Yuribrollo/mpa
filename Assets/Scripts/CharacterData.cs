using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [Header("Identificação")]
    public string characterName;

    [Header("Convencimento")]
    public int convencimentoInicial = 50;
    public int convencimentoMaximo = 100;

    [Header("Diálogos")]
    public DialogueStep[] dialogos;

    [Header("Aparência")]
    public Sprite retrato;

    [Header("Estado da conversa")]
    public bool dialogoFinalizado = false;
}