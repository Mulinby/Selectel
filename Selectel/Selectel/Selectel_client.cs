using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.IO.Ports;
using Selectel.Properties;
using System.Threading;
using System.IO.Compression;

namespace Selectel
{
    public partial class Main_window : Form
    {
        string data = "0";                                                   // Пришедшие данные
        SerialPort port = new SerialPort();                                  // Экземпляр COM порта
        static readonly char[] separator = { '\r', '\n' };                   // Вырезаем символы переноса и новой строки из сообщения
        private string _ftpServerIp = "ftp.selcdn.ru";                       // Имя хоста
        private string _ftpContiner = "Maneki";                              // Имя контейнера
        private string _user;                                                // Имя юзера
        private string _password;                                            // Пароль
        private string _path;                                                // Путь к файлу
        private string _name;                                                // Файл
        private string _extension;                                           // Здесь храним расширение выбранного файла
        private string _date;                                                // Здесь храним текущую дату и время
        private float _size;                                                 // Размер файла байт

        private bool replace;                                                // Заменять ли файл
        private bool folder;                                                 // Отправлять ли папку целиком

        public Main_window()
        {
            InitializeComponent();

            // Функции для сворачивания в трей
            notifyIcon.Visible = false;                                         // Прячем иконку из трея
            // Добавляем событие по 2му клику мышки, вызывая функцию  notifyIcon1_MouseDoubleClick
            this.notifyIcon.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);          // добавляем событие на изменение окна

            // Получаем сохраненные ранее данные из настроек
            _ftpServerIp = (string)Settings.Default["Server"];                  // Адрес сервера
            _user = (string)Settings.Default["User"];                           // Имя пользователя
            _password = (string)Settings.Default["Password"];                   // Пароль
            _ftpContiner = (string)Settings.Default["Container"];               // Название контейнера
            _path = (string)Settings.Default["Path"];                           // Путь к файлу/папке
            _name = (string)Settings.Default["FileName"];                       // Имя файла/архива
            _extension = (string)Settings.Default["Extension"];                 // Расширение
            // Присваваем соответствующим текстовым полям сохраненные ранее значения
            textServer.Text = _ftpServerIp;
            textUser.Text = _user;
            textPass.Text = _password;
            textContainer.Text = _ftpContiner;
            textPath.Text = _path;
            textFileName.Text = _name;
            textExtension.Text = _extension;

            replace = (bool)Settings.Default["Replace"];                        // Получаем значение "Заменить файл"
            folder = (bool)Settings.Default["Folder"];                          // Получаем значение "Папка целиком"
            // Устанавливаем сохраненные значения чекбоксов
            checkReplace.Checked = replace;
            checkFolder.Checked = folder;
            // В зависимости от значения чекбокса "Папка целиком" устанавливаем соответсвующую подпись и включаем/отключаем надписи
            if (folder)
            {
                labelPath.Text = "ПУТЬ К ПАПКЕ";
                textCount.Enabled = true;
                labelCount.Enabled = true;
            }
            else
            {
                labelPath.Text = "ПУТЬ К ФАЙЛУ";
                textCount.Enabled = false;
                labelCount.Enabled = false;
            }
        }
        // Записываем новые данные в настройки...
        private void Main_window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default["Server"] = textServer.Text;
            Settings.Default["User"] = textUser.Text;
            Settings.Default["Password"] = textPass.Text;
            Settings.Default["Container"] = textContainer.Text;
            Settings.Default["Path"] = _path; 
            Settings.Default["FileName"] = _name;
            Settings.Default["Extension"] = _extension;

            Settings.Default["Replace"] = checkReplace.Checked;
            Settings.Default["Folder"] = checkFolder.Checked;
            Settings.Default.Save();                                            // ...и сохраняем
        }

        ////////////////////////////////////// FORM   ////////////////////////////////////////////    
        private void Main_window_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();                         // Создаем список портов
            foreach (string port in ports) portList.Items.Add(port);            // И записываем его в комбобокс
            portList.SelectedIndex = 0;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)                       // Проверяем окно
            {
                this.ShowInTaskbar = false;                                     // Прячем окно из панели
                notifyIcon.Visible = true;                                      // Делаем иконку в трее активной
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false;                                         // Прячем  иконку в трее 
            this.ShowInTaskbar = true;                                          // Возвращаем отображение окна в панели
            WindowState = FormWindowState.Normal;                               // Разворачиваем окно
        }

        ////////////////////////////////////// ВЫБОР ПОРТА   ////////////////////////////////////////////    
        // Тут мы в комбобокс передаем список портов по клику по самому комбобоксу
        private void comboBox1_DropDown(object sender, EventArgs e)             // При открытии комбобокса обновляем список портов
        {
            portList.Items.Clear();                                             // Очищаем список портов в комбобоксе
            string[] ports = SerialPort.GetPortNames();                         // Создаем списко портов
            foreach (string port in ports) portList.Items.Add(port);            // И запизиваем его в комбобокс
        }
        // По клику по кнопке «Подключить», срабатывает код ниже
        private void btn_connect_Click(object sender, EventArgs e)              // Клик по кнопке
        {
            if (!port.IsOpen)                                                   // Если порт закрыт
            {
                try                                                             // Пробуем
                {
                    port.PortName = portList.SelectedItem.ToString();           // Используем выбранный порт
                    port.BaudRate = 9600;                                       // Задаем скорость порта
                    port.Open();                                                // Открываем порт
                    // Создаем слушатель принятого сообщения
                    port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                }
                catch                                                           // Не получилось
                {
                    textStatus.Text = "Новозможно подключиться. Порт занят";
                }
                if (port.IsOpen)                                                // Если порт открыли
                {
                    btn_connect.Text = "ОТКЛЮЧИТЬСЯ";                           // Меняем надпись на кнопке
                    textStatus.Text = "Подключено к " + port.PortName;          // Обновляем текст статуса
                    port.Write("1");                                            // При подключении, котик мяукает
                }
            }
            else                                                                // Если порт открыт
            {
                port.Close();                                                   // Закрываем порт
                btn_connect.Text = "ПОДКЛЮЧИТЬСЯ";                              // Меняем надпись на кнопке
                textStatus.Text = "Отключено";                                  // Обновляем текст статуса
            }
        }

        ////////////////////  ПРИЕМ СООБЩЕНИЯ  /////////////////////////////////////////////
        // Тот самый слушатель приема сообщения, который мы создали выше
        private void Port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if(port.IsOpen)                                                     // Если порт открыт
            {
                Thread.Sleep(10);                                               // Задержка для приема всего сообщения
                String str = port.ReadExisting();                               // Читаем все пришедшие байты
                // Вырезаем символы переноса строки и новой строки
                String[] strArr = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                LabelsRefreshSafe(strArr);                                      // Передаем строку в другой поток
            } 
        }

        private void LabelsRefreshSafe(String[] strArr)                         // Потоково безопасный метод
        {
            if (this.InvokeRequired) this.Invoke(new Action<String[]>((d) => LabelsRefresh(d)), new Object[] { strArr });
            else LabelsRefresh(strArr);
        }
        
        private void LabelsRefresh(String[] str)                                // Обычный метод 
        {
            for (int i = 0; i < str.Length; i++)                                // Собираем строку по символам
            {
                data = str[i].ToString();                                       // Наша строка
                if (data == "2") sendFTP();                                     // Если пришла "2" вызываем функцию отправки файла на сервер
            }
        }

        ////////////////////  ОТПРАВКА ФАЙЛА  /////////////////////////////////////////////
        private void sendFTP()
        {
            string temp_path = _path;                                           // Путь к файлу
            // Если отправляем папку
            if (folder)
            {
                if (File.Exists(_path + ".zip")) File.Delete(_path + ".zip");   // Проверяем есть ли такой архив, если да, то удаляем
                ZipFile.CreateFromDirectory(_path, _path + ".zip");             // Создаем новый архив

                temp_path = _path + ".zip";                                     // Обновляем путь к архиву
                _extension = ".zip";                                            // Присваиваем переменной значение ".zip"

                // Получаем информацию о имени и размере архива, для вывода в текстовые блоки
                FileInfo fileInfo = new FileInfo(temp_path);                    // Создаем новый объект FileInfo
                _name = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".")); // Присваиваем переменной имя архива без расширения
                _size = fileInfo.Length;                                        // Присваиваем переменной размер архива в байтах

                textFileName.Text = _name;                                      // Присваиваем текстовому блоку имя архива
                textExtension.Text = ".zip";                                    // Присваиваем текстовому блоку расширение архива
                
                // Присваиваем текстовому блоку размер архива в соответствии с его размером: байты, Кб, Мб, Гб
                if (_size < 1000) textSize.Text = _size.ToString("0.#") + "Байт";
                if (_size > 1000) textSize.Text = (_size / 1000).ToString("0.#") + "Кб";
                if (_size > 1000000) textSize.Text = (_size / 1000000).ToString("0.#") + "Мб";
                if (_size > 1000000000) textSize.Text = (_size / 1000000000).ToString("0.#") + "Гб";

                string[] files = Directory.GetFiles(_path);                     // Получаем количество файлов в корневой дирректории
                textCount.Text = files.Length.ToString();                       // Присваиваем текстовому блоку количество файлов
            }

            // Присваиваем текстовому блоку размер архива в соответствии с его размером: байты, Кб, Мб, Гб
            if (_size < 1000) textSize.Text = _size.ToString("0.#") + "Байт";
            if (_size > 1000) textSize.Text = (_size / 1000).ToString("0.#") + "Кб";
            if (_size > 1000000) textSize.Text = (_size / 1000000).ToString("0.#") + "Мб";
            if (_size > 1000000000) textSize.Text = (_size / 1000000000).ToString("0.#") + "Гб";

            try
            {
            //Запрос
            if (replace) _date = "";                                            // Пустая строка
                else _date = DateTime.Now.ToString("_MM:dd_HH:mm:ss");          // Строка с датой и временем   
                string uri = "ftp://" + this._ftpServerIp                       // Строка
                    + "/"
                    + this._ftpContiner                                         // Имя хоста
                    + "/"
                    + this._name                                                // Имя файла  
                    + this._date                                                // Строка с датой и временем
                    + this._extension;                                          // Строка с расширением файла

                FtpWebRequest FTPR = (FtpWebRequest)WebRequest.Create(uri);     // Создаем запрос
                FTPR.Credentials = new NetworkCredential(this._user, this._password); // Отправляем учетные данные
                FTPR.Method = WebRequestMethods.Ftp.UploadFile;                 // Загрузка файла
                FTPR.Proxy = null;                                              // Не используем прокси
                FTPR.UseBinary = true;                                          // Вариант либо ASCI (текст) либо Binary (что угодно)
                FTPR.KeepAlive = true;                                          // Закрывать ли подключение после завершения запроса

                // Запись файла в качестве аргументов передаем полный путь к файлу
                using (FileStream fileStream = File.OpenRead(temp_path))
                {
                    FTPR.ContentLength = fileStream.Length;
                    using (Stream ftpRequestStream = FTPR.GetRequestStream())
                    {
                        byte[] buffer = new byte[4096];
                        int cnt = 0;
                        do
                        {
                            cnt = fileStream.Read(buffer, 0, buffer.Length);
                            if (cnt == 0) { break; }
                            ftpRequestStream.Write(buffer, 0, cnt);
                        } while (true);
                    }
                }

                using (FtpWebResponse ftpResp = (FtpWebResponse)FTPR.GetResponse())            // Запрос на ответ
                {
                    if (port.IsOpen)                                                           // Если порт открыт
                    {
                        if (ftpResp.StatusCode == FtpStatusCode.ClosingData)
                        {
                            textStatus.Text = "Отправка произведена успешно";                  // Обновляем текст статуса
                            port.Write("1");                                                   // Все хорошо - шлем "1"
                        }
                        else port.Write("0");                                                  // Что-то не так на сервере - шлем "0"
                    }
                }
            }
            catch (WebException)
            {
                textStatus.Text = "Проблемы с ответом от сервера";                             // Обновляем текст статуса
                port.Write("0");                                                               // Что-то не так с интернетом - шлем "0"
            }
            catch (Exception)
            {
                textStatus.Text = "Проблемы с программой";                                     // Обновляем текст статуса
                port.Write("0");                                                               // Что-то не так с приложением - шлем "0"
            };
            if (folder) File.Delete(temp_path);
        }

        // Если кликнули по чекбоксу "Заменять файл"
        private void CheckReplace_CheckedChanged(object sender, EventArgs e)
        {
            replace = checkReplace.Checked;                                                    // Обновляем значение переменной
            if (replace) textStatus.Text = "Исходный файл будет заменен";                      // Обновляем текст статуса
            else textStatus.Text = "Будет создана новая версия файла";                         // Обновляем текст статуса
        }

        // Если кликнули по чекбоксу "Папка целиком"
        private void CheckFolder_CheckedChanged(object sender, EventArgs e)
        {
            folder = checkFolder.Checked;                                                      // Обновляем значение переменной
            if (folder)
            {
                textStatus.Text = "Будет отправлена сжатая папка";                             // Обновляем текст статуса
                labelPath.Text = "ПУТЬ К ПАПКЕ";                                               // Обновляем текст пути
                // Активируем строку с количеством файлов в архиве
                textCount.Enabled = true;
                labelCount.Enabled = true;
            }
            else
            {
                textStatus.Text = "Будет отправлен один файл";                                 // Обновляем текст статуса
                labelPath.Text = "ПУТЬ К ФАЙЛУ";                                               // Обновляем текст пути
                // Деактивируем строку с количеством файлов в архиве
                textCount.Enabled = false;
                labelCount.Enabled = false;
                textCount.Text = "0";
            }
        }

        // Клик по текстовому полю "ПУТЬ К ФАЙЛУ"
        private void TextPath_Click(object sender, EventArgs e)
        {
            // Если отправляем папку
            if (folder)
            {
                var fbd = new FolderBrowserDialog();                                           // Создаем диалоговое окно выбора папки
                DialogResult result = fbd.ShowDialog();                                        // Создаем переменную завершения выбора папки

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) // Если нажали "Ок" и папка выбрана
                {
                    _path = fbd.SelectedPath;                                                  // Присваиваем переменной новый путь
                    textPath.Text = _path;                                                     // Присваиваем текстовому полю новый путь
                    if (File.Exists(_path + ".zip")) File.Delete(_path + ".zip");              // Проверяем есть ли такой архив, если да, то удаляем
                    ZipFile.CreateFromDirectory(_path, _path + ".zip");                        // Создаем новый архив
                    FileInfo fileInfo = new FileInfo(_path + ".zip");                          // Создаем новый объект FileInfo
                    _name = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf("."));            // Присваиваем переменной имя файла без расширения
                    _extension = ".zip";                                                       // Присваиваем переменной значение ".zip"
                    _size = fileInfo.Length;                                                   // Присваиваем переменной размер архива в байтах

                    textFileName.Text = _name;                                                 // Присваиваем текстовому блоку имя архива
                    textExtension.Text = ".zip";                                               // Присваиваем текстовому блоку расширение архива
                    
                    // Присваиваем текстовому блоку размер архива в соответствии с его размером: байты, Кб, Мб, Гб
                    if (_size < 1000) textSize.Text = _size.ToString("0.#") + "Байт";
                    if (_size > 1000) textSize.Text = (_size / 1000).ToString("0.#") + "Кб";
                    if (_size > 1000000) textSize.Text = (_size / 1000000).ToString("0.#") + "Мб";
                    if (_size > 1000000000) textSize.Text = (_size / 1000000000).ToString("0.#") + "Гб";

                    // Активируем строку с количеством файлов в архиве
                    textCount.Enabled = true;
                    labelCount.Enabled = true;
                    string[] files = Directory.GetFiles(fbd.SelectedPath);                     // Получаем количество файлов в корневой дирректории
                    textCount.Text = files.Length.ToString();                                  // Присваиваем текстовому блоку количество файлов
                }     
            }
            // Если отправляем файл
            else
            {
                OpenFileDialog FileDialog = new OpenFileDialog();                              // Создаем диалоговое окно выбора файла
                FileDialog.InitialDirectory = @"С:\";                                          // Директория "по умолчанию"

                if (FileDialog.ShowDialog() == DialogResult.OK)                                // Если файл выбран
                {
                    FileInfo fileInfo = new FileInfo(FileDialog.FileName);                     // Создаем новый объект FileInfo

                    _path = FileDialog.FileName;                                               // Присваиваем переменной новый путь
                    _name = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf("."));            // Присваиваем переменной имя файла без расширения
                    _extension = fileInfo.Extension;                                           // Присваиваем переменной расширения файла
                    _size = fileInfo.Length;                                                   // Присваиваем переменной размер архива в байтах

                    textPath.Text = _path;                                                     // Присваиваем текстовому полю новый путь
                    textFileName.Text = _name;                                                 // Присваиваем текстовому блоку имя архива
                    textExtension.Text = _extension;                                           // Присваиваем текстовому блоку расширение архива

                    // Присваиваем текстовому блоку размер архива в соответствии с его размером: байты, Кб, Мб, Гб
                    if (_size < 1000) textSize.Text = _size.ToString("0.#") + "Байт";
                    if (_size > 1000) textSize.Text = (_size/1000).ToString("0.#") + "Кб";
                    if (_size > 1000000) textSize.Text = (_size / 1000000).ToString("0.#") + "Мб";
                    if (_size > 1000000000) textSize.Text = (_size / 1000000000).ToString("0.#") + "Гб";

                    // Деактивируем строку с количеством файлов в архиве
                    textCount.Enabled = false;
                    labelCount.Enabled = false;
                    textCount.Text = "0";
                }
            }
        }
    }
}