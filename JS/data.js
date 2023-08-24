
const cookievalue = document.cookie.split("; ").find((row)=> row.startsWith("id="))?.split("=")[1]
let istrue = false;
console.log(cookievalue)
if(cookievalue != 0 && cookievalue != undefined)
{
  window.location.href = "http://127.0.0.1:5500/index.html";
}


function loguser()
{
  if(istrue)
  {
document.getElementById("res").remove();
  }
  let email = document.getElementById('em').value;
  let password = document.getElementById('pa').value;
  fetch(`https://localhost:44331/User/${email},${password}`,
   {
    
 
    
  })
  .then(response => {
    if (response.ok) {
     
 
 return response.json().then(z =>{ 
  document.cookie = `id=${z.ids}; Samesite=None; Secure`;
window.location.href = "http://127.0.0.1:5500/index.html";})


  }  else if (response.status === 400) {
    return response.json().then(error => {
      if(error.errorMessage == "email")
      {
        document.getElementById('email').innerHTML += `<figcaption id="res">not right email</figcaption>`
       
      }
      else{
        document.getElementById('password').innerHTML += `<figcaption id="res">not right password</figcaption>`
      }
      istrue = true;
  });
    }

    
  else {
    console.error(response.json());
  }})
 
  .catch(error => {
    console.error(error)
  });
}
function adduser()
{
  
  const b = {id:0,
  Name:document.getElementById('n').value,
  Surname:document.getElementById('s').value,
  email:document.getElementById('e').value,
  Password:document.getElementById('p').value,
  Age:+document.getElementById('a').value,
}
  fetch('https://localhost:44331/User/user', {
    method: 'Post',
    headers: {
      'Content-Type': 'application/json'
    },
    
    body: JSON.stringify(b)
  })
  .then(response => {
    if (response.ok) {
     
 
 return response.json().then(z =>{ 
  document.cookie = `id=${z.ids}; Samesite=None; Secure`;
window.location.href = "http://127.0.0.1:5500/index.html";})

  } 

    
  else {
    console.error(response.json());
  }})
 
  .catch(error => {
    console.error(error)
  });
}

function getplayers()
{

  
fetch('https://localhost:44331/CentralBank')
.then(response => response.json())
.then(data => { document.getElementById('b').innerHTML = data.name; console.log(data)})
.catch(error => console.error(error));


}
