var interval;

window.togglePlay = function (id) {
    let audio = document.getElementById("audio-" + id);
    let play = document.getElementById("play-" + id);
    let pause = document.getElementById("pause-" + id);

    if (audio.paused) {
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
            let audio = document.getElementById("audio-" + id);
            let play = document.getElementById("play-" + id);
            let pause = document.getElementById("pause-" + id);
            let playhead = document.getElementById("playhead-" + id);

            if (audio === null || audio.ended) {
                if(play !== null && pause !== null) {
                    play.hidden = false;
                    pause.hidden = true;
                }
                clearInterval(interval);
            }

            let percentage = (audio.currentTime / audio.duration) * 100;
            playhead.style.left = percentage + "%";
            playhead.style.display = 'block';
        }, 20, id);
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