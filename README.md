# Pump equipment
Описание: Проект .NET 6.0 API, использующий Entity Framework, Entity Framework Design и Entity Framework Tools для взаимодействия с базой данных PostgreSQL, а также Angular-frontend для реализации API.

# Функции:

Три основные сущности: Pump, Motor, Material  
CRUD (Create, Read, Update, Delete) операции для каждой сущности  
API-endpoints:  
Pump:  
POST /pump: Создать новый насос  
GET /pump: Получить все насосы  
PUT /pump/{id}: Обновить конкретный насос  
DELETE /pump/{id}: Удалить конкретный насос  
Motor:  
POST /motor: Создать новый мотор  
GET /motor: Получить все моторы  
PUT /motor/{id}: Обновить конкретный мотор  
DELETE /motor/{id}: Удалить конкретный мотор  
Material:  
POST /material: Создать новый материал  
GET /material: Получить все материалы  
PUT /material/{id}: Обновить конкретный материал  
DELETE /material/{id}: Удалить конкретный материал  
# Зависимости:

.NET 6.0  
Entity Framework 6.0  
Entity Framework Design 6.0  
Entity Framework Tools 6.0  
Npgsql для PostgreSQL  

# Frontend:

Angular 12+
Использует API-endpoints выше для выполнения CRUD-операций над сущностями
# Начало работы:

Клонировать репозиторий и перейти в папку проекта.  
Запустить команду dotnet run для запуска .NET 6.0 API.  
Скачать пакеты для Angular проекта командой npm install --force.  
Запустить команду ng serve для запуска Angular frontend.  
Открыть веб-сайт в браузере и перейти по адресу http://localhost:4200 для доступа к frontend.  
Использовать инструмент, seperti Postman или cURL для тестирования endpoints API.  
# Функции:

Список всех насосов, моторов и материалов  
Создание новых насосов, моторов и материалов  
Редактирование существующих насосов, моторов и материалов  
Удаление насосов, моторов и материалов  
Разработка:  

Этот проект использует TypeScript и JavaScript для frontend.  
Angular frontend использует Observables и RXJS для обработки асинхронной загрузки и манипуляции данными.  

# Настройка:

API использует базу данных PostgreSQL, настроенную в файле appsettings.json. Вы можете изменить строку подключения к вашей собственной базе данных.
