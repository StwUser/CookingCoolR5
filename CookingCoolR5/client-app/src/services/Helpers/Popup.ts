export function showPopup(message: string) : void {
    const popup = document.getElementById('Popup') as HTMLDivElement;
    popup.innerHTML = message;
    popup.classList.add("Show-popup");

    const doc = document.getElementById('root') as HTMLElement;
    doc.addEventListener("click", hidePopup);
};

const hidePopup = () : void => {
    const popup = document.getElementById('Popup') as HTMLDivElement;
    popup.classList.remove("Show-popup");
    popup.classList.add("Hide-popup")

    setTimeout(() => {
        popup.classList.remove("Hide-popup");
    }, 3000);
};