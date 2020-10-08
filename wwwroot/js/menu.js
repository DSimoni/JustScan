$('.tab1').click(function () {
    debugger;
    $('.pizza1').css('display', 'block');
    $('.pasta1').css('display', 'none');
    $('.starter1').css('display', 'none');
});
$('.tab2').click(function () {
    debugger;
    $('.pasta1').css('display', 'block')
    $('.starter1').css('display', 'none');
    $('.pizza1').css('display', 'none');

});
$('.tab3').click(function () {
    $('.starter1').css('display', 'block')
    $('.pizza1').css('display', 'none');
    $('.pasta1').css('display', 'none');
});