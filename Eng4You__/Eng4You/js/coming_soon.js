// Get today's date and time
var now = new Date().getTime();

// Calculate the future date (30 days, 8 hours, 0 minutes, 0 seconds from now)
var countDownDate = now + (30 * 24 * 60 * 60 * 1000) + (8 * 60 * 60 * 1000);

// Update the countdown every 1 second
var x = setInterval(function () {

    // Get today's date and time
    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = countDownDate - now;

    // Time calculations for days, hours, minutes, and seconds
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // Display the result in the respective elements
    document.getElementById("days").innerText = days.toLocaleString('en-US', { minimumIntegerDigits: 2 });
    document.getElementById("hours").innerText = hours.toLocaleString('en-US', { minimumIntegerDigits: 2 });
    document.getElementById("minutes").innerText = minutes.toLocaleString('en-US', { minimumIntegerDigits: 2 });
    document.getElementById("seconds").innerText = seconds.toLocaleString('en-US', { minimumIntegerDigits: 2 });

    // If the countdown is over, write some text
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("countdown").innerText = "EXPIRED";
    }
}, 1000);