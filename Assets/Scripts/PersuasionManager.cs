using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersuasionManager : MonoBehaviour
{
    public CharacterData personagem;
    public Slider persuasionSlider;

    [Header("Interface")]
    public TMP_Text characterNameText;
    public TMP_Text dialogueText;
    public Button[] optionButtons;
    public MonoBehaviour controleMovimento;

    public DialogueUI dialogueUI;
    private int convencimento;
    private int dialogoAtual;

    void Start()
    {
        dialogueUI.FecharDialogo();
        //controleMovimento.enabled = true;
    }

    public void IniciarDialogo(CharacterData novoPersonagem)
    {

        if (novoPersonagem.dialogoFinalizado)
        {
            return;
        }

        //controleMovimento.enabled = false;
        personagem = novoPersonagem;

        convencimento = personagem.convencimentoInicial;
        dialogoAtual = 0;

        persuasionSlider.minValue = 0;
        persuasionSlider.maxValue = personagem.convencimentoMaximo;
        persuasionSlider.value = convencimento;

        characterNameText.text = personagem.characterName;

        dialogueUI.AbrirDialogo(personagem);

        MostrarDialogo(0);
    }

    void MostrarDialogo(int indice)
    {
        dialogoAtual = indice;

        DialogueStep dialogo = personagem.dialogos[indice];

        dialogueText.text = dialogo.falaPersonagem;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < dialogo.opcoes.Length)
            {
                optionButtons[i].gameObject.SetActive(true);

                TMP_Text texto = optionButtons[i]
                    .GetComponentInChildren<TMP_Text>();

                texto.text = dialogo.opcoes[i].texto;

                int indiceOpcao = i;

                optionButtons[i].onClick.RemoveAllListeners();

                optionButtons[i].onClick.AddListener(
                    () => EscolherResposta(indiceOpcao)
                );
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void EscolherResposta(int indiceOpcao)
    {
        DialogueOption opcao = personagem.dialogos[dialogoAtual].opcoes[indiceOpcao];

        convencimento += opcao.valorConvencimento;
        convencimento = Mathf.Clamp(convencimento, 0, personagem.convencimentoMaximo);

        persuasionSlider.value = convencimento;

        if (convencimento >= personagem.convencimentoMaximo)
        {
            Debug.Log("PERSONAGEM CONVENCIDO!");
            personagem.dialogoFinalizado = true;
            dialogueUI.FecharDialogo();
            //controleMovimento.enabled = true;
            return;
        }

        if (convencimento <= 0)
        {
            Debug.Log("VOCÊ NÃO CONSEGUIU CONVENCER!");
            personagem.dialogoFinalizado = true;
            dialogueUI.FecharDialogo();
            //controleMovimento.enabled = true;
            return;
        }

        MostrarDialogo(opcao.proximoDialogo);
    }
}