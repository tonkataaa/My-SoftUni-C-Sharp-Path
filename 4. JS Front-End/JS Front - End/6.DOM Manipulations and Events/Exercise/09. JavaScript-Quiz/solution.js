function solve() {
  const sections = document.querySelectorAll('section');
    let currentSectionIndex = 0;
    let correctAnswersCount = 0;
    const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

    document.getElementById('quizzie').addEventListener('click', function (event) {
        if (event.target.className.includes('answer-text')) {
            let chosenAnswer = event.target.textContent.trim();
            if (correctAnswers.includes(chosenAnswer)) {
                correctAnswersCount++;
            }

            const currentSection = sections[currentSectionIndex];
            currentSection.style.display = 'none'; 

            currentSectionIndex++;
            if (currentSectionIndex < sections.length) {
                sections[currentSectionIndex].style.display = 'block'; 
            } else {
                displayResults(correctAnswersCount);
            }
        }
    });

    function displayResults(score) {
        const resultsElement = document.getElementById('results');
        resultsElement.style.display = 'block';
        const resultsMessage = document.querySelector('#results h1');

        if (score === correctAnswers.length) {
            resultsMessage.textContent = "You are recognized as top JavaScript fan!";
        } else {
            resultsMessage.textContent = `You have ${score} right answers`;
        }
    }
}
