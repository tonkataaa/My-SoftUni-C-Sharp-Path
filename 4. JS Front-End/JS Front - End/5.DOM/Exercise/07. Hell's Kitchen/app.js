function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let input = document.querySelector('#inputs textarea').value;
      const restaurantStrings = JSON.parse(input);

      const restaurants = restaurantStrings.map(restaurantStr => {
         const [name, workersStr] = restaurantStr.split(' - ');
         const workers = workersStr.split(', ').map(workerStr => {
            const [name, salary] = workerStr.split(' ');
            return {name, salary: Number(salary)};
         });
         return {name, workers};
      })

      let outputHtml = '';
      restaurants.forEach(restaurant => {
          outputHtml += `<h3>${restaurant.name}</h3><ul>`;
          restaurant.workers.forEach(worker => {
              outputHtml += `<li>${worker.name}: ${worker.salary}</li>`;
          });
          outputHtml += `</ul>`;
      });
      document.querySelector('#bestRestaurant p').innerHTML = outputHtml;
      
   }
}