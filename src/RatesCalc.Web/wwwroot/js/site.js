// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function calculateInterestRate() {
    var agreementId = $('input[name="AgreementRadioButton"]:checked').val();
    var baseRateCode = $(`[data-agreement-id="${agreementId}"]`).val();
    var objData = { AgreementId: parseInt(agreementId, 10), BaseRateCode: baseRateCode };
    console.log(agreementId);
    console.log(baseRateCode);
    $.ajax({
        type: "POST",
        url: '/Customer/CalculateInterestRate',
        contentType: "application/json",
        data: JSON.stringify(objData),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
    }).done(function (data) {
        $('#calculated-results').html(`<h5>Calculated Rates:</h5>` +
            `<h6>Existing interest rate is:${data['existingInteresRate']}</h6>` +
            `<h6>Calculated interest rate is: ${data['calculatedInteresRate']}</h6>` +
            `<h6>Difference: ${(data['calculatedInteresRate'] - data['existingInteresRate']).toFixed(2)}</h6>`);
    })
}