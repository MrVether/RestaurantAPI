// Make a GET request to the API to retrieve the list of restaurants
fetch('/api/restaurant/GetAll')
    .then(response => response.json())
    .then(data => {
        // Get the restaurant list container
        const restaurantList = document.getElementById('restaurantList');

        // Iterate over the list of restaurants and create a new HTML element for each one
        data.forEach(restaurant => {
            const newRestaurant = document.createElement('div');
            newRestaurant.innerHTML = restaurant.name;
            restaurantList.appendChild(newRestaurant);
        });
    })
    .catch(error => console.error(error));
