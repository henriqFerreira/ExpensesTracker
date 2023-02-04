"use strict";

var AccountAPI = function () {
    var urlIndex = "/Dashboard/Index/";
    var urlSignUp = "/Account/SignUp/";
    var urlSignIn = "/Account/SignIn";

    var _SignInForm = function () {
        var form = document.getElementById("sign-in-form");

        var validation = new FormValidation(
            form,
            {
                fields: {
                    name: {
                        validators: {
                            notEmpty: {
                                message: "O campo Name é obrigatório."
                            }
                        }
                    },
                    lastname: {
                        validators: {
                            notEmpty: {
                                message: "O campo LastName é obrigatório."
                            }
                        }
                    },
                    email: {
                        validators: {
                            notEmpty: {
                                message: "O campo Email é obrigatório."
                            },
                            regex: {
                                expression: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g,
                                message: "Esse Email não é válido."
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: "O campo Password é obrigatório."
                            }
                        }
                    }
                }
            }
        );

        $('input[name="sign-in-submit"]').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status != "Valid") return false;

                var model = {}
                model.Email = $('input[name="email"]').val();
                model.Password = $('input[name="password"]').val();

                $.ajax({
                    url: urlSignIn,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(model),
                    success: function (data) {

                        // TODO: Tratamento do resultado do request (Sign-in)
                        if (data.Ok) {
                            console.log(data);
                        } else {
                            console.log(data);
                        }
                    }
                });
            });
        });
    }

    var _SignUpForm = function () {
        var form = document.getElementById("sign-up-form");
        var steps = document.querySelectorAll(".form-step");
        var totalSteps = document.querySelectorAll(".form-step").length;
        var currentStep = 0;
        var btnPrev = document.getElementById("btn-prev");
        var btnNext = document.getElementById("btn-next");

        btnPrev.style.display = "none";

        var validation = new FormValidation(
            form,
            {
                fields: {
                    email: {
                        validators: {
                            notEmpty: {
                                message: "O campo Email é obrigatório."
                            },
                            regex: {
                                expression: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g,
                                message: "Esse Email não é válido."
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: "O campo Password é obrigatório."
                            }
                        }
                    }
                }
            }
        );

        $('#btn-prev').on('click', function (e) {
            e.preventDefault();

            if (currentStep > 0) {
                steps[currentStep].classList.remove("active-step");
                currentStep -= 1;
                steps[currentStep].classList.add("active-step");
            }

            if (currentStep <= 0) {
                btnPrev.style.display = "none";
            } else {
                btnPrev.style.display = "block";
            }

            if (currentStep < totalSteps - 1) {
                btnNext.value = "Next";
            } else {
                btnNext.value = "Finish";
            }
        });

        $('#btn-next').on('click', function (e) {
            e.preventDefault();

            if (this.value == "Finish") {
                validation.validate().then(function (status) {
                    if (status != "Valid") return false;

                    var model = {};
                    model.Name = $('input[name="name"]').val();
                    model.LastName = $('input[name="lastname"]').val();
                    model.Email = $('input[name="email"]').val();
                    model.Password = $('input[name="password"]').val();

                    $.ajax({
                        url: urlSignUp,
                        type: 'POST',
                        contentType: 'application/json',
                        data: JSON.stringify(model),
                        success: function (data) {

                            // TODO: Tratamento do resultado do request (Sign-up)
                            if (data.Ok) {
                                console.log(data);
                            } else {
                                console.log(data);
                            }
                        }
                    });
                });
            }

            if (currentStep != totalSteps - 1) {
                steps[currentStep].classList.remove("active-step");
                currentStep += 1;
                steps[currentStep].classList.add("active-step");
            }

            if (currentStep <= 0) {
                btnPrev.style.display = "none";
            } else {
                btnPrev.style.display = "block";
            }

            if (currentStep < totalSteps - 1) {
                btnNext.value = "Next";
            } else {
                btnNext.value = "Finish";
            }
        });
    }

    return {
        initSignIn: function () {
            _SignInForm();
        },
        initSignUp: function () {
            _SignUpForm();
        }
    }
}();