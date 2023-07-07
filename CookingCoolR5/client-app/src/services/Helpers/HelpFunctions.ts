export function timeOut(delay: number) {
    return new Promise( res => setTimeout(res, delay) );
}

// min and max included
export function randomIntFromInterval(min: number, max: number) : number {  
    return Math.floor(Math.random() * (max - min + 1) + min)
}