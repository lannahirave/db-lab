ІНФОРМАЦІЙНІ ТЕХНОЛОГІЇ
2023-2024 н.р.
Завдання: Фрагментарна реалізація системи управління табличними базами даних
Загальні вимоги
Основні вимоги щодо структури бази:
 кількість таблиць принципово не обмежена (реляції між таблицями не враховувати);
 кількість полів та кількість записів у кожній таблиці також принципово не обмежені.
У кожній роботі для всіх варіантів для полів у таблицях треба забезпечити підтримку таких типів:
 integer;
 real;
 char;
 string.
Також у кожній роботі треба реалізувати функціональну підтримку для:
 створення бази;
 створення (із валідацією даних) та знищення таблиці з бази;
 перегляду та редагування рядків таблиці;
 збереження табличної бази на диску та зчитування її з диску.
Результатом виконання кожного етапу є представлення набору моделей UML/програмного рішення та текстового звіту в електронній формі.
Визначення персонального варіанту
 Для індивідуальних завдань варіант визначається двома останніми цифрами в номері студентського витка. Перша з цих цифр позначає номер у списку
додаткових ТИПІВ, друга – номер у списку ОПЕРАЦІЙ (див нижче).
 Для групових завдань варіант обирається як індивідуальний варіант одного з учасників
(ТИПИ) Варіанти додаткових типів відповідно до варіанту
Потрібно забезпечити підтримку (для можливого використання у таблицях) двох додаткових типів у відповідності з одним із наступних варіантів:
0) color (RGB код кольору); colorInvl;
1) текстові файли; integerInvl;
2) html-файли; stringInvl;

3) charInvl; string(charInvl);
4) перелiчуваний тип (множину значень складає набiр рядкiв); email;
5) date; dateInvl;
6) time; timeInvl;
7) $ (грошовий форматний тип, max$ =10,000,000,000,000.00); $Invl;
8) complexInteger; complexReal;
9) picture-файли (один з форматів); realInvl;
Примiтка. Типи із суфіксом Invl (наприклад, colorInvl, integerInvl тощо) є "iнтервальними" типами.
(ОПЕРАЦІЇ) Варіанти додаткових операцiй над таблицями відповідно до варіанту
0) сортування таблиці за одним полем;
1) пошук (за шаблоном) та перегляд знайдених рядкiв таблицi;
2) об'єднання таблиць;
3) рiзниця таблиць;
4) перетин таблиць;
5) вилучення повторюваних рядкiв у таблиці;
6) прямий добуток двох таблиць;
7) проекцiя таблиць;
8) сполучення таблиць (за спiльним полем);
9) перейменування та/або перестановка колонок таблиці (з відповідною зміною схеми таблиці).