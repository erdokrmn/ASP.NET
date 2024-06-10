const link1 = document.getElementById("link1");
const link2 = document.getElementById("link2");
// Diğer linkler buraya eklenir

link1.addEventListener("click", () => {
    loadContent("Link 1 İçeriği");
});

link2.addEventListener("click", () => {
    loadContent("Link 2 İçeriği");
});

// Diğer linklerin dinleyicileri buraya eklenir

function loadContent(content) {
    const mainContent = document.querySelector(".main-content");
    mainContent.innerHTML = `<h2>${content}</h2>`;
}