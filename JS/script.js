let user = 0;
const cookievalue = document.cookie.split("; ").find((row)=> row.startsWith("id="))?.split("=")[1]
console.log(cookievalue)
if(cookievalue != 0 && cookievalue != undefined)
{

user = getplayer(+cookievalue);

GetBank();
}
else{
  window.location.href = "http://127.0.0.1:5500/login.html";
}

  function GB()
  {
    document.cookie = `id= ;expires=${Date.now} Samesite=None; Secure`;
    window.location.href = "http://127.0.0.1:5500/login.html";
  }


  // functions
function GetBank()
{
  let x = document.getElementById('table')
  

  fetch('https://localhost:44331/CentralBank')
  .then(response => {
   
    return response.json().then(data => {
      for (let i = 0; i < 18; i++) {
       x.innerHTML += `
       <tr>
       <td>${data[i].name}</td>
       <td>${data[i].dramtorubl}</td>
       <td>${data[i].rubltodram}</td>
       <td>${data[i].dramtodollar}</td>
       <td>${data[i].dollartodram}</td>
       <td>${data[i].dramtoeuro}</td>
       <td>${data[i].eurotodram}</td>
       </tr>
       `
      }
    });
   
  }).catch(error => {
    console.error(error)
  });
}


function getplayer(id)
{

 
fetch(`https://localhost:44331/User/${id}`)
.then(response =>{return response.json().then(user => {document.getElementById('user').innerHTML += `<p>${user.name} ${user.surname} `; 
document.getElementById("About").innerHTML+=`<p>${user.name} ${user.surname} ${user.age}</p><button onclick="DP()">Exit</button>`})})
.catch(error => console.error(error));


}
function DP()
{
  fetch(`https://localhost:44331/User/${+cookievalue}`, {
  method: 'Delete',
  headers: {
    'Content-Type': 'application/json'
  }
})
.then(response => {
  if (response.ok) {
    document.cookie = `id= ;expires=${Date.now} Samesite=None; Secure`;
    window.location.href = "http://127.0.0.1:5500/login.html";
   
} else {
    console.error('DELETE request failed');
    document.cookie = `id= ;expires=${Date.now} Samesite=None; Secure`;
    window.location.href = "http://127.0.0.1:5500/login.html";
}
}).then(data => console.log(data))
.catch(error => {
  console.error(error)
});
}

