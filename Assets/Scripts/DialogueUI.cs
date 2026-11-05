using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [Header("Painel")]
    public GameObject dialoguePanel;

    [Header("Informações do personagem")]
    public Image retrato;
    public TMP_Text nome;
    public TMP_Text dialogo;

    public void AbrirDialogo(CharacterData personagem)
    {
        Debug.Log("DialogueUI chamado: " + gameObject.name);
        Debug.Log("DialoguePanel: " + dialoguePanel);

        dialoguePanel.SetActive(true);
        dialoguePanel.transform.SetAsLastSibling();

        Debug.Log("Painel ativo: " + dialoguePanel.activeSelf);
        Debug.Log("Painel na tela: " + dialoguePanel.GetComponent<RectTransform>().position);

        //retrato.sprite = personagem.retrato;
        nome.text = personagem.characterName;
    }

    public void FecharDialogo()
    {
        dialoguePanel.SetActive(false);

    }
}