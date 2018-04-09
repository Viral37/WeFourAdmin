src = "http://code.jquery.com/jquery-1.10.2.min.js"


//For main image 
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img').attr('src', e.target.result);
            $('#Imgthumb').attr('src', e.target.result);
            $('#Imgeout').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#fp1").change(function () {
    readURL(this);
});

//for second Image
function image1(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img1').attr('src', e.target.result);
            $('#Imgthumb1').attr('src', e.target.result);
            $('#Imgeout1').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#fp2").change(function () {
    image1(this);
});


//for third Image
function image2(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img2').attr('src', e.target.result);
            $('#Imgthumb2').attr('src', e.target.result);
            $('#Imgeout2').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#fp3").change(function () {
    image2(this);
});


//for fourth image 
function image3(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img3').attr('src', e.target.result);
            $('#Imgthumb3').attr('src', e.target.result);
            $('#Imgeout3').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#fp4").change(function () {
    image3(this);
});


//for fifth image
function image4(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img4').attr('src', e.target.result);
            $('#Imgthumb4').attr('src', e.target.result);
            $('#Imgeout4').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#fp5").change(function () {
    image4(this);
});

// for image 6

function image5(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img5').attr('src', e.target.result);
            $('#Imgthumb5').attr('src', e.target.result);
            $('#Imgeout5').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#fp6").change(function () {
    image5(this);
});



