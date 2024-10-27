# Тестовое задание
[Файлы для запуска](https://github.com/Iv2005an/EffectiveMobile/releases/latest)

## Обработчики:
 - некорректных аргументов;
 - блокировки файлов(заказов, логов), например Excelем;
 - некорректных данных в файле `orders.csv`.

## Аргументы:
- _cityDistrict - номер района(число)
- _firstDeliveryDateTime - время первой доставки
- _deliveryLog - путь до директории с файлом логов, файл лога дописывается с каждым запуском
- _deliveryOrder - путь до директории с файлом отфильтрованных заказов, файл перезаписывается с каждым запуском

Пути поддерживаются и относительные и абсолютные, если есть пробелы то в кавычках.

Пример команды для powershell:

    ./EffectiveMobileConsole.exe _cityDistrict 1 _firstDeliveryDateTime "2024-09-01 12:00:00" _deliveryLog logs _deliveryOrder filtered
