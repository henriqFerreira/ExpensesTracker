"use strict";

var AccountAPI = function () {
    var urlIndex = "/Dashboard/Index/";
    var urlSignUp = "/Account/SignUp/";
    var urlSignIn = "/Account/SignIn";

    var _SignInForm = function () {
        var validation;
        var form = document.getElementById("sign-in-form");

        // TODO: Validação dos campos (client-side).

        $('input[name="sign-in-submit"]').on('click', function (e) {
            e.preventDefault();

            var model = {}
            model.Email = $('input[name="email"]').val();
            model.Password = $('input[name="password"]').val();

            $.ajax({
                url: urlSignIn,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(model),
                success: function (data) {

                    // TODO: Tratamento do resultado do request no 'if' abaixo (Sign-in)
                    if (data.Ok) {
                        console.log(data);
                    } else {
                        console.log(data);
                    }
                }
            })
        }) 
    }

    return {
        initSignIn: function () {
            _SignInForm();
        }
    }
}();