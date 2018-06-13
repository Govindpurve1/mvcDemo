function SetChecked(ch) {
  if(document.f.ch[0].checked){ 
    for( i=0 ; i<document.f.ch.length ; i++) {
		if (document.f.ch[i].name==ch) {
		document.f.ch[i].checked=true;
		}
	}}else{
	 for( i=0 ; i<document.f.ch.length ; i++) {
		if (document.f.ch[i].name==ch) {
		document.f.ch[i].checked=false; 
		}  	}}
}
function check1() {
var flag = false;
  for( i=1 ; i<document.f.ch.length ; i++) {
		if (document.f.ch[i].checked) {
		    document.f.ch[0].checked=true;
		    flag = true;
		    break;
		}
	}
  if(!flag){
	   document.f.ch[0].checked=false; 
	}
}
function check() {
var flag = false;
  for( i=1 ; document.f.ch+i.value!=NAN ; i++) {
       alert(document.f.ch+i.value);
		if (document.f.ch+i.checked) {
		    flag = true;
		    break;
		}
	}
  if(!flag){
	   alert("Select any Category"); 
	}
	return flag;
}
	
