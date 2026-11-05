using UnityEngine;

public class NPCInterection : MonoBehaviour
{
    public PersuasionManager persuasionManager;

    private CharacterData personagem;

    void Awake()
    {
        personagem = GetComponent<CharacterData>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            persuasionManager.IniciarDialogo(personagem);
        }
    }
}