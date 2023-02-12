"use strict";

class Alert {
    show(type, title, description) {
        var body = document.body;
        var svg = this.getSvg(type);
        var html = `
            <div class="alert">
                <a class="close-icon" onclick="$(this).closest('.alert').remove()">
                    <span></span>
                </a>
                <div class="alert-icon">
                    ${svg}
                </div>
                <h2 class="alert-title">${title}</h2>
                <p class="alert-description">${description}</p>
            </div>
        `;

        $(body).append(html);
    }

    getSvg(type) {
        switch (type) {
            case "Warning":
                return `<svg width="100" height="100" viewBox="0 0 100 100" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <style>
                        svg { overflow: visible; }
                        #i-circle { stroke-dasharray: 306; stroke-dashoffset: 306; animation: draw-circle .7s ease-in-out forwards; }
                        #i-icon { animation: animate-icon .4s 0.2s ease-in-out forwards; }
                        @keyframes draw-circle { to { stroke-dashoffset: 0; } }
                        @keyframes animate-icon {
                            0% { transform: translateX(0); }
                            20% { transform: translateX(5px); }
                            40% { transform: translateX(-5px); }
                            60% { transform: translateX(5px); }
                            80% { transform: translateX(-5px); }
                            100% { trasnform: translateX(0); }
                        }
                    </style>
                    <path id="i-circle" d="M47.9398 3.94845C48.4882 2.86796 49.3196 2.5 50 2.5C50.6804 2.5 51.5118 2.86796 52.0602 3.94845L97.0998 92.6808C97.6664 93.7971 97.5993 95.0675 97.0998 96.0516C96.6016 97.033 95.8205 97.5 95.0395 97.5H4.96045C4.1795 97.5 3.39838 97.0329 2.90023 96.0516C2.40074 95.0675 2.33363 93.7971 2.90024 92.6808L47.9398 3.94845Z" stroke="#FDFD96" stroke-width="5" />
                    <path id="i-icon" d="M49 45.4429C53.0298 45.2246 55.5 42.6507 55.5 39.479C55.5 36.1627 52.7995 33.5 49.5 33.5C46.2005 33.5 43.5 36.1627 43.5 39.479C43.5 42.6507 45.9702 45.2246 49.0721 45.4429C45.9702 45.6613 43.5 48.2352 43.5 51.4069V81.521C43.5 84.8373 46.2005 87.5 49.5 87.5C52.7995 87.5 55.5 84.8373 55.5 81.521V51.4069C55.5 48.2352 53.0298 45.6613 49.9279 45.4429Z" fill="#FDFD96" stroke="#121212" stroke-width="5" />
                </svg>
                `;
                break;
            case "Error":
                return `<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" viewBox="0 0 100 100" fill="none">
                    <style>
                        svg { overflow: visible; }
                        #i-circle { stroke-dasharray: 300; stroke-dashoffset: 300; animation: draw-circle .7s ease-in-out forwards; }
                        #i-icon { transform-origin: center; transform: scale(0); animation: animate-icon .7s 0.2s ease-in-out forwards; }
                        @keyframes draw-circle {
                            0% { stroke-dashoffset: 300; }
                            20% { stroke-dashoffset: 300; transform: translateX(15px); }
                            40% { stroke-dashoffset: 300; transform: translateX(-15px); }
                            60% { stroke-dashoffset: 0; transform: translateX(15px); }
                            80% { stroke-dashoffset: 0; transform: translateX(-15px); }
                            100% { stroke-dashoffset: 0; transform: translateX(0px); }
                        }
                        @keyframes animate-icon {
                            0% { transform: scale(0); }
                            20% { transform: scale(1) rotate(-15deg); }
                            40% { transform: scale(1.6) rotate(15deg); }
                            60% { transform: scale(1.6) rotate(-15deg); }
                            80% { transform: scale(1.6) rotate(15deg); }
                            100% { transform: scale(1) rotate(0deg); }
                        }
                    </style>
                    <path id="i-circle" d="M97.5 50C97.5 76.2335 76.2335 97.5 50 97.5C23.7665 97.5 2.5 76.2335 2.5 50C2.5 23.7665 23.7665 2.5 50 2.5C76.2335 2.5 97.5 23.7665 97.5 50Z" stroke="#FF6961" stroke-width="5" stroke-linejoin="round" />
                    <path id="i-icon" d="M43.5 22.5085V61.5339C43.5 65.4001 46.6296 68.5424 50.5 68.5424C54.3704 68.5424 57.5 65.4001 57.5 61.5339V22.5085C57.5 18.6422 54.3704 15.5 50.5 15.5C46.6296 15.5 43.5 18.6422 43.5 22.5085ZM57.5 76.9915C57.5 73.1253 54.3704 69.9831 50.5 69.9831C46.6296 69.9831 43.5 73.1253 43.5 76.9915C43.5 80.8578 46.6296 84 50.5 84C54.3704 84 57.5 80.8578 57.5 76.9915Z" fill="#FF6961" stroke="#121212" stroke-width="5" />
                </svg>
                `;
                break;
            case "Success":
                return `<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" viewBox="0 0 100 100" fill="none">
                    <style>
                        svg { overflow: visible; }
                        #i-circle { stroke-dasharray: 300; stroke-dashoffset: 600; animation: draw-circle .7s ease-in-out forwards; }
                        #i-icon { stroke-dasharray: 72; stroke-dashoffset: 72; animation: animate-icon .7s 0.2s ease-in-out forwards; }
                        @keyframes draw-circle { to { stroke-dashoffset: 0; } }
                        @keyframes animate-icon { to { stroke-dashoffset: 0; } }
                    </style>
                    <path id="i-circle" d="M97.5 50C97.5 76.2335 76.2335 97.5 50 97.5C23.7665 97.5 2.5 76.2335 2.5 50C2.5 23.7665 23.7665 2.5 50 2.5C76.2335 2.5 97.5 23.7665 97.5 50Z" stroke="#77DD77" stroke-width="5" stroke-linejoin="round" />
                    <path id="i-icon" d="M24 53L38.2929 67.2929C38.6834 67.6834 39.3166 67.6834 39.7071 67.2929L75 32" stroke="#77DD77" stroke-width="5" stroke-linecap="round" />
                </svg>
                `;
                break;
            case "Info":
            default:
                return `<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" viewBox="0 0 100 100" fill="none">
                    <style>
                        svg { overflow: visible; }
                        #i-circle { stroke-dasharray: 300; stroke-dashoffset: 300; animation: draw-circle 0.4s ease-in-out forwards; }
                        #i-icon { transform-origin: center; transform: scale(0); animation: animate-icon 0.7s 0.1s ease-in-out forwards; }
                        @keyframes draw-circle { to { stroke-dashoffset: 0; } }
                        @keyframes animate-icon {
                            0% { transform: scale(0); }
                            20% { transform: scale(1) rotate(-15deg); }
                            40% { transform: scale(1.6) rotate(15deg); }
                            60% { transform: scale(1.6) rotate(-15deg); }
                            80% { transform: scale(1.6) rotate(15deg); }
                            100% { transform: scale(1) rotate(0deg); }
                        }
                    </style>
                    <path id="i-circle" d="M97.5 50C97.5 76.2335 76.2335 97.5 50 97.5C23.7665 97.5 2.5 76.2335 2.5 50C2.5 23.7665 23.7665 2.5 50 2.5C76.2335 2.5 97.5 23.7665 97.5 50Z" stroke="#3D426B" stroke-width="5" stroke-linejoin="round" />
                    <path id="i-icon" d="M57.5 76.9915V37.9661C57.5 34.0999 54.3704 30.9576 50.5 30.9576C46.6296 30.9576 43.5 34.0999 43.5 37.9661V76.9915C43.5 80.8578 46.6296 84 50.5 84C54.3704 84 57.5 80.8578 57.5 76.9915ZM43.5 22.5085C43.5 26.3747 46.6296 29.5169 50.5 29.5169C54.3704 29.5169 57.5 26.3747 57.5 22.5085C57.5 18.6422 54.3704 15.5 50.5 15.5C46.6296 15.5 43.5 18.6422 43.5 22.5085Z" fill="#3D426B" stroke="#121212" stroke-width="5" />
                </svg>
                `;
                break;
        }
    }
}