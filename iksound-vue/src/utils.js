import corsProxy from "./corsSetting.js";

export const download = (track) => {
    fetch(corsProxy.value + track.stems.full.lqMp3Url)
        .then(response => response.blob())
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = track.isSfx ? track.title : track.title + ' - ' + track.creatives.mainArtists[0].name;
            a.click();
            window.URL.revokeObjectURL(url);
            a.remove();
        });
};
