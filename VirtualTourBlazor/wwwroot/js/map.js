// wwwroot/js/map.js
window.mapFunctions = {
    // Инициализация карты
    initMap: function (elementId, lat, lng, zoom) {
        try {
            const map = L.map(elementId).setView([lat, lng], zoom);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '© OpenStreetMap contributors',
                maxZoom: 19
            }).addTo(map);

            // Сохраняем карту для дальнейшего использования
            window.mapInstances = window.mapInstances || {};
            window.mapInstances[elementId] = map;

            // Сохраняем маркеры для этой карты
            window.mapMarkers = window.mapMarkers || {};
            window.mapMarkers[elementId] = [];

            return true;
        } catch (error) {
            console.error('Ошибка при инициализации карты:', error);
            return false;
        }
    },

    // Добавление маркера
    addMarker: function (elementId, lat, lng, title, description) {
        try {
            const map = window.mapInstances?.[elementId];
            if (!map) {
                console.error('Карта не инициализирована:', elementId);
                return false;
            }

            const marker = L.marker([lat, lng]).addTo(map);

            if (title || description) {
                const popupContent = `
                    <div class="map-popup">
                        ${title ? `<h6 class="fw-bold mb-2">${title}</h6>` : ''}
                        ${description ? `<p class="mb-0 small">${description}</p>` : ''}
                    </div>
                `;
                marker.bindPopup(popupContent);
            }

            // Сохраняем маркер
            if (window.mapMarkers[elementId]) {
                window.mapMarkers[elementId].push(marker);
            }

            return true;
        } catch (error) {
            console.error('Ошибка при добавлении маркера:', error);
            return false;
        }
    },

    // Увеличение масштаба
    zoomIn: function (elementId) {
        try {
            const map = window.mapInstances?.[elementId];
            if (map) {
                map.zoomIn();
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при увеличении:', error);
            return false;
        }
    },

    // Уменьшение масштаба
    zoomOut: function (elementId) {
        try {
            const map = window.mapInstances?.[elementId];
            if (map) {
                map.zoomOut();
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при уменьшении:', error);
            return false;
        }
    },

    // Перемещение к точке
    flyTo: function (elementId, lat, lng, zoom) {
        try {
            const map = window.mapInstances?.[elementId];
            if (map) {
                map.flyTo([lat, lng], zoom || 15);
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при перемещении:', error);
            return false;
        }
    },

    // Сброс вида к исходному
    resetView: function (elementId) {
        try {
            const map = window.mapInstances?.[elementId];
            if (map && window.mapMarkers[elementId] && window.mapMarkers[elementId].length > 0) {
                // Создаем bounds на основе всех маркеров
                const group = new L.featureGroup(window.mapMarkers[elementId]);
                map.fitBounds(group.getBounds().pad(0.1));
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при сбросе вида:', error);
            return false;
        }
    },

    // Подгонка карты под все маркеры
    fitBounds: function (elementId) {
        try {
            const map = window.mapInstances?.[elementId];
            if (map && window.mapMarkers[elementId] && window.mapMarkers[elementId].length > 0) {
                const group = new L.featureGroup(window.mapMarkers[elementId]);
                map.fitBounds(group.getBounds().pad(0.1));
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при подгонке карты:', error);
            return false;
        }
    },

    // Очистка всех маркеров
    clearMarkers: function (elementId) {
        try {
            const markers = window.mapMarkers?.[elementId];
            if (markers) {
                markers.forEach(marker => {
                    marker.remove();
                });
                window.mapMarkers[elementId] = [];
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при очистке маркеров:', error);
            return false;
        }
    },

    // Удаление карты 24
    removeMap: function (elementId) {
        try {
            const map = window.mapInstances?.[elementId];
            if (map) {
                map.remove();
                delete window.mapInstances[elementId];
                delete window.mapMarkers[elementId];
                return true;
            }
            return false;
        } catch (error) {
            console.error('Ошибка при удалении карты:', error);
            return false;
        }
    }
};