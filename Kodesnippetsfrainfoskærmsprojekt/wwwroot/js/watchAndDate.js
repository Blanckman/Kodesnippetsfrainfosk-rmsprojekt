window.addEventListener('DOMContentLoaded', () => {
    function twoDigits(value) {
        if (value < 10)
            return '0' + value;
        else
            return '' + value;
    }
    let monthName = [
        'januar',
        'februar',
        'marts',
        'april',
        'maj',
        'juni',
        'juli',
        'august',
        'september',
        'oktober',
        'november',
        'december'
    ];

    let dayName = [
        'Søndag',
        'Mandag',
        'Tirsdag',
        'Onsdag',
        'Torsdag',
        'Fredag',
        'Lørdag'
    ];

    setInterval(() => {
        // current date/time
        let now = new Date();
        // date as text
        let dateStr =
            dayName[now.getDay()] + ' d.' +
            now.getDate() + ' ' +
            monthName[now.getMonth()] + ' ' +
            now.getFullYear();
        // time as text
        let timeStr =
            now.getHours() + ':' +
            twoDigits(now.getMinutes()) + ':' +
            twoDigits(now.getSeconds());
        // example: set date and time as text content of spans
        document.getElementById('timeId').textContent = timeStr;
        document.getElementById('dateId').textContent = dateStr;
    }, 100); // 100 ms => update 10 times per second
});
