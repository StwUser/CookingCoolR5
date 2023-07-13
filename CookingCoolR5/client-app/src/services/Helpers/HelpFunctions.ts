import { setFlagsFromString } from "v8";

export function timeOut(delay: number) {
  return new Promise((res) => setTimeout(res, delay));
}

// min and max included
export function randomIntFromInterval(min: number, max: number): number {
  return Math.floor(Math.random() * (max - min + 1) + min);
}
// min and max included
export function* fromToIntIterator(from: number, to: number): any {
  let start = from;
  while (start <= to) {
    yield start;
    start++;
    if (start > to) {
      start = from;
    }
  }
}