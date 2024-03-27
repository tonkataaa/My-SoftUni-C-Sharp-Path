function extractText() {
    const lists = document.getElementsByTagName(`li`);
    const result = [];

    for (const items of lists) {
        result.push(items.textContent);
    }

    const textAreaElement = document.getElementById("result");
    textAreaElement.textContent = result.join("\n");
}