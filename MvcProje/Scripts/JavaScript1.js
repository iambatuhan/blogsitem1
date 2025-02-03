// JavaScript for scrolling the timeline horizontally

const timeline = document.querySelector('.timeline');
const timelineItems = document.querySelectorAll('.timeline-item');

let scrollAmount = 0;

document.getElementById('scroll-right').addEventListener('click', () => {
    scrollAmount += 200; // Adjust scroll amount as needed
    timeline.scrollTo({
        top: 0,
        left: scrollAmount,
        behavior: 'smooth'
    });
});

document.getElementById('scroll-left').addEventListener('click', () => {
    scrollAmount -= 200; // Adjust scroll amount as needed
    timeline.scrollTo({
        top: 0,
        left: scrollAmount,
        behavior: 'smooth'
    });
});
