# CSVFileUploadAPI
API реализовано на язык C#, с использованием базы данных EntityFrameworInMemory. С помощью этого веб сервиса можно загрузить любой файл в формате csv в базу данных, для дальнейшей работы с данными файла. База данных хронит в себе ID файла, название и данные файла.
# Методы
## Post Add Data
* В качетве параметров принимает сам файл и его ID для записи в БД
* В случае успешного запроса возвращает информацию о файле
* В случае неуспешного запроса выводится информация об ошибке
## Get Get All Data
* В случае успешного запроса возвращает информацию о всех файлов в базе данных в формате (ID, имя файла, Название столбцов - содержание файла)
* В случае неуспешного запроса выводится информация об ошибке
## Get Get Data By Id
* В качетве параметров принимает ID файла в Базе Данных
* В случае успешного запроса возвращает информацию о файле в базе данных в формате (ID, имя файла, Название столбцов - содержание файла)
* В случае неуспешного запроса выводится информация об ошибке
