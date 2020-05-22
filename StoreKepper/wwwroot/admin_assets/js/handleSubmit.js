$(document).ready(function () {
    $("#createMerchant").click(function (e) {
        e.preventDefault();
        var inputName = $("inputName").val();
        var inputEmail = $("inputEmail").val();
        var inputAcctno = $("inputAcctNo").val();
        var inputPhone = $("inputPhone").val();
        var inputAddress = $("inputAddress").val();
        var inputUrl = $("inputUrl").val();
        if (inputAcctno.length < 10) {
            alert("Account number is less than 10 digits...");
            return false;
        }
        if (inputPhone.length < 11) {
            alert("Phone number is less than 11 digits...");
            return false;
        }
        var ob = { "Name": inputName, "EmailAddress": inputEmail, "PhoneNo": inputPhone, "Address": inputAddress, "AccountNo": inputAcctno, "Url": inputUrl };
        var obj = JSON.stringify(ob);
        alert(obj);
        //ajax({
        //    url:"/business/Create",
        //    type: "POST",
        //    data: obj,
        //    cache: false,
        //    crossDomain: true,
        //    success: function (data) {
        //        if (data) {
        //            alert("Merchant created Successfully");
        //            window.location.href = '/business/index';
        //        }
        //    }
        //});

    });
});