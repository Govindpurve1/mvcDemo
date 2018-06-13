/// <reference path="jquery-form-validation-V.1.js" />

$(document).ready(function () {
    //Login form validation start
    $("#ValidateLogin").validate({
        rules: {

            Loginname: {
                required: true
            },
            Password: {
                required: true,
                minlength: 8
            },
        },
        messages: {

            Password: {
                required: "Please provide a password",
                minlength: "Password at least have 8 characters"
            },
            Loginname: "Please provide user name"
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
    //Login form validation end

    //Registration form validation start
    $("#ValidateRegistration").validate({
        rules: {
            Firstname: { required: true },
            Lastname: { required: true },
            Birthdate: { required: true },
            Hno: { required: true },
            Street: { required: true },
            City: { required: true },
            State: { required: true },
            Country: { required: true },
            Pincode: { required: true },
            ContactNo: { required: true },
            Email: { required: true, email: true },
            Country: { required: true },
            Loginname: {
                required: true
                //email: true ev
            },
            Password: {
                required: true,
                minlength: 8
            },
            Squestionid: { required: true },
            Sanswer: { required: true },
        },
        messages: {

            Firstname: { required: "Please enter first name." },
            Lastname: { required: "Please enter last name." },
            Birthdate: { required: "Please select date of birth." },
            Hno: { required: "Please enter house no." },
            Street: { required: "Please enter street." },
            City: { required: "Please enter city." },
            State: { required: "Please select state." },
            Country: { required: "Please select country." },
            Pincode: { required: "Please enter zipcode." },
            ContactNo: { required: "Please enter phone no." },
            Email: { required: "Please enter a valid email address." },
            Loginname: "Please enter login name.",
            Password: {
                required: "Please provide a password",
                minlength: "Password at least have 8 characters"
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
    //Registration form validation end

    // Admin Create Brand and Edit Brand Start

    $("#CreateBrandformValidation").validate({

        rules: {
            BrandName: { required: true },
            BrandDesc: { required: true },
            file: { required: false }

        },
        messages: {
            BrandName: { required: 'Please enter brand name.' },
            BrandDesc: { required: 'Please enter brand description.' },
            file: { required: 'Please select brand logo.' }

        },
        submitHandler: function (form) {
            form.submit();
        }
    });
    // Admin Create Brand and Edit Brand End

    // Admin Create Category and Edit Category Start

    $("#CreateCategoryformValidation").validate({

        rules: {
            CategoryName: { required: true },
            CategoryDesc: { required: true },
            file: { required: false }

        },
        messages: {
            CategoryName: { required: 'Please enter category name.' },
            CategoryDesc: { required: 'Please enter category description.' },
            file: { required: 'Please select category logo.' }

        },
        submitHandler: function (form) {
            form.submit();
        }
    });
    // Admin Create Category and Edit Category End


    // Admin Create Items and Edit Items Start

    $("#CreateItemsformValidation").validate({

        rules: {
            BrandId: { required: true },
            CategoryId: { required: true },
            ItemName: { required: true },
            ItemDesc: { required: true },
            ItemQuantity: { required: true, number: true, maxlength: 5, },
            ItemPrice: { required: true, number: true, maxlength: 5, },
            file: { required: false }

        },
        messages: {
            BrandId: { required: 'Please select band.' },
            CategoryId: { required: 'Please select category.' },
            ItemName: { required: 'Please enter item name.' },
            ItemDesc: { required: 'Please enter item description.' },
            ItemQuantity: { required: 'Please enter quantity.' },
            ItemPrice: { required: 'Please enter price.' },
            file: { required: 'Please select item logo.' }

        },
        submitHandler: function (form) {
            form.submit();
        }
    });
    // Admin Create Items and Edit Items End

    // Customer Create Feedback validation Start

    $("#feedbackvalid").validate({

        rules: {
            BrandId: { required: true },
            CategoryId: { required: true },
            ItemId: { required: true },
            Feedbackdesc1: { required: true }
        },
        messages: {
            BrandId: { required: 'Please select band.' },
            CategoryId: { required: 'Please select category.' },
            ItemId: { required: 'Please select item name.' },
            Feedbackdesc1: { required: 'Please enter feedback description.' }


        },
        submitHandler: function (form) {

            form.submit();
        }
    });
    // Customer Create Feedback validation End



    // Customer Create query validation Start

    $("#QueryValidation").validate({
        rules: {
            Description: { required: true }
        },
        messages: {

            Description: { required: 'Please enter query description.' }
        },
        submitHandler: function (form) {

            form.submit();
        }
    });
    // Customer Create query validation End

    // Customer Create Cardit validation Start

    $("#ccform").validate({
        rules: {
            Type: { required: true },
            CcNumber: { required: true, creditcard: true },
            CName: { required: true },
            Exp: { required: true },
            Cvv: { required: true, number: true },
            Street: { required: true },
            CityID: { required: true },
            StateID: { required: true },
            CountryID: { required: true },
            Zipcode: { required: true,number:true }
        },
        messages: {
            Type: { required: 'Please select cartd.' },
            CcNumber: { required: 'Please enter cartd number.' },
            CName: { required: 'Please enter card name.' },
            Exp: { required: 'Please enter expiry date.' },
            Cvv: { required: 'Please enter cvv number.' },
            Street: { required: 'Please enter street.' },
            CityID: { required: 'Please enter city.' },
            StateID: { required: 'Please enter state.' },
            CountryID: { required: 'Please enter country.' },
            Zipcode: { required: 'Please enter zip code.' }

        },
        submitHandler: function (form) {

            form.submit();
        }
    });
    // Customer Create Cardit validation End


});
