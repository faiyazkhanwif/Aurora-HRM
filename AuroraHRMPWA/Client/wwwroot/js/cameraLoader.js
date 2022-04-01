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
    const video = document.querySelector('video');
    const mediaStream = video.srcObject;

    if (mediaStream != null) {
        // Through the MediaStream, you can get the MediaStreamTracks with getTracks():
        const tracks = mediaStream.getTracks();
        // Tracks are returned as an array, so if you know you only have one, you can stop it with: 
        tracks[0].stop();
        // Or stop all like so:
        tracks.forEach(track => track.stop());
        video.srcObject = null;
        console.log("Camera off");
    } else {
        console.log("Camera already off");
        location.reload();
    }


}