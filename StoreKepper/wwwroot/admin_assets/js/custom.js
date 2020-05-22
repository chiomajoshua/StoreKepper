/// <reference path="../modules/jquery.min.js" />
/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 * 
 */

"use strict";

function validateName(name) {
    var lblNameError = document.getElementById("lblNameError");
    var lblNameCorrect = document.getElementById("lblNameCorrect");
    lblNameError.innerHTML = "";
    lblNameCorrect.innerHTML = "";
    if (name.value === "") {
        name.style.borderColor = 'red';
        //lblNameError.innerHTML = "Enter Merchant Name....";
        return false;
    } else {
        name.style.borderColor = '';
        lblNameCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateEmailID(emailID) {
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    var lblError = document.getElementById("lblError");
    var lblCorrect = document.getElementById("lblCorrect");
    lblError.innerHTML = "";
    lblCorrect.innerHTML = "";
    if (emailID.value === "") {
        emailID.style.borderColor = 'red';
        //lblError.innerHTML = `<i class="fa fa-times"></i>`;
        return false;
    }
    else if (expr.test(emailID.value)) {
        emailID.style.border = '';
        lblCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
    else {
        emailID.style.borderColor = "red";
        //lblError.innerHTML = "Invalid Email Address";
        return false;
    }
}

function validateAccountNo(acctNo) {
    var expr = /^[0-9]+$/;
    var minLen = 10;
    var maxLen = 14;
    var lblAcctNoError = document.getElementById("lblAcctNoError");
    var lblAcctNoCorrect = document.getElementById("lblAcctNoCorrect");
    lblAcctNoError.innerHTML = "";
    lblAcctNoCorrect.innerHTML = "";
    if (acctNo.value.length < minLen || acctNo.value.length > maxLen) {
        acctNo.style.borderColor = 'red';
        //lblAcctNoError.innerHTML = "Account Number length is incorrect...";
        return false;
    }    else {        
        if (acctNo.value.match(expr)) {
            acctNo.style.borderColor = '';  
            lblAcctNoCorrect.innerHTML = `<i class="fa fa-check"></i>`;
            return true;
        } else {
            acctNo.style.borderColor = 'red';
            //lblAcctNoError.innerHTML = "Account Number must be digit";
            return false;
        }        
    }
}

function validatePhoneNo(phnNo) {
    var expr = /^\d{11}$/;
    var lblPhnNoError = document.getElementById("lblPhnNoError");
    var lblPhnNoCorrect = document.getElementById("lblPhnNoCorrect");
    lblPhnNoError.innerHTML = "";
    lblPhnNoCorrect.innerHTML = "";
    if (phnNo.value.match(expr)) {
        phnNo.style.borderColor = '';
        lblPhnNoCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    } else {
        phnNo.style.borderColor = 'red';
        //lblPhnNoError.innerHTML = "Phone Number must be 11 digits....";
        return false;
    }
    
}

function validateAddress(address) {
    var lblAddressError = document.getElementById("lblAddressError");
    var lblAddressCorrect = document.getElementById("lblAddressCorrect");
    lblAddressError.innerHTML = "";
    lblAddressCorrect.innerHTML = "";
    if (address.value === "") {
        address.style.borderColor = 'red';
        //lblAddressError.innerHTML = "Enter Merchant Address....";
        return false;
    } else {
        address.style.borderColor = '';
        lblAddressCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateURL(url) {
    //var expr = /^(?:(?:https?|ftp):\/\/)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/\S*)?$/;
    var expr = /^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/;
    var lblURLError = document.getElementById("lblURLError");
    var lblURLCorrect = document.getElementById("lblURLCorrect");
    lblURLError.innerHTML = "";
    lblURLCorrect.innerHTML = "";
    if (url.value === "") {
        url.style.borderColor = 'red';
        //lblURLError.innerHTML = "Enter Merchant URL....";
        return false;
    } else if (expr.test(url.value)) {
        url.style.border = "";
        lblURLCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
    else if (!expr.test(url.value)) {
        url.style.borderColor = 'red';
        //lblURLError.innerHTML = "Invalid Merchant URL.....";
        return false;
    }
}

function validateURLToolTip(urlToolTip) {
    var lblURLToolTip = document.getElementById("lblURLToolTip");
    lblURLToolTip.innerHTML = "";
    if (urlToolTip.value === "") {
        lblURLToolTip.innerHTML = "URL should begin with http:// or https://";
    }
}



function validateCode(code) {
    var lblCodeError = document.getElementById("lblCodeError");
    var lblCodeCorrect = document.getElementById("lblCodeCorrect");
    lblCodeError.innerHTML = "";
    lblCodeCorrect.innerHTML = "";
    if (code.value === "") {
        code.style.borderColor = 'red';
        //lblCodeError.innerHTML = "Required";
        return false;
    } else {
        code.style.borderColor = '';
        lblCodeCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateTitle(title) {
    var lblTitleError = document.getElementById("lblTitleError");
    var lblTitleCorrect = document.getElementById("lblTitleCorrect");
    lblTitleError.innerHTML = "";
    lblTitleCorrect.innerHTML = "";
    if (title.value === "") {
        title.style.borderColor = 'red';
        //lblTitleError.innerHTML = "Required";
        return false;
    } else {
        title.style.borderColor = '';
        lblTitleCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateServiceCharge(sc) {
    var expr = /\d+(\.\d{1,2})?/;
    var lblSCError = document.getElementById("lblSCError");
    var lblSCCorrect = document.getElementById("lblSCCorrect");
    lblSCError.innerHTML = "";
    lblSCCorrect.innerHTML = "";
    if (sc.value === "") {
        sc.style.borderColor = 'red';
        //lblSCError.innerHTML = "Required";
        return false;
    } else if (sc.value.match(expr)) {
        sc.style.borderColor = '';
        lblSCCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    } else {
        sc.style.borderColor = 'red';
        //lblSCError.innerHTML = "Must be digit";
        return false;
    }
}

function validateDiscount(discount) {
    var expr = /\d+(\.\d{1,2})?/;
    var lblDiscountError = document.getElementById("lblDiscountError");
    var lblDiscountCorrect = document.getElementById("lblDiscountCorrect");
    lblDiscountError.innerHTML = "";
    lblDiscountCorrect.innerHTML = "";    
    if (discount.value ==="") {
        sc.style.borderColor = 'red';
        //lblDiscountError.innerHTML = "Required";
        return false;
    } else if (discount.value.match(expr)) {
        discount.style.borderColor = '';
        lblDiscountCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    } else {
        discount.style.borderColor = 'red';
        //lblDiscountError.innerHTML = "Discount must be digit...";
        return false;
    }
    
}

function validateMaxDiscount(max) {
    var expr = /\d+(\.\d{1,2})?/;
    var lblMaxDisError = document.getElementById("lblMaxDisError");
    var lblMaxDisCorrect = document.getElementById("lblMaxDisCorrect");
    lblMaxDisError.innerHTML = "";
    lblMaxDisCorrect.innerHTML = "";
    if (max.value === "") {
        sc.style.borderColor = 'red';
        //lblMaxDisError.innerHTML = "Required";
        return false;
    } else if (max.value.match(expr)) {
        max.style.borderColor = '';
        lblMaxDisCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    } else {
        max.style.borderColor = 'red';
        //lblMaxDisError.innerHTML = "Must be digit...";
        return false;
    }

}

function validateMinDiscount(min) {
    var expr = /\d+(\.\d{1,2})?/;
    var lblMinDisError = document.getElementById("lblMinDisError");
    var lblMinDisCorrect = document.getElementById("lblMinDisCorrect");
    lblMinDisError.innerHTML = "";
    lblMinDisCorrect.innerHTML = "";
    if (min.value === "") {
        min.style.borderColor = 'red';
        //lblMinDisError.innerHTML = "Required";
        return false;
    } else if (min.value.match(expr)) {
        min.style.borderColor = '';
        lblMinDisCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    } else {
        min.style.borderColor = 'red';
        //lblDiscountError.innerHTML = "Must be digit...";
        return false;
    }

}

//validation for school section
function validateSchoolName(name) {
    var lblSchoolNameError = document.getElementById("lblSchoolNameError");
    var lblSchoolNameCorrect = document.getElementById("lblSchoolNameCorrect");
    lblSchoolNameError.innerHTML = "";
    lblSchoolNameCorrect.innerHTML = "";
    if (name.value === "") {
        name.style.borderColor = 'red';
        //lblSchoolNameError.innerHTML = "Enter School Name....";
        return false;
    } else {
        name.style.borderColor = '';
        lblSchoolNameCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateServiceName(name) {
    var lblServiceNameError = document.getElementById("lblServiceNameError");
    var lblServiceNameCorrect = document.getElementById("lblServiceNameCorrect");
    lblServiceNameError.innerHTML = "";
    lblServiceNameCorrect.innerHTML = "";
    if (name.value === "") {
        name.style.borderColor = 'red';
        //lblServiceNameError.innerHTML = "Enter Endpoint Service Name....";
        return false;
    } else {
        name.style.borderColor = '';
        lblServiceNameCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateServiceURL(name) {
    var lblServiceURLError = document.getElementById("lblServiceURLError");
    var lblServiceURLCorrect = document.getElementById("lblServiceNameCorrect");
    lblServiceURLError.innerHTML = "";
    lblServiceURLCorrect.innerHTML = "";
    if (name.value === "") {
        name.style.borderColor = 'red';
        //lblServiceURLError.innerHTML = "Enter Endpoint Service URL....";
        return false;
    } else {
        name.style.borderColor = '';
        lblServiceURLCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function validateContactName(name) {
    var lblContactNameError = document.getElementById("lblContactNameError");
    var lblContactNameCorrect = document.getElementById("lblContactNameCorrect");
    lblContactNameError.innerHTML = "";
    lblContactNameCorrect.innerHTML = "";
    if (name.value === "") {
        name.style.borderColor = 'red';
        //lblContactNameError.innerHTML = "Enter Contact Name....";
        return false;
    } else {
        name.style.borderColor = '';
        lblContactNameCorrect.innerHTML = `<i class="fa fa-check"></i>`;
        return true;
    }
}

function ShowPreview(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            $('#preview').attr('src', e.target.result);
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}

function validAccountNo(accountNo){        
    var actNo = accountNo.value
    var _data = { acctNo:actNo};
    $.ajax({
        url: "/business/VerifyAccount",
        data: _data,
        dataType: "json",
        type: "POST",
        crossDomain: true,
        success: function (data) {
            if (data) {
                alert("Account number is correct!!");
            } else {
                alert("Invalid account number!!!");
            }
        }
    });    
}

function AddServiceChargeICon(serviceType) {
    var serviceTYPE = serviceType.value;  
    var lblSCCorrect = document.getElementById("lblSCCorrect"); 
    lblSCCorrect.innerHTML = "";
    if (serviceTYPE === 1) {  
        lblSCCorrect.innerHTML = `<i class="">&#8358;</i>`;
    } else {
        lblSCCorrect.innerHTML = `<i class="">&#37;</i>`;        
    }

}
  




