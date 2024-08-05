var interval;

window.togglePlay = function (id) {
    let audio = document.getElementById("audio-" + id);
    let play = document.getElementById("play-" + id);
    let pause = document.getElementById("pause-" + id);

    if (audio.paused) {
        playAudio(id, audio, play, pause);
    } else {
        audio.pause();
        play.hidden = false;
        pause.hidden = true;

        clearInterval(interval);
    }
}

window.revealButtons = function (id) {
    let audio = document.getElementById("audio-" + id);
    let play = document.getElementById("play-" + id);
    let pause = document.getElementById("pause-" + id);

    if (audio.paused) {
        play.hidden = false;
        pause.hidden = true;
    } else {
        play.hidden = true;
        pause.hidden = false;
    }
}

window.hideButtons = function (id) {
    let play = document.getElementById("play-" + id);
    let pause = document.getElementById("pause-" + id);

    play.hidden = true;
    pause.hidden = true;
}

window.manageWaveformClick = async function(event, div, id){
    let audio = document.getElementById("audio-" + id);

    audio.load()
    // Ensure the audio metadata is loaded before proceeding
    if (audio.readyState < 1) {
        await new Promise(resolve => {
            audio.addEventListener('loadedmetadata', resolve, { once: true });
        });
    }

    // get mouse position relative to the waveform div    
    let rect = div.getBoundingClientRect();
    let x = event.clientX - rect.left;
    let width = div.offsetWidth;
    let percentage = x / width;
    let time = percentage * audio.duration;

    if(!Number.isNaN(time))
        playAt(audio, id, time);
}

const playAt = function (audio, id, time){
    let play = document.getElementById("play-" + id);
    let pause = document.getElementById("pause-" + id);

    audio.pause();
    audio.currentTime = time;
    
    playAudio(id, audio, play, pause);
}

const playAudio = function (id, audio, play, pause) {
    // Stop all other audio from playing
    clearInterval(interval);
    document.querySelectorAll('audio').forEach(el => {
        if (el.id !== audio.id) {
            el.pause()
            el.currentTime = 0

            el.previousElementSibling.style.left = '0';
            el.previousElementSibling.style.display = 'none';
        }
    });

    audio.play();
    play.hidden = true;
    pause.hidden = false;

    interval = setInterval((id) => {
        let playhead = document.getElementById("playhead-" + id);

        if (audio === null || audio.ended || playhead === null) {
            if(play !== null && pause !== null && !pause.hidden) {
                play.hidden = false;
                pause.hidden = true;
            }
            clearInterval(interval);
            return;
        }

        let percentage = (audio.currentTime / audio.duration) * 100;
        playhead.style.left = percentage + "%";
        playhead.style.display = 'block';
    }, 20, id);
}