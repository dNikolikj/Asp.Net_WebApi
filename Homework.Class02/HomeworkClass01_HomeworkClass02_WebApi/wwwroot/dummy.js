let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");
let addUserBtn = document.getElementById("btn3");
let getAllTagsBtn = document.getElementById("btn4");
let getTagByIdBtn = document.getElementById("btn5");
let getByIdInput = document.getElementById("input2");
let addUserInput = document.getElementById("input3");


let port = "5195";
let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/user";

    let response = await fetch(url);
    console.log(response);
    debugger;
    let data = await response.json();
    console.log(data);
};

let getUserById = async () => {
    let url = "http://localhost:" + port + "/api/user/" + getByIdInput.value;
    debugger
    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};


let addUser = async () => {
    let url = "http://localhost:" + port + "/api/user/addUser";
   var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: addNoteInput.value 
   });
   var data = await response.text();
   console.log(data);
}


getAllBtn.addEventListener("click", getAllUsers);
getByIdBtn.addEventListener("click", getUserById);
addUserBtn.addEventListener("click", addUser);