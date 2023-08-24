let circle = document.getElementById("img");
let circle2 = document.getElementById("imag");
let pos = false;
let position = false;
let px = 0;
let lpx = 0;
const move = (e) => {

    
   let z = innerWidth / 2000;
 if(e.pageX >= lpx && position == false)
 {
position == true
px = e.pageX
 }
 else if(e.pageX <= lpx && position == true)
 {
position == false
px = e.pageX
 }
  
 if(Math.abs(e.pageX - px) <= 400){
    circle.style.left= (Math.abs(e.pageX-px))*z +'px';

 }
lpx = e.pageX
// else{

 
  
  //circle2.style.left = innerWidth - e.pageX +'px';
  //circle2.style.top =  innerHeight - e.pageY +'px';
 //}
}

document.addEventListener("mousemove",move);
