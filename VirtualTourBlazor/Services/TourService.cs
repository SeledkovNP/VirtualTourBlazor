using VirtualTourBlazor.Models;

namespace VirtualTourBlazor.Services
{
    public class TourService : ITourService
    {
        private readonly List<Tour> _tours = new();
        private readonly List<Guide> _guides = new();
        private int _nextTourId = 1;
        private int _nextReviewId = 1;
        private int _nextPlaceId = 11; // Продолжаем с 11, так как уже есть 10 мест

        public TourService()
        {
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            // Создаем гидов с шутливыми именами
            var guide1 = new Guide
            {
                Id = 1,
                Name = "Иван умный",
                Email = "1@mail.com",
                Bio = "Опытный гид с 10-летним стажем. Знает все секреты городов России."
            };

            var guide2 = new Guide
            {
                Id = 2,
                Name = "ИИ",
                Email = "2@mail.com",
                Bio = "Виртуальный гид-историк. Использую нейросети для анализа исторических событий."
            };

            var guide42 = new Guide
            {
                Id = 42,  // Брат в чём  смисол жизны!
                Name = "Астролог",
                Email = "42@mail.com",
                Bio = "Архитектор и нумеролог. Специализируюсь на тайных значениях чисел в архитектуре городов."
            };

            // Добавляем гидов в список
            _guides.AddRange(new[] { guide1, guide2, guide42 });

            //  ТУР ПО ГАЛАКТИКЕ
            var galaxyPlaces = new List<Place>
            {
                new Place
                {
                    Id = 1,
                    Name = "Планета 42",
                    Description = "Место где хранится Ответ на Главный Вопрос жизни, Вселенной и всего такого",
                    Latitude = 55.7558,
                    Longitude = 37.6173
                },
                new Place
                {
                    Id = 2,
                    Name = "Туманность Андромеды",
                    Description = "Соседняя галактика с удивительными видами на звёздные скопления",
                    Latitude = 55.7517,
                    Longitude = 37.6178
                },
                new Place
                {
                    Id = 3,
                    Name = "Черная дыра",
                    Description = "Захватывающее путешествие через пространство-время. Не забудьте полотенце!",
                    Latitude = 55.7603,
                    Longitude = 37.6256
                },
                new Place
                {
                    Id = 4,
                    Name = "Ресторан «У конца Вселенной»",
                    Description = "Место, где можно попробовать блюда со всех уголков галактики",
                    Latitude = 55.7580,
                    Longitude = 37.6195
                }
            };

            var galaxyTour = new Tour
            {
                Id = _nextTourId++,
                Name = "Тур по галактике",
                Description = "Вы узнаете секрет 42, и побываете там где я сам не знаю где. Не забудьте полотенце!",
                Guide = guide42,
                Places = galaxyPlaces
            };

            // Добавляем отзывы!
            galaxyTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Артур Дент",
                Rating = 5,
                Comment = "Не забудьте полотенце! Отличный тур! Особенно понравился ресторан в конце Вселенной."
            });

            galaxyTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Форд Префект",
                Rating = 4,
                Comment = "Лучший тур после паба! Но не хватило информации о черных дырах. И где бинтакурагафон?"
            });

            galaxyTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Зафод Библброкс",
                Rating = 3,
                Comment = "Слишком много ходьбы! Где мой корабль «Золотое Сердце»? Нужен транспорт получше."
            });

            _tours.Add(galaxyTour);

            //  ТУР ПО МОСКВЕ 
            var moscowTour = new Tour
            {
                Id = _nextTourId++,
                Name = "Классическая Москва",
                Description = "Знакомство с главными достопримечательностями столицы России",
                Guide = guide1,
                Places = new List<Place>
                {
                    new Place {
                        Id = 5,
                        Name = "Красная площадь",
                        Description = "Главная площадь страны. Здесь проходят все важнейшие события России",
                        Latitude = 55.7539,
                        Longitude = 37.6208
                    },
                    new Place {
                        Id = 6,
                        Name = "Парк Горького",
                        Description = "Центральный парк культуры и отдыха. Идеальное место для прогулок",
                        Latitude = 55.7297,
                        Longitude = 37.6040
                    },
                    new Place {
                        Id = 7,
                        Name = "ВДНХ",
                        Description = "Выставка достижений народного хозяйства. Архитектурный ансамбль разных эпох",
                        Latitude = 55.8294,
                        Longitude = 37.6322
                    },
                    new Place {
                        Id = 8,
                        Name = "Москва-Сити",
                        Description = "Деловой центр с небоскрёбами. Панорамный вид на город с высоты",
                        Latitude = 55.7496,
                        Longitude = 37.5398
                    }
                }
            };

            moscowTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Анна Петрова",
                Rating = 5,
                Comment = "Отличный тур! Гид Иван очень знающий, показал все главные места Москвы."
            });

            moscowTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Михаил Соколов",
                Rating = 4,
                Comment = "Хороший маршрут, но хотелось бы больше времени на ВДНХ. Очень интересное место!"
            });

            _tours.Add(moscowTour);

            //  ТУР ПО ТЮМЕНИ 
            var tyumenTour = new Tour
            {
                Id = _nextTourId++,
                Name = "Тюмень - первая столица Сибири",
                Description = "Исторический и современный облик первого русского города в Сибири",
                Guide = guide1,
                Places = new List<Place>
                {
                    new Place {
                        Id = 9,
                        Name = "Набережная реки Туры",
                        Description = "Одна из самых красивых набережных в России. Четырехуровневый комплекс с фонтанами",
                        Latitude = 57.1612,
                        Longitude = 65.542274
                    },
                    new Place {
                        Id = 10,
                        Name = "Мост Влюбленных",
                        Description = "Пешеходный вантовый мост с великолепным видом на город. Место для романтических прогулок",
                        Latitude = 57.1637,
                        Longitude = 65.5214
                    },
                    new Place {
                        Id = 11,
                        Name = "Цветной бульвар",
                        Description = "Пешеходная зона с пятью площадями, фонтанами, колесом обозрения и аттракционами",
                        Latitude = 57.151164,
                        Longitude = 65.537705
                    },
                    new Place {
                        Id = 12,
                        Name = "Тюменский драматический театр",
                        Description = "Один из старейших театров Сибири, основан в 1858 году. Великолепная архитектура",
                        Latitude = 57.144431,
                        Longitude = 65.559842
                    },
                    new Place {
                        Id = 13,
                        Name = "Сквер сибирских кошек",
                        Description = "Уникальный сквер с 12 скульптурами кошек. Посвящён кошкам, спасшим Эрмитаж в блокаду",
                        Latitude = 57.153995,
                        Longitude = 65.536762
                    },
                    new Place {
                        Id = 14,
                        Name = "Знаменский кафедральный собор",
                        Description = "Православный храм 18 века, один из старейших в Сибири. Архитектурный памятник",
                        Latitude = 57.15889,
                        Longitude = 65.53207
                    }
                }
            };

            // Добавляем отзывы для тура по Тюмени
            tyumenTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Алексей Тюменцев",
                Rating = 5,
                Comment = "Отличный тур! Узнал много нового о своём городе. Особенно понравилась история про сибирских кошек!"
            });

            tyumenTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Мария Сибирякова",
                Rating = 4,
                Comment = "Очень понравилась набережная и мост Влюбленных. Но хотелось бы больше исторических фактов о купеческой Тюмени."
            });

            tyumenTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Дмитрий Уральский",
                Rating = 5,
                Comment = "Прекрасный гид! Показал и старую, и новую Тюмень. Обязательно вернусь с семьёй!"
            });

            _tours.Add(tyumenTour);

            //  ТУР ПО ПИТЕРУ 
            var peterTour = new Tour
            {
                Id = _nextTourId++,
                Name = "Санкт-Петербург - Северная Венеция",
                Description = "Культурная столица России: дворцы, музеи и разводные мосты",
                Guide = guide2, // ИИ будет гидом
                Places = new List<Place>
                {
                    new Place {
                        Id = 15,
                        Name = "Эрмитаж",
                        Description = "Один из крупнейших художественных музеев мира",
                        Latitude = 59.9398,
                        Longitude = 30.3146
                    },
                    new Place {
                        Id = 16,
                        Name = "Петропавловская крепость",
                        Description = "Историческое ядро города, основанное Петром I",
                        Latitude = 59.9500,
                        Longitude = 30.3167
                    },
                    new Place {
                        Id = 17,
                        Name = "Исаакиевский собор",
                        Description = "Крупнейший православный храм Санкт-Петербурга",
                        Latitude = 59.9341,
                        Longitude = 30.3061
                    }
                }
            };

            peterTour.Reviews.Add(new Review
            {
                Id = _nextReviewId++,
                UserName = "Екатерина Романова",
                Rating = 5,
                Comment = "ИИ-гид просто потрясающий! Знает все даты и факты. Очень необычный опыт!"
            });

            _tours.Add(peterTour);
        }

        public List<Tour> GetAllTours() => _tours;

        public Tour? GetTourById(int id) => _tours.FirstOrDefault(t => t.Id == id);

        public void AddTour(Tour tour)
        {
            tour.Id = _nextTourId++;

            // Генерируем ID для мест
            foreach (var place in tour.Places)
            {
                place.Id = _nextPlaceId++;
            }

            _tours.Add(tour);
        }

        public void UpdateTour(Tour tour)
        {
            var existing = GetTourById(tour.Id);
            if (existing != null)
            {
                var index = _tours.IndexOf(existing);
                _tours[index] = tour;
            }
        }

        public void DeleteTour(int id)
        {
            var tour = GetTourById(id);
            if (tour != null)
            {
                _tours.Remove(tour);
            }
        }

        public void AddReview(int tourId, Review review)
        {
            var tour = GetTourById(tourId);
            if (tour != null)
            {
                review.Id = _nextReviewId++;
                review.CreatedAt = DateTime.Now;
                tour.Reviews.Add(review);
            }
        }

        public List<Guide> GetAllGuides() => _guides;
    }
}