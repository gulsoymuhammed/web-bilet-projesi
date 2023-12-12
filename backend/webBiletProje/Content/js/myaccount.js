window.addEventListener('DOMContentLoaded', (event) => {
    const sidebarItems = document.querySelectorAll('#sidebarMenu .list-group-item');
    const contentContainers = Array.from(document.querySelectorAll('[id^="cardContainer"]'));

    sidebarItems.forEach((item, index) => {
        item.addEventListener('click', () => {
            const activeItem = document.querySelector('.list-group-item.active');
            if (activeItem) {
                activeItem.classList.remove('active');
            }
            item.classList.add('active');

            const contentId = item.getAttribute('data-content');
            contentContainers.forEach((container, index) => {
                container.style.display = index + 1 == parseInt(contentId) ? 'block' : 'none';
            });
        });
    });
});