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

        Object.keys(fields).forEach(key => {
            var input = $(`input[name="${key}"]`);
            this.validateInput(input, fields[key].validators);
        });

        return "Valid";
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

    notEmpty(input, args) {
        var message = args.message;

        if (!$.trim(input.val()).length) {
            this.addError(input, message);
            return false;
        }
        this.removeError(input);
        return true;
    }

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

    addError(referenceElement, message) {
        if ($(referenceElement).next(".input-error").length === 0) {
            $(`<span class="input-error">${message}</span>`).insertAfter(referenceElement);
        } else {
            $(referenceElement).next().text(message);
        }
    }

    removeError(referenceElement) {
        $(referenceElement).next().remove(".input-error");
    }
}