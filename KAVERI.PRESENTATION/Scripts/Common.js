
function OpenPopup(url)
        {
        debugger;
            var width  = 700;
            var height = 500;
            var left   = (screen.width  - width)/2;
            var top    = (screen.height - height)/2;
            var params = 'width='+width+', height='+height;
            params += ', top='+top+', left='+left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=yes';
            params += ', status=yes';
            params += ', toolbar=no';
            newwin=window.open(url,'windowname5', params);
            if (window.focus) {newwin.focus()}
            return false;
        }         

        
function postbackParent(parameter) {
    
        window.opener.__doPostBack('parameter','');
        self.close();
    }
    
function closepopup()
   {
      self.close ();
   }
    
 function ValidText(txtObj)
        {                       
            txtObj.value = txtObj.value.replace(/[^0-9]+/g,'');                 
        }
    
    
function validateCheckBoxes()
        {       
	        var isValid = false;
	        var gridView = document.getElementById('<%= this.gvSearchResult.ClientID %>');
	        alert(gridView);	        
	        for (i=0; i<gridView.rows.length; i++)
                {
                    //get the reference of first column
                    cell = gridView.rows[i].cells[0];
                    alert(gridView.rows[i]);
                    alert(cell);
                    
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox" && cell.childNodes[j].checked)
                        {
                            //assign the status of the Select All checkbox to the cell checkbox within the grid
                            isValid = true;	
					         					        
                        }
                    }
                } 		    	    
		    if(!isValid)
		    {
		        alert("Please select atleast one checkbox to continue");
	            return false;
	        }	        
	    }
	    
	/*    
	function checkFMSDate(sender,args)
    {
        if (sender._selectedDate.setHours(0,0,0,0) < new Date().setHours(0,0,0,0)) 
        {    
            alert('Start'); 
            document.getElementById("<%=lblFMSErrorMsg.ClientID%>").innerHTML = "You cannot select a day earlier than today!";   
            //alert("You cannot select a day earlier than today!");
            sender._selectedDate = new Date(); 
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    */
    /*
    function checkIDMSDate(sender,args)
    {
        if (sender._selectedDate.setHours(0,0,0,0) < new Date().setHours(0,0,0,0)) 
        {     
            document.getElementById("<%=lblIDMSErrorMsg.ClientID%>").innerHTML = "You cannot select a day earlier than today!";   
            //alert("You cannot select a day earlier than today!");
            sender._selectedDate = new Date(); 
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    */
    function checkReleasedDate(sender,args)
    {
        if (sender._selectedDate.setHours(0,0,0,0) < new Date().setHours(0,0,0,0)) 
        {   
            var today = new Date();
            var tomorrow = today.setDate(today.getDate()+1); //today.add(1).day();
            
    
            alert("The Released Date should be greater than Required Date!");
            sender._selectedDate = new Date(tomorrow); 
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    
    function checkOccupationDate(sender,args)
    {
        if (sender._selectedDate.setHours(0,0,0,0) < new Date().setHours(0,0,0,0)) 
        {   
            var today = new Date();
            var tomorrow = today.setDate(today.getDate()+2); //today.add(1).day();
            
    
            alert("The Occupation Date should be minimum two days greater than Request Date!");
            sender._selectedDate = new Date(tomorrow); 
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    
    function ValidateTab4IDMSDateDifference(d1, d2)
    { 
        //alert(document.getElementById(d1).value);    
        var DMY =document.getElementById(d1).value.split('/');     //splits the date string by '/' and stores in a array.    
        
        var DMY1 =document.getElementById(d2).value.split('/');        
        var day= DMY[0];    var month=DMY[1];    var year=DMY[2];    
        var day1= DMY1[0];    var month1=DMY1[1];    var year1=DMY1[2];

        var dateTemp1=new Date(year, (month-1),day);           
        var dateTemp2=new Date(year1, (month1-1),day1);
        
        if (dateTemp1.getTime() > dateTemp2.getTime())
        {
            alert("The Released Date should be greater than Required Date");
           return false;
        }
        else
        {
           return true;
        }        
        return true;
    }
    
    function ValidateTabFMSDateDifference(d1, d2)
    {    //var DMY =d1.value.split('/');     //splits the date string by '/' and stores in a array.        
        //var DMY1 =d2.value.split('/');
        
        var DMY =document.getElementById('wzPositionCreationStart_txtRequestDate').value.split('/');     //splits the date string by '/' and stores in a array.        
        var DMY1 =document.getElementById('wzPositionCreationStart_txtOccupationDate').value.split('/'); 
             
        var day= DMY[0];    var month=DMY[1];    var year=DMY[2];    
        var day1= DMY1[0];    var month1=DMY1[1];    var year1=DMY1[2];

        var dateTemp1=new Date(year, (month-1),day);           
        var dateTemp2=new Date(year1, (month1-1),day1);
        
        if (dateTemp1.getTime() < dateTemp2.getTime())
        {           

            //Check whether RRF Startdate and Enddates are between project startdate and enddate.
            var ProjectdateTemp1 = parseMyDate(document.getElementById('<%= lblProjectStartDate.ClientID %>').innerText);
            var ProjectdateTemp2 = parseMyDate(document.getElementById('<%= lblProjectEndDate.ClientID %>').innerText);
                        
            if ((dateTemp1.getTime() >= ProjectdateTemp1.getTime()) && (dateTemp2.getTime() <= ProjectdateTemp2.getTime()))
            {
                return true;
            }
            else
            {
                //alert("The RRF start date and end date must be between project start date and end date");
                document.getElementById("<%=lblFMSErrorMsg.ClientID%>").innerHTML = "The Request date and occupation date must be between project start date and end date";
                return false;
            }            
        }
        else
        {
           //alert("The Resource Release Date should be greater than Resource Start Date");
           document.getElementById("<%=lblFMSErrorMsg.ClientID%>").innerHTML = "The Resource Release Date should be greater than Resource Start Date";
           return false;
        }        
    }
    
    function parseMyDate(s) 
    {        
        s = new String(s);        
        var m = ['jan','feb','mar','apr','may','jun','jul','aug','sep','oct','nov','dec'];
        var match = s.match(/(\d+)-([^.]+)-(\d+)/);
        //alert(match);
        var date = match[1];
        var monthText = match[2];
        var year = match[3];    
        var month = m.indexOf(monthText.toLowerCase());    
        return new Date(year, month, date);
    }
    
    if (!Array.prototype.indexOf) 
    {   
        Array.prototype.indexOf = function (searchElement /*, fromIndex */ ) 
        {   
            "use strict";   
            if (this == null) 
            {   
                throw new TypeError();   
            }   
            var t = Object(this);   
            var len = t.length >>> 0;   
            if (len === 0) 
            {   
                return -1;   
            }   
            var n = 0;   
            if (arguments.length > 0) 
            {   
                n = Number(arguments[1]);   
                if (n != n) 
                { // shortcut for verifying if it's NaN   
                    n = 0;   
                } else if (n != 0 && n != Infinity && n != -Infinity) 
                {   
                    n = (n > 0 || -1) * Math.floor(Math.abs(n));   
                }   
            }   
            if (n >= len) 
            {   
                return -1;   
            }   
            var k = n >= 0 ? n : Math.max(len - Math.abs(n), 0);   
            for (; k < len; k++) 
            {   
                if (k in t && t[k] === searchElement) 
                {   
                    return k;   
                }   
            }   
            return -1;   
        }   
    }
    
 function ValidateShiftTimingsTest(fromTime,toTime)
 {
    var LfromTime
    var LtoTime
    var LHrsDiff
    var LMinsDiff
    var frmHrs
    var toHrs
    var frmMins
    var toMins
     LfromTime=document.getElementById(fromTime).value;
     LtoTime=document.getElementById(toTime).value;
     var FromTimeArray = LfromTime.split(":");
     var ToTimeArray = LtoTime.split(":");
     frmHrs=FromTimeArray[0];
     frmMins=FromTimeArray[1]
     toHrs=ToTimeArray[0];
     toMins=ToTimeArray[1]
     LHrsDiff=parseFloat(frmHrs)-parseFloat(toHrs)
     LMinsDiff=parseFloat(frmMins)-parseFloat(toMins)
    
    if (parseFloat(LHrsDiff) < 0)
    {
       LHrsDiff=parseFloat(LHrsDiff) * -1;
    }
    else if (parseFloat(LHrsDiff) > 0)
    {
       LHrsDiff=24 - parseFloat(LHrsDiff);
    }
    if (parseFloat(LMinsDiff) > 0)
    {
        LHrsDiff=parseFloat(LHrsDiff)-1;
    }
    else if (parseFloat(LMinsDiff) < 0)
    {
        LMinsDiff=parseFloat(LMinsDiff) *-1;
    }
    if (parseFloat(LHrsDiff) < 1 )
    {
        alert("Shift duration should be minimum one Hour")
        return false
    }
   if ( confirm("You have selected shift duration " + LHrsDiff + " Hrs and " + LMinsDiff + " Mins." + '\n' + " Are you sure to continue!"))
        return true
   else
        return false
    
}

function Visibility(grd,chk)
{
    var TargetBaseControl = document.getElementById(grd); 
    //alert(TargetBaseControl); 
    if(TargetBaseControl!=null)
    {
        var chk = document.getElementById(chk);
        //alert(chk);
        if (chk.checked==true)  
        {  
           TargetBaseControl.style.display = "none";  
        }    
        else  
        {  
           TargetBaseControl.style.display = "block";  
        }
    }
}
