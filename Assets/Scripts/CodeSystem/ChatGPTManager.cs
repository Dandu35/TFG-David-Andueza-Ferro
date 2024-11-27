using UnityEngine;
using TMPro;
using OpenAI;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi("Credenciales");
    private List<ChatMessage> messages = new List<ChatMessage>();

    public TMP_InputField inputField; // Referencia al TMP_InputField
    public Text textObject; // Desafio
    public static int idMaquina;

    public async void AskChatGPT()
    {
        string desafio = textObject.text;
        string userInput = inputField.text;
        string newText = "Se le pide al usuario que desarrolle el siguiente codigo: " + desafio + ". Nos entrega este codigo: " + userInput + ".Comprueba si  el codigo del usuario corresponde con el codigo pedido y devuelve solo  si es correcto o incorrecto, una palabra";

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
            if (chatResponse.Content.Trim().ToLower() == "correcto")
            {
                Debug.Log("El código del usuario es correcto.");

                // Aquí llamas al método DropItem de la instancia de MaquinaRetro específica
                int maquinaId = idMaquina; // Cambia esto al ID de la máquina que deseas afectar
                MaquinaRetro maquinaRetroInstance = MaquinaRetro.FindById(maquinaId);
                if (maquinaRetroInstance != null)
                {
                    maquinaRetroInstance.DropItem();
                }
                else
                {
                    Debug.LogError("No se encontró una instancia de MaquinaRetro con el ID especificado.");
                }
            }
        }


    }
}
