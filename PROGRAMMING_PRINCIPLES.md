# Programming Principles in HrestykyNolyky

## 1. **DRY (Don't Repeat Yourself)**
Логіка перевірки перемоги не дублюється, а винесена в окремий метод.

**Приклад:**  
`Board.CheckForWin()` - один метод для всіх перевірок

## 2. **KISS (Keep It Simple, Stupid)**
Проста структура проектів, зрозумілі назви методів.

## 3. **Single Responsibility Principle**
- `Board` - лише стан ігрового поля
- `GameManager` - логіка гри
- `Player` - абстракція гравця

## 4. **Open/Closed Principle**
Можна додати новий тип гравця через успадкування від `Player`.

## 5. **Dependency Inversion Principle**
`ConsoleBoardObserver` залежить від інтерфейсу `IObserver`.

## 6. **Factory Pattern**
`PlayerFactory` створює об'єкти гравців.