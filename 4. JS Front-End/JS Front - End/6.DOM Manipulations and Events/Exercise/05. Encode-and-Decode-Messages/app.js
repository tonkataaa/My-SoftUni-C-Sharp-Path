function encodeAndDecodeMessages() {
    const buttons = document.querySelectorAll("button");
    const textAreas = document.querySelectorAll("textarea");

    const encodeBtn = buttons[0];
    const senderTextArea = textAreas[0];

    const decodeBtn = buttons[1];
    const recieverTextArea = textAreas[1];

    encodeBtn.addEventListener("click", encodeMessage);
    decodeBtn.addEventListener("click", decodeMessage);

    function encodeMessage () {
        let message = senderTextArea.value;
        let encodeMsg = '';
        for (const char of message) {
            const encodeChar = String.fromCharCode(char.charCodeAt(0) + 1);
            encodeMsg += encodeChar;     
        }
        senderTextArea.value = '';
        recieverTextArea.value = encodeMsg;
    }

    function decodeMessage () {
        const message = recieverTextArea.value;
        let decodeMsg = '';
        for (const char of message) {
            const decodeChar = String.fromCharCode(char.charCodeAt(0) - 1);
            decodeMsg += decodeChar;
        }
        recieverTextArea.value = decodeMsg;
    }
}