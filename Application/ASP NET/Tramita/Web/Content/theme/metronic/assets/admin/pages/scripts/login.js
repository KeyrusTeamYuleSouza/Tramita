
var Login = function () {

    var handleLogin = function () {

        $('.login-form').validate({

            errorElement: 'span',

            errorClass: 'help-block',

            focusInvalid: false,

            rules: {
                username: {
                    required: true,
                    number: true,
                    minlength: 9,
                    remote: {
                        url: "/Login/GetUserByCPF/",
                        type: "POST",
                        data: {
                            key: function () {
                                return $("#username").val();
                            }
                        }
                    }
                },
                password: {
                    required: true
                },
                remember: {
                    required: false
                }
            },

            messages: {
                username: {
                    required: "Informe seu cpf",
                    number: "Formato invalido",
                    minlength: "CPF deve conter ao menos 9 caracteres",
                    remote: "Usuario nao encontrado"
                },
                password: {
                    required: "Informe a senha.",
                    remote: "Senha invalida"
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
                $('.alert-danger', $('.login-form')).show();
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                error.insertAfter(element.closest('.input-icon'));
            },

            submitHandler: function (form) {
                form.submit();
            }
        });

        $('.login-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.login-form').validate().form()) {
                    $('.login-form').submit();
                }
                return false;
            }
        });
    }

    var handleForgetPassword = function () {
        $('.forget-form').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                email: {
                    required: true,
                    email: true,
                    remote: {
                        url: "/Login/GetEmailByKey/",
                        type: "POST",
                        data: {
                            key: function () {
                                return $("#email").val();
                            }
                        }
                    }
                }
            },

            messages: {
                email: {
                    required: "Informe o e-mail.",
                    email: "Informe um e-mail valido",
                    remote: "E-mail nao encontrado"
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   

            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                error.insertAfter(element.closest('.input-icon'));
            },

            submitHandler: function (form) {
                form.submit();
            }
        });

        $('.forget-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.forget-form').validate().form()) {
                    $('.forget-form').submit();
                }
                return false;
            }
        });

        jQuery('#forget-password').click(function () {
            jQuery('.login-form').hide();
            jQuery('.forget-form').show();
        });

        jQuery('#back-btn').click(function () {
            jQuery('.login-form').show();
            jQuery('.forget-form').hide();
        });
    }

    var handleRegister = function () {

        function format(state) {
            if (!state.id) return state.text; // optgroup
            return "<img class='flag' src='../../assets/global/img/flags/" + state.id.toLowerCase() + ".png'/>&nbsp;&nbsp;" + state.text;
        }

        if (jQuery().select2) {
            $("#select2_sample4").select2({
                placeholder: '<i class="fa fa-map-marker"></i>&nbsp;Select a Country',
                allowClear: true,
                formatResult: format,
                formatSelection: format,
                escapeMarkup: function (m) {
                    return m;
                }
            });

            $('#select2_sample4').change(function () {
                $('.register-form').validate().element($(this)); //revalidate the chosen dropdown value and show error or success message for the input
            });
        }

        $('.register-form').validate({

            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {

                cpf: {
                    required: true,
                    number: true,
                    minlength: 8,
                    remote: {
                        url: "/Login/GetUserRegisterByCPF/",
                        type: "POST",
                        data: {
                            key: function () {
                                return $("#cpf").val();
                            }
                        }
                    }
                },

                registerpassword: {
                    required: true
                },

                rpassword: {
                    equalTo: "#register_password"
                },

                tnc: {
                    required: true
                }
            },

            messages: {

                cpf: {
                    required: "Informe seu CPF",
                    number: "Formato invalido",
                    minlength: "CPF deve conter no minimo 8 digitos",
                    remote: "Este CPF ja esta ativo no sistema"
                },

                registerpassword: {
                    required: "Informe a senha"
                },

                rpassword: {
                    equalTo: "Informe a mesma senha"
                },

                tnc: {
                    required: "Aceite or termos de uso."
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   

            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
                label.remove();
            },

            errorPlacement: function (error, element) {
                if (element.attr("name") == "tnc") { // insert checkbox errors after the container                  
                    error.insertAfter($('#register_tnc_error'));
                } else if (element.closest('.input-icon').size() === 1) {
                    error.insertAfter(element.closest('.input-icon'));
                } else {
                    error.insertAfter(element);
                }
            },

            submitHandler: function (form) {
                $.ajax({
                    type: "POST",
                    url: "/Login/RegisterUser/",
                    data: {
                        username: function () {
                            return $("#cpf").val();
                        },

                        password: function () {
                            return $("#register_password").val();
                        }
                    },
                    success: function (data) {

                    }
                });
            }
        });

        $('.register-form input').keypress(function (e) {
            if (e.which == 13) {
                if ($('.register-form').validate().form()) {
                    $('.register-form').submit();
                }
                return false;
            }
        });

        jQuery('#register-btn').click(function () {
            jQuery('.login-form').hide();
            jQuery('.register-form').show();
        });

        jQuery('#register-back-btn').click(function () {
            jQuery('.login-form').show();
            jQuery('.register-form').hide();
        });
    }

    return {
        init: function () {
            handleLogin();
            handleForgetPassword();
            handleRegister();
        }
    };
}();

