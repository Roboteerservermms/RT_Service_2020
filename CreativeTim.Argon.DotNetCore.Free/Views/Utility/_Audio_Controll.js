import noUiSlider from 'nouislider';

var resultElement = document.getElementById('_AudioControll');
var sliders = document.getElementsByClassName('sliders');
var audio = [0, 0, 0];

[].slice.call(sliders).forEach(function (slider, index) {

    noUiSlider.create(slider, {
        start: 127,
        connect: [true, false],
        orientation: "vertical",
        range: {
            'min': 0,
            'max': 255
        },
        format: wNumb({
            decimals: 0
        })
    });

    // Bind the audio changing function to the update event.
    slider.noUiSlider.on('update', function () {

        audio[index] = slider.noUiSlider.get();

        var audio = 'audio(' + audios.join(',') + ')';

        resultElement.style.background = audio;
        resultElement.style.audio = audio;
    });
});