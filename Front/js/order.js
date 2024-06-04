document.addEventListener('DOMContentLoaded', function () {
    const order = JSON.parse(localStorage.getItem('order'));
    console.log(order)
    if (order) {
        const image = document.getElementById("ramen-imagen");
        image.src = order.image;

        const description = document.getElementById("description");
        description.textContent = order.description;

        localStorage.removeItem('order');
    }
});

function placeNewOrder() {
    window.location.href = '/'
}