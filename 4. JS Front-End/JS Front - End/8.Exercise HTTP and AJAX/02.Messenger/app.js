function attachEvents() {
    const baseUrl = "http://localhost:3030/jsonstore/messenger";
    const textArea = document.getElementById("messages");
    const [nameInput, contentInput, sendButton, refreshButton] = document.getElementsByTagName("input");

    sendButton.addEventListener("click", async () => {
        const messageFormat = {
            author: nameInput.value,
            content: contentInput.value,
        };

        await fetch(baseUrl, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(messageFormat)
          });

        nameInput.value = "";
        contentInput.value = "";
    })

    refreshButton.addEventListener("click", async () =>{
        const response = await fetch(baseUrl);
        const messages = await response.json();
        textArea.value = Object.values(messages)
        .map(msg => `${msg.author}: ${msg.content}`)
      .join('\n');
    })
}

attachEvents();