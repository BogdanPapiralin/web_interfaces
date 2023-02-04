window.onload = function(){
    slideOne(0);
    slideTwo(0);
    slideOne(1);
    slideTwo(1);
}
let firstSlider, secondSlider;
let minGap = 5;
let sliderTrack = document.getElementsByClassName("slider-track");
let sliderMaxValue = 0;
function slideOne(number){
    if(number==0){ 
        firstSlider = document.getElementById("PriceSlider-1");
        secondSlider = document.getElementById("PriceSlider-2");
        sliderMaxValue = document.getElementById("PriceSlider-1").max;
    }
    else{ 
        firstSlider = document.getElementById("PagesSlider-1");
        secondSlider = document.getElementById("PagesSlider-2");
        sliderMaxValue = document.getElementById("PagesSlider-1").max;
    }
    minGap = Math.floor(sliderMaxValue/10);
    if(parseInt(secondSlider.value) - parseInt(firstSlider.value) <= minGap){

        firstSlider.value = parseInt(secondSlider.value) - minGap;
        }
    
    if(number==0) document.getElementById("minPrice").textContent = firstSlider.value + "$";
    else document.getElementById("minPages").textContent = firstSlider.value;
    fillColor(number);
}
function slideTwo(number){
    if(number==0){ 
        firstSlider = document.getElementById("PriceSlider-1");
        secondSlider = document.getElementById("PriceSlider-2");
        sliderMaxValue = document.getElementById("PriceSlider-1").max;
    }
    else{ 
        firstSlider = document.getElementById("PagesSlider-1");
        secondSlider = document.getElementById("PagesSlider-2");
        sliderMaxValue = document.getElementById("PagesSlider-1").max;
    }
    minGap =  Math.floor(sliderMaxValue/10);
    if(parseInt(secondSlider.value) - parseInt(firstSlider.value) <= minGap)  secondSlider.value = parseInt(firstSlider.value) + minGap;
    
    if(number==0) document.getElementById("maxPrice").textContent = secondSlider.value + "$";
    else document.getElementById("maxPages").textContent = secondSlider.value;
  
    fillColor(number);
}
function fillColor(number){
    percent1 = ( parseInt(firstSlider.value) / sliderMaxValue) * 100;
    percent2 = (parseInt(secondSlider.value) / sliderMaxValue) * 100;
    sliderTrack[number].style.background = `linear-gradient(to right, rgb(198,194,191) ${percent1}% , rgb(153,136,126) ${percent1}% , rgb(153,136,126) ${percent2}%,  rgb(198,194,191) ${percent2}%)`;
}