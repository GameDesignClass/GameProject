using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CharacterSelectionUI : MonoBehaviour
{
    public GameObject optionPrefab;

    public Transform prevCharacter;
    public Transform selectedCharacter;

    private void Start()
    {
        foreach(Character c in GameManager.instance.characters)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() => {
                GameManager.instance.SetCharacter(c);
                if (selectedCharacter != null)
                {
                    prevCharacter = selectedCharacter;
                }
                else
                {
                    selectedCharacter = option.transform;
                }
            });

            TextMeshProUGUI text = option.GetComponentInChildren<TextMeshProUGUI>();
            text.text = c.name;

            Image image = option.GetComponentInChildren<Image>();
            image.sprite = c.icon;
        }
    }

}
