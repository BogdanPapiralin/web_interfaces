let currentPanel = 0 
let panelNames = ["MainPanel", "AddBook", "EditAssortment", "SeeAssortment"]
function ChangePanel(number){
    if(number!=currentPanel){
        document.getElementById(panelNames[currentPanel]).style.display="none";
        currentPanel = number;
        document.getElementById(panelNames[currentPanel]).style.display="block";
    }
}
