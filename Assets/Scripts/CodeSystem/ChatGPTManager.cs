using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa la librería de TextMeshPro
using OpenAI;
using UnityEngine.UI;

public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi("sk-proj-vKY7OaE1eA46WlsBmyT4T3BlbkFJe9tc0aCuyl0Y7uCXhvYB", "org-LesZ88hs7BkcplHwfRr8kemT");
    private List<ChatMessage> messages = new List<ChatMessage>();

    public TMP_InputField inputField; // Referencia al TMP_InputField
    public Text textObject; // Desafio


    public async void AskChatGPT()
    {
        string desafio = textObject.text;
        string userInput = inputField.text;
        string newText = "Se le pide al usuario esto: " + desafio + ". Nos entrega este codigo: " + userInput + ".Comprueba si lo que el usuario a entregado corresponde con lo pedido y devuelve solo  si es correcto o incorrecto, una palabra";

        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";

        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}