"use strict";

class FormValidation {
    constructor(form, options) {
        this.form = form;
        this.options = options;
    }

    /**
     * Async method that validate all inputs and return a response.
     * */
    async validate() {
        var fields = this.options.fields;
        var validations = [];

        Object.keys(fields).forEach(key => {
            var input = $(`input[name="${key}"]`);
            validations.push({ field: `${key}`, result: this.validateInput(input, fields[key].validators) });
        });

        var result = validations.every(function (element) {
            return element.result;
        })

        return (result) ? "Valid" : "Error";
    }

    /**
     * Validates input using given validations methods.
     * */
    validateInput(input, validations) {
        for (var callback in validations) {

            var result = new FormValidation()[callback](input, validations[callback]);

            if (!result) {
                return false;
            }
        }
        return true;
    }

    /**
     * Validates if input is empty or not.
     * */
    notEmpty(input, args) {
        var message = args.message;

        if (!$.trim(input.val()).length) {
            this.addError(input, message);
            return false;
        }
        this.removeError(input);
        return true;
    }

    /**
     * Validates if input value matches a regular expression.
     * */
    regex(input, args) {
        var regex = new RegExp(args.expression);
        var message = args.message;

        if (!regex.test(input.val())) {
            this.addError(input, message);
            return false;
        }
        this.removeError(input);
        return true;
    }

    /**
     * Add the error message.
     * */
    addError(referenceElement, message) {

        referenceElement[0].classList.add("not-valid");

        if ($(referenceElement).next(".input-error").length === 0) {
            $(`<span class="input-error">${message}</span>`).insertAfter(referenceElement);
        } else {
            $(referenceElement).next().text(message);
        }
    }

    /**
     * Remove the error message.
     * */
    removeError(referenceElement) {
        referenceElement[0].classList.remove("not-valid");
        $(referenceElement).next().remove(".input-error");
    }
}