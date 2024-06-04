const url = 'https://yquxto04gk.execute-api.us-east-1.amazonaws.com/Prod/api/v1'
const apiKey = 'ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf';

let broths;
let proteins;

let brothsSelected;
let proteinsSelected;

const Type = {
  BROTH: 'broths',
  PROTEIN: 'proteins'
};

document.addEventListener('DOMContentLoaded', function () {
  getBroths();
  getProteins();

  var botaoScroll = document.getElementById('newOrder');
  var parteDaTela = document.getElementById('itens');

  botaoScroll.addEventListener('click', function () {
    var rect = parteDaTela.getBoundingClientRect();
    var offsetTop = rect.top + window.scrollY;

    window.scrollTo({
      top: offsetTop,
      behavior: 'smooth'
    });
  });
});

function getBroths() {
  const myHeaders = new Headers();
  myHeaders.append("x-api-key", apiKey);

  const requestOptions = {
    method: "GET",
    headers: myHeaders,
    redirect: "follow"
  };

  fetch(url + "/broths", requestOptions)
    .then((response) => response.json())
    .then((result) => {
      broths = result
      renderItems(result, Type.BROTH)
    })
    .catch((error) => console.log(error));
}

function getProteins() {
  const myHeaders = new Headers();
  myHeaders.append("x-api-key", apiKey);

  const requestOptions = {
    method: "GET",
    headers: myHeaders,
    redirect: "follow"
  };

  fetch(url + "/proteins", requestOptions)
    .then((response) => response.json())
    .then((result) => {
      proteins = result
      renderItems(result, Type.PROTEIN)
    })
    .catch((error) => console.log(error));
}

function createItemElement(item, type) {
  const itemContainer = document.createElement('div');
  itemContainer.id = item.name.toLowerCase();
  itemContainer.classList.add('iten-container');
  itemContainer.onclick = function () { toggleClicked(this, type); };

  const img = document.createElement('img');
  img.src = item.imageInactive;
  img.alt = `${item.title} icon`;

  const title = document.createElement('span');
  title.classList.add('iten-title');
  title.textContent = item.name;

  const subtitle = document.createElement('span');
  subtitle.classList.add('sub-title');
  subtitle.textContent = item.description;

  const price = document.createElement('span');
  price.classList.add('price-title');
  price.textContent = `US$ ${item.price}`;

  itemContainer.appendChild(img);
  itemContainer.appendChild(title);
  itemContainer.appendChild(subtitle);
  itemContainer.appendChild(price);

  return itemContainer;
}

function renderItems(itemList, type) {
  const container = document.getElementById(type);
  container.innerHTML = '';
  itemList.forEach(item => {
    const itemElement = createItemElement(item, type);
    container.appendChild(itemElement);
  });
}

function toggleClicked(element, type) {
  let selected, selectedList, selectedItem, activeItem;

  if (type == Type.BROTH) {
    selectedList = broths;
    selectedItem = brothsSelected;
  } else {
    selectedList = proteins;
    selectedItem = proteinsSelected;
  }

  selected = selectedList.find(x => x.name.toLowerCase() == element.id);

  if (selectedItem && selectedItem != selected) {
    activeItem = document.getElementById(selectedItem.name.toLowerCase());
    resetItemStyle(activeItem, selectedItem);
  }

  if (element.style.backgroundColor == '') {
    setActiveStyle(element, selected);
    if (type == Type.BROTH) {
      brothsSelected = selected;
    } else {
      proteinsSelected = selected;
    }
  } else {
    resetItemStyle(element, selected);
    if (type == Type.BROTH) {
      brothsSelected = undefined;
    } else {
      proteinsSelected = undefined;
    }
  }

  checkButtonState();
}

function resetItemStyle(item, selected) {
  item.style.backgroundColor = '';
  item.children[0].src = selected.imageInactive;
  item.children[1].style.color = '#1820EF';
  item.children[2].style.color = '#000000';
  item.children[3].style.color = '#FF4E42';
}

function setActiveStyle(item, selected) {
  item.style.backgroundColor = '#1820EF';
  item.children[0].src = selected.imageActive;
  item.children[1].style.color = '#FFFFFF';
  item.children[2].style.color = '#FFFFFF';
  item.children[3].style.color = '#FFC024';
}

function checkButtonState() {
  const button = document.getElementById('placeOrder');
  const buttonText = button.querySelector('span');
  const buttonIcon = button.querySelector('img');

  if (brothsSelected && proteinsSelected) {
    button.disabled = false;
    buttonText.textContent = 'ORDER NOW';
    buttonIcon.src = 'assets/ArrowYellow.svg';
  } else {
    button.disabled = true;
    buttonText.textContent = 'PLACE MY ORDER';
    buttonIcon.src = 'assets/Arrow.svg';
  }
}

function newOrder() {
  const arrowIcon = document.getElementById("arrowIcon");
  const spinnerIcon = document.getElementById("spinnerIcon");

  arrowIcon.style.display = "none";
  spinnerIcon.style.display = "inline-block";

  const myHeaders = new Headers();
  myHeaders.append("x-api-key", apiKey);
  myHeaders.append("Content-Type", "application/json");

  const body = JSON.stringify({
    brothId: brothsSelected.id,
    proteinId: proteinsSelected.id
  });

  const requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: body,
    redirect: "follow"
  };

  fetch(url + "/order", requestOptions)
    .then((response) => response.json())
    .then((result) => {
      arrowIcon.style.display = "inline-block";
      spinnerIcon.style.display = "none";

      orderResult(result)
    })
    .catch((error) => {
      arrowIcon.style.display = "inline-block";
      spinnerIcon.style.display = "none";

      console.log(error)
    }
    );
}

function orderResult(result) {
  console.log(result)
  localStorage.setItem('order', result);
  window.location.href = '/order.html';
}

$(document).ready(function () {
  $('.scroll-link').on('click', function (event) {
    event.preventDefault();
    var target = $(this).attr('href');
    $('html, body').animate({
      scrollTop: $(target).offset().top
    }, 800);
  });
});