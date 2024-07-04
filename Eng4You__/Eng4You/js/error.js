const flickerFire = 1;

const flicker = () => {
    if (!flickerFire) return false;

    gsap.to(".filtered, .error-demo", {
        duration: 2,
        className: "+=glowing",
        opacity: 1,
        ease: RoughEase.ease.config({
            template: Power0.easeNone, 
            strength: 100,
            points: 20,
            taper: 'none',
            randomize: true,
            clamp: true
        }),
        repeat: 1,
        yoyo: true,
        onComplete: flicker
    });
};

flicker();