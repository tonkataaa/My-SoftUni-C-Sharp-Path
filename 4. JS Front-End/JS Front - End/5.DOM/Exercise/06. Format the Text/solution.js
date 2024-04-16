function solve() {
  let text = document.getElementById('input').value;

  const sentances = text.match(/[^.!?]+[.!?]+/g) || [];
  let paragraphText = '';
  let sentenceCount = 0;

  sentances.forEach((sentance, index) => {
    paragraphText += sentance.trim() + ' ';
    sentenceCount++;

    if (sentenceCount === 3 || index === sentances.length - 1) {
      const paragraphElement = document.createElement('p');
      paragraphElement.innerHTML = paragraphText.trim();

      document.getElementById('output').appendChild(paragraphElement);
      paragraphText = '';
      sentenceCount = 0;
    }

  });
}