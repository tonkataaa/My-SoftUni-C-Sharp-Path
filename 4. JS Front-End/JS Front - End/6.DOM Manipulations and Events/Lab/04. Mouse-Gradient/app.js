function attachGradientEvents() {
  const gradient = document.getElementById("gradient");
  const resultElement = document.getElementById("result");

  gradient.addEventListener("mousemove", function (event) {
    const gradientWidth = gradient.clientWidth -1;
    const mouseX = event.offsetX;

    const percentage = Math.trunc((mouseX / gradientWidth) * 100);
    resultElement.textContent = percentage + "%";
  });

  gradient.addEventListener("mouseout", function () {
    resultElement.textContent = "";
  });
}
