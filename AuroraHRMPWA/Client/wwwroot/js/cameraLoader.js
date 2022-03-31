function loadCamera() {
    var video = document.getElementById('video');

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
            try {
                video.srcObject = stream;
            } catch (error) {
                video.src = window.URL.createObjectURL(stream);
            }
            video.play();
        });
    }
}

function offloadCamera() {
    var video = document.getElementById('video');
    video.pause();
    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
            stream.getTracks().forEach(function (track) {
                track.stop();
                track.enabled = false;
            });
            video.srcObject = null;
        });
    }
    console.log("Camera off");

}