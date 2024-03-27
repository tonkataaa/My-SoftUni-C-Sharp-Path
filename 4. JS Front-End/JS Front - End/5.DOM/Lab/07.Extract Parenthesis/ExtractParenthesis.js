function extract(content) {
    const contentElement = document.getElementById("content").textContent;
    const regex = /\(([^)]+)\)/g;
    let matches = contentElement.match(regex);

    let extractedContent = matches.map((match) => {
        return match.substring(1, match.length - 1); 
      });

      return extractedContent.join("; ");
}