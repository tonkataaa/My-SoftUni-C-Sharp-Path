function solve() {
   const textAreaElement = document.querySelector("textarea");
   const checkOutElement = document.querySelector(".checkout");
   const allProductsElement = Array.from(document.querySelectorAll(".product"));
   const allButtonsElement = Array.from(document.querySelectorAll("button"));
 
   let productsAdded = [];
   let totalPrice = 0;
 
   allProductsElement.forEach((element) => {
     const productTitle = element.querySelector(".product-title");
     const productButtonAdd = element.querySelector(".add-product");
     const productPrice = element.querySelector(".product-line-price");
 
     productButtonAdd.addEventListener("click", function(e) {
       const title = productTitle.textContent;
       const price = parseFloat(productPrice.textContent);
 
       textAreaElement.textContent += `Added ${title} for ${price.toFixed(2)} to the cart.\n`;
 
       if (!productsAdded.includes(title)) {
         productsAdded.push(title);
       }
 
       totalPrice += price;
     });
   });
 
   checkOutElement.addEventListener("click", function(e) {
     allButtonsElement.forEach(button => {
       button.disabled = true;
     });
 
     textAreaElement.textContent += `You bought ${productsAdded.join(", ")} for ${totalPrice.toFixed(2)}.`;
   });
 }
 